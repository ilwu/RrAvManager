using rbt.util;
using RrAvManager.util;
using RrAvManager.util.db;
using RrAvManager.util.def;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RrAvManager.sublogic
{
    internal class SubLogicFileManager
    {
        private static readonly RavmDBUtil ravmDBUtil = new RavmDBUtil("RrAvManager.db");

        public static DataTable ScanFolder(string scanDir, ListBox litBoxFileList)
        {
            scanDir = scanDir.Replace("\\", "/");

            //========================================
            //取得路徑下已經存在資料庫的資料
            //========================================
            //組sql
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("SELECT f.DIRECTORY_PATH, \r\n");
            sqlStr.Append("       f.VIDEO_FILE_NAME, \r\n");
            sqlStr.Append("       f.COVER_FILE_NAME, \r\n");
            sqlStr.Append("       v.* \r\n");
            sqlStr.Append("FROM   FILE_INFO f \r\n");
            sqlStr.Append("       LEFT JOIN VIDEO_INFO v \r\n");
            sqlStr.Append("              ON f.SNO = v.SNO \r\n");
            sqlStr.Append("WHERE  f.DIRECTORY_PATH like :DIR ");

            //查詢參數
            var paramater = new Dictionary<string, object> { { ":DIR", scanDir + "%" } };
            //查詢
            DataTable mainListDatatable = ravmDBUtil.Query(sqlStr.ToString(), paramater);
            // 欄位整理
            SubFunction.GetMainListEmptyDataTable(mainListDatatable);

            //========================================
            //掃瞄檔案路徑
            //========================================
            Dictionary<string, List<string>> fileDataDic = PrepareFileData(scanDir);

            //========================================
            //整理檔案資料
            //========================================

            //清掉debug檔案列表
            litBoxFileList.Items.Clear();

            var index = 0;
            foreach (KeyValuePair<string, List<string>> keyValuePair in fileDataDic)
            {
                //目錄路徑
                string directoryPath = keyValuePair.Key;
                //檔案清單
                List<string> fileList = keyValuePair.Value;

                //影片列表 (過濾附檔名為影片者)
                var movieList = fileList.Select(item => item).Where(item => EvnDef.VIDEO_TYPE.Any((item.ToLower()).EndsWith));

                foreach (var videoFile in movieList)
                {
                    //加入debug檔案列表
                    litBoxFileList.Items.Add(videoFile);

                    //判斷資料是否已經存在於DB
                    var dataRows = mainListDatatable.Select(ColDef.DIRECTORY_PATH + "='" + directoryPath + "' and " + ColDef.VIDEO_FILE_NAME + "='" + videoFile + "'");

                    DataRow fileDataRow;
                    if (dataRows.Length > 0)
                    {
                        fileDataRow = dataRows[0];

                        //先註記檔案存在
                        fileDataRow[ColDef.PROCESS_STATUS] = "-";

                        //檢查封面檔案是否還存在，不存在的話清掉值
                        if (!File.Exists(
                            StringUtil.SafeTrim(fileDataRow[ColDef.DIRECTORY_PATH]) +
                            StringUtil.SafeTrim(fileDataRow[ColDef.COVER_FILE_NAME])))
                        {
                            //清掉封面檔案名稱
                            fileDataRow[ColDef.COVER_FILE_NAME] = null;
                            //註記需要UPDATE
                            fileDataRow[ColDef.PROCESS_STATUS] = "U";
                        }
                    }
                    else
                    {
                        //新增一筆並加進檔案清單
                        fileDataRow = mainListDatatable.NewRow();
                        mainListDatatable.Rows.Add(fileDataRow);

                        //註記需要新增
                        fileDataRow[ColDef.PROCESS_STATUS] = "I";

                        //目錄路徑
                        fileDataRow[ColDef.DIRECTORY_PATH] = directoryPath;

                        //影片檔案名稱
                        fileDataRow[ColDef.VIDEO_FILE_NAME] = videoFile;
                    }

                    //品番：預設以檔名為品番
                    //string sno = StringUtil.SafeTrim(Path.GetFileNameWithoutExtension(videoFile)).ToUpper();
                    //fileDataRow[ColDef.SNO] = sno;

                    //封面檔案名稱 (資料檔中不存在時，判斷路徑下是否有檔案)
                    if (StringUtil.IsEmpty(fileDataRow[ColDef.COVER_FILE_NAME]))
                    {
                        fileDataRow[ColDef.COVER_FILE_NAME] = GetCoverFile(
                            fileList,
                            StringUtil.SafeTrim(fileDataRow[ColDef.SNO]),
                            StringUtil.SafeTrim(Path.GetFileNameWithoutExtension(videoFile)));
                    }

                    //取得封面影像檔
                    fileDataRow[ColDef.COVER_IMAGE] =
                        CommUtil.GetBytesFromImagePath(
                            directoryPath + StringUtil.SafeTrim(fileDataRow[ColDef.COVER_FILE_NAME]),
                            300, 200);

                    //index
                    fileDataRow[ColDef.INDEX] = index++;
                }
            }

            //========================================
            //更新資料庫
            //========================================
            MaintainDirFileInfo(ref mainListDatatable);

            return mainListDatatable;
        }

        #region 準備檔案

        /// <summary>
        ///     準備檔案資料
        /// </summary>
        /// <param name="rootPath">開始掃瞄的根路徑</param>
        /// <returns></returns>
        private static Dictionary<string, List<string>> PrepareFileData(string rootPath)
        {
            //========================================
            //掃瞄路徑下所有檔案
            //========================================
            var fileList = CommUtil.getAllAccesibleFiles(rootPath);

            //========================================
            //整理檔案：以路徑為單位，整理出單一路徑下的 file list
            //========================================
            var fileDic = new Dictionary<string, List<string>>();

            foreach (var fullPath in fileList)
            {
                //取得路徑名稱
                var directoryName = StringUtil.SafeTrim(Path.GetDirectoryName(fullPath));
                directoryName = directoryName.Replace("\\", "/") + "/";

                //路徑檔案 list 不存在時，新增一個檔案list 容器
                if (!fileDic.ContainsKey(directoryName))
                {
                    fileDic.Add(directoryName, new List<string>());
                }

                //將檔案名稱加入 檔案list 容器
                var dirFileList = fileDic[directoryName];
                dirFileList.Add(Path.GetFileName(fullPath));
            }

            return fileDic;
        }

        #endregion 準備檔案

        #region 圖形處理

        //====================================================================
        //取圖
        //====================================================================
        private static string GetCoverFile(List<string> fileList, string sno, string videoFileName)
        {
            //========================================
            //依據附檔名判斷，取得所有圖檔
            //========================================
            var picFileList = fileList.Select(item => item.ToString(CultureInfo.InvariantCulture))
                .Where(item => EvnDef.PIC_TYPE.Any(item.ToLower().EndsWith));

            var picfileNames = picFileList as IList<string> ?? picFileList.ToList();

            //=======================================
            //判斷 1 :檔案名稱和影片檔名一樣
            //=======================================

            foreach (var fileName in picfileNames)
            {
                if (
                    StringUtil.SafeTrim(Path.GetFileNameWithoutExtension(fileName))
                        .ToLower()
                        .Equals(videoFileName.ToLower()))
                {
                    return fileName;
                }
            }

            //=======================================
            //判斷 2 :取得名稱為 品番 的圖檔
            //=======================================
            foreach (var fileName in picfileNames)
            {
                if (StringUtil.SafeTrim(Path.GetFileNameWithoutExtension(sno)).ToLower().Equals(fileName.ToLower()))
                {
                    return fileName;
                }
            }

            //========================================
            //判斷 3 :取得名稱為類似 品番 的圖檔
            //=======================================
            //取得圖片列表
            //where 1 : 檔名 like 品番
            foreach (var fileName in picfileNames)
            {
                if (fileName.Contains(sno))
                {
                    return fileName;
                }
            }

            //========================================
            //判斷 4 :取得名稱為 cover 的圖檔
            //========================================
            //where 1 : 檔名 = "cover"
            foreach (var fileName in picfileNames)
            {
                if (StringUtil.SafeTrim(Path.GetFileNameWithoutExtension(sno)).ToLower().Equals("cover"))
                {
                    return fileName;
                }
            }

            return "";
        }

        #endregion 圖形處理

        /// <summary>
        ///
        /// </summary>
        /// <param name="fileDataTable"></param>
        private static void MaintainDirFileInfo(ref DataTable fileDataTable)
        {
            SQLiteConnection conn = null;
            SQLiteTransaction trns = null;

            try
            {
                conn = new SQLiteConnection("Data Source = RrAvManager.db");
                conn.Open();
                trns = conn.BeginTransaction();

                foreach (DataRow dataRow in fileDataTable.Rows)
                {
                    string procStatue = StringUtil.SafeTrim(dataRow[ColDef.PROCESS_STATUS]);

                    var whereColumn = new Dictionary<string, object>{
                            {ColDef.DIRECTORY_PATH, dataRow[ColDef.DIRECTORY_PATH]},
                            {ColDef.VIDEO_FILE_NAME, dataRow[ColDef.VIDEO_FILE_NAME]}
                        };

                    switch (procStatue)
                    {
                        case "": //已無此檔案，刪除！
                                 //從資料庫刪除
                            ravmDBUtil.Delete("FILE_INFO", whereColumn, conn, trns);
                            //從 DataTable 刪除
                            dataRow.Delete();
                            break;

                        case "U":
                            //更新資料
                            var updateColumn = new Dictionary<string, object>{
                                    {ColDef.COVER_FILE_NAME, dataRow[ColDef.COVER_FILE_NAME]}
                                };
                            ravmDBUtil.Update("FILE_INFO", updateColumn, whereColumn, conn, trns);
                            break;

                        case "I":
                            //新增資料
                            var insertColumn = new Dictionary<string, object>{
                                    {ColDef.DIRECTORY_PATH, dataRow[ColDef.DIRECTORY_PATH]},
                                    {ColDef.VIDEO_FILE_NAME, dataRow[ColDef.VIDEO_FILE_NAME]},
                                    {ColDef.COVER_FILE_NAME, dataRow[ColDef.COVER_FILE_NAME]}
                                };
                            ravmDBUtil.Insert("FILE_INFO", insertColumn, conn, trns);
                            break;
                    }
                }
                trns.Commit();
            }
            catch (Exception ex)
            {
                trns?.Rollback();
                throw new Exception(ex.Message + "\r\n\r\n" + ex.StackTrace);
            }
            finally
            {
                conn?.Close();
                conn?.Dispose();
                conn = null;
                trns?.Dispose();
                trns = null;
            }
        }
    }
}