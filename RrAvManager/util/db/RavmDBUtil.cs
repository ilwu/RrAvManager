using rbt.util.db.sqlite;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace RrAvManager.util.db
{
    internal class RavmDBUtil : SqlLiteDBUtil
    {
        /// <summary>
        /// 資料檔案路徑
        /// </summary>
        private readonly string _dataBasePath;

        public RavmDBUtil(string dataBasePath)
        {
            _dataBasePath = dataBasePath;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected override DbConnection GetConnection()
        {
            return GetSQLiteConnection();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection GetSQLiteConnection()
        {
            // =================================================
            // 檢查檔案是否存在
            // =================================================
            if (!File.Exists(_dataBasePath))
            {
                SQLiteConnection.CreateFile(_dataBasePath);
            }
            return new SQLiteConnection("Data Source = " + _dataBasePath);
        }

        private void initSchames()
        {
        }
    }
}