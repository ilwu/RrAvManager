using HtmlAgilityPack;
using Newtonsoft.Json;
using rbt.util;
using RrAvManager.util.def;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RrAvManager.util
{
    /// <summary>
    ///     共用方法
    /// </summary>
    internal class CommUtil
    {
        /// <summary>
        /// </summary>
        private readonly Dictionary<Button, Button> ButtonProcessDic = new Dictionary<Button, Button>();

        /// <summary>
        ///     瞄路徑下所有的檔案
        /// </summary>
        /// <param name="RrAvManager">開始掃瞄的起始路徑</param>
        /// <returns></returns>
        public static IEnumerable<string> getAllAccesibleFiles(string RrAvManager)
        {
            var RV = new List<string>();
            var directories = default(IEnumerable<string>);
            directories = Directory.EnumerateDirectories(RrAvManager);

            foreach (var directory in directories)
            {
                try
                {
                    RV.AddRange(Directory.EnumerateFiles(directory));
                    RV.AddRange(getAllAccesibleFiles(directory));
                }
                catch (Exception ex)
                {
                    ////exception 訊息放到 debug textbox
                    //mainForm.txtDebug.Text = ex.StackTrace;
                    ////tab 焦點移到 debug tab
                    //tabControl1.SelectTab(tabPageDebug);
                }
            }

            return RV;
        }

        /// <summary>
        ///     讀取圖檔，並傳回 byte[]
        /// </summary>
        /// <param name="imagePath">圖檔路徑</param>
        /// <param name="width">選項：回傳圖形寬度</param>
        /// <param name="height">選項：回傳圖形高度</param>
        /// <returns></returns>
        public static byte[] GetBytesFromImagePath(string imagePath, int width = 0, int height = 0)
        {
            if (!File.Exists(imagePath))
            {
                return null;
            }

            using (var ms = new MemoryStream())
            {
                var img = Image.FromFile(imagePath);

                //改變大小
                if (width > 0 && height > 0)
                {
                    img = ResizeImage(img, width, height);
                }

                img.Save(ms, ImageFormat.Bmp);
                return ms.GetBuffer();
            }
        }

        /// <summary>
        ///     改變圖形大小
        /// </summary>
        /// <param name="img">Image</param>
        /// <param name="width">寬</param>
        /// <param name="height">高</param>
        /// <returns></returns>
        public static Image ResizeImage(Image img, int width, int height)
        {
            var b = new Bitmap(width, height);
            using (var g = Graphics.FromImage(b))
            {
                g.DrawImage(img, 0, 0, width, height);
            }

            return b;
        }

        /// <summary>
        ///     將 Byte 陣列轉換為 Image。
        /// </summary>
        /// <param name="Buffer">Byte 陣列。</param>
        public static Image BufferToImage(byte[] Buffer)
        {
            if (Buffer == null || Buffer.Length == 0)
            {
                return null;
            }
            //建立副本

            using (var oMemoryStream = new MemoryStream(Buffer) { Position = 0 })
            {
                //設定資料流位置
                var oImage = Image.FromStream(oMemoryStream);
                //建立副本
                return new Bitmap(oImage);
            }
        }

        /// <summary>
        ///     將 HtmlNodeCollection html 內容列印出來
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static string GetNodesContent(HtmlNodeCollection nodes)
        {
            var sb = new StringBuilder();
            foreach (var node in nodes)
            {
                sb.Append(node.InnerHtml.Trim() + "\n");
            }
            return sb.ToString();
        }

        /// <summary>
        ///     檢核 node 下是否含有指定的元素
        /// </summary>
        /// <param name="node">目標 HtmlNode</param>
        /// <param name="name">Html 元素名稱</param>
        /// <returns></returns>
        public static bool hasChildNodesByName(HtmlNode node, string name)
        {
            foreach (var childNode in node.ChildNodes)
            {
                if (name.Equals(StringUtil.SafeTrim(childNode.Name)))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     取得 node 下第一個指定類型的 Node
        /// </summary>
        /// <param name="node">目標 HtmlNode</param>
        /// <param name="name">Html 元素名稱</param>
        /// <returns></returns>
        public static HtmlNode GetFirstChildNodesByName(HtmlNode node, string name)
        {
            foreach (var childNode in node.ChildNodes)
            {
                if (name.Equals(StringUtil.SafeTrim(childNode.Name)))
                {
                    return childNode;
                }
            }
            return null;
        }

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string HmlToText(string context)
        {
            context = StringUtil.SafeTrim(context);
            context = context.Replace("&nbsp;", "");
            return context;
        }

        /// <summary>
        /// </summary>
        /// <param name="windowFrForm"></param>
        /// <param name="windowX"></param>
        /// <param name="windowY"></param>
        public static void SetWindowDesktopLocation(Form windowFrForm, int windowX, int windowY)
        {
            if (windowY + windowFrForm.Size.Height > SystemInformation.VirtualScreen.Height - 20)
            {
                windowY = SystemInformation.VirtualScreen.Height - 20 - windowFrForm.Size.Height;
            }

            windowFrForm.DesktopLocation = new Point(windowX + EvnDef.mouseLeftSize, windowY + EvnDef.mouseLeftSize);
        }

        /// <summary>
        /// </summary>
        /// <param name="processForm"></param>
        /// <param name="btn"></param>
        /// <param name="message"></param>
        public void ProcessBtnLockStart(Form processForm, Button btn, string message = "處理中")
        {
            //鎖定觸發的 btn
            ButtonProcessStart(btn, message);

            //鎖定其他button
            //取得所有按鈕
            var bnnList = BaseUtil_FindControsByType(typeof(Button), processForm);

            foreach (var cuttBtn in bnnList)
            {
                //遇到觸發按鈕則跳過
                if (cuttBtn.Equals(btn))
                {
                    continue;
                }
                //鎖定其他按鈕
                ButtonProcessStart((Button)cuttBtn, message);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="processForm"></param>
        public void ProcessBtnLockEnd(Form processForm)
        {
            //取得所有按鈕
            var bnnList = BaseUtil_FindControsByType(typeof(Button), processForm);

            //還原所有狀態
            foreach (var cuttBtn in bnnList)
            {
                ButtonProcessEnd((Button)cuttBtn);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="message"></param>
        public void ButtonProcessStart(Button btn, string message = "")
        {
            //記錄原始 button 狀態
            if (!ButtonProcessDic.ContainsKey(btn))
            {
                var orgBtn = new Button
                {
                    Text = btn.Text,
                    Enabled = btn.Enabled
                };
                ButtonProcessDic.Add(btn, orgBtn);
            }

            btn.Enabled = false;

            if (message != "")
            {
                btn.Text = message;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="btn"></param>
        public void ButtonProcessEnd(Button btn)
        {
            if (ButtonProcessDic.ContainsKey(btn))
            {
                var orgBtn = ButtonProcessDic[btn];
                btn.Text = orgBtn.Text;
                btn.Enabled = orgBtn.Enabled;
            }
        }

        /// <summary>
        ///     依據 type 取得畫面上的 control
        /// </summary>
        /// <param name="controlType"></param>
        /// <param name="parentContol"></param>
        /// <param name="resultControls"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected List<Control> BaseUtil_FindControsByType(Type controlType, Control parentContol,
            List<Control> resultControls = null)
        {
            if (resultControls == null)
            {
                resultControls = new List<Control>();
            }

            foreach (Control control in parentContol.Controls)
            {
                //System.Diagnostics.Debug.WriteLine(control.ID & ":" & control.GetType().ToString())

                if (control.HasChildren)
                {
                    BaseUtil_FindControsByType(controlType, control, resultControls);
                }

                if (ReferenceEquals(control.GetType(), controlType))
                {
                    resultControls.Add(control);
                }
            }

            return resultControls;
        }

        /// <summary>
        ///     取得畫面上的 control
        /// </summary>
        /// <param name="parentContol"></param>
        /// <param name="resultControls"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected List<Control> BaseUtil_FindAllContros(Control parentContol, List<Control> resultControls = null)
        {
            if (resultControls == null)
            {
                resultControls = new List<Control>();
            }

            foreach (Control control in parentContol.Controls)
            {
                if (control.HasChildren)
                {
                    BaseUtil_FindAllContros(control, resultControls);
                }

                resultControls.Add(control);
            }

            return resultControls;
        }

        //================================================================
        // Json
        //================================================================

        /// <summary>
        ///     將物件放入暫存區
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        /// <remarks></remarks>
        protected void BaseUtil_SaveObjectToFile(object obj, string fileName)
        {
            //寫入檔案
            var jsonText = JsonConvert.SerializeObject(obj);
            using (var sw = File.CreateText(fileName))
            {
                sw.Write(jsonText);
                sw.Close();
            }
        }

        /// <summary>
        ///     將物件由暫存區取回
        /// </summary>
        /// <param name="setName"></param>
        /// <param name="type"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected object BaseUtil_GetObjectFromFile(string setName, Type type, string fileName)
        {
            //讀取 Server 中的 Json檔案
            if (!File.Exists(fileName))
            {
                return null;
            }
            //讀取
            var jsonText = new StringBuilder();
            using (var sr = File.OpenText(fileName))
            {
                string input = null;
                input = sr.ReadLine();
                jsonText.Append(input);
                while (input != null)
                {
                    input = sr.ReadLine();
                    jsonText.Append(input);
                }
                sr.Close();
            }

            return JsonConvert.DeserializeObject(jsonText.ToString(), type);
        }

        /// <summary>
        ///     將 DataTable  轉為 JSON String (為零行時, 會自動保留結構, 需和 BaseUtil_JSON2DataTable 配合使用)
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected string BaseUtil_DataTable2JSON(DataTable dataTable)
        {
            if (dataTable.Rows.Count == 0)
            {
                dataTable.Columns.Add("_BaseUtilStructureKeep");
                dataTable.AcceptChanges();
                var structureRow = dataTable.NewRow();
                structureRow["_BaseUtilStructureKeep"] = "Y";
                dataTable.Rows.Add(structureRow);
            }
            return JsonConvert.SerializeObject(dataTable);
        }

        /// <summary>
        ///     將 JSON String 轉為 DataTable
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <remarks></remarks>
        protected DataTable BaseUtil_JSON2DataTable(string jsonStr)
        {
            //由 JSON 字串轉回 DataSet
            var dataTable = (DataTable)JsonConvert.DeserializeObject(jsonStr, new DataTable().GetType());

            //清除結構保留行
            if (dataTable.Columns.Contains("_BaseUtilStructureKeep"))
            {
                var rows = dataTable.Select("_BaseUtilStructureKeep='Y'");
                if (rows.Length > 0)
                {
                    rows[0].Delete();
                }
                dataTable.Columns.Remove("_BaseUtilStructureKeep");
                dataTable.AcceptChanges();
            }

            //將 null 轉回空白
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (row[column] == null)
                    {
                        row[column] = "";
                    }
                }
            }
            dataTable.AcceptChanges();
            return dataTable;
        }
    }
}