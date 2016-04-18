using RrAvManager.util.def;
using System.Data;

namespace RrAvManager.util
{
    /// <summary>
    /// </summary>
    internal class SubFunction
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static DataTable GetMainListEmptyDataTable(DataTable dataTable)
        {
            if (dataTable == null)
            {
                dataTable = new DataTable();
            }

            //目錄路徑
            if (!dataTable.Columns.Contains(ColDef.DIRECTORY_PATH))
                dataTable.Columns.Add(ColDef.DIRECTORY_PATH);
            //影片檔案名稱
            if (!dataTable.Columns.Contains(ColDef.VIDEO_FILE_NAME))
                dataTable.Columns.Add(ColDef.VIDEO_FILE_NAME);
            //封面影像檔
            if (!dataTable.Columns.Contains(ColDef.COVER_IMAGE))
                dataTable.Columns.Add(new DataColumn(ColDef.COVER_IMAGE, typeof(byte[])));
            //封面檔案名稱
            if (!dataTable.Columns.Contains(ColDef.COVER_FILE_NAME))
                dataTable.Columns.Add(ColDef.COVER_FILE_NAME);
            //品番
            if (!dataTable.Columns.Contains(ColDef.SNO))
                dataTable.Columns.Add(ColDef.SNO);
            //INDEX
            if (!dataTable.Columns.Contains(ColDef.INDEX))
                dataTable.Columns.Add(ColDef.INDEX);
            //PROCESS_STATUS
            if (!dataTable.Columns.Contains(ColDef.PROCESS_STATUS))
                dataTable.Columns.Add(ColDef.PROCESS_STATUS);

            dataTable.AcceptChanges();

            return dataTable;
        }
    }
}