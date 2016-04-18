namespace RrAvManager.util.def
{
    /// <summary>
    ///     環境常數
    /// </summary>
    internal class EvnDef
    {
        /// <summary>
        ///     資料庫網址 : www.javlibrary.com
        /// </summary>
        public const string LIBURL_JAVLIBRARY = "http://www.javlibrary.com/tw/vl_searchbyid.php?&keyword=";

        /// <summary>
        ///     圖檔下載 Timeout 時間
        /// </summary>
        public const int IMAGE_DOWNLOAD_TIMEOUT = 5;

        //====================================================
        //ShowImageForm
        //====================================================

        public const int mouseLeftSize = 4;
        public const int showWidth = 900;
        public const int showHeight = 600;
        public const int zoomInOutSize = 40;

        //====================================================
        //
        //====================================================
        /// <summary>
        ///     影片附檔名
        /// </summary>
        public static readonly string[] VIDEO_TYPE = { ".mkv", ".avi", ".mp4", ".rmvb", ".wmv" };

        /// <summary>
        ///     圖片附檔名
        /// </summary>
        public static readonly string[] PIC_TYPE = { ".jpg", ".jpeg", ".bmp", ".gif" };
    }
}