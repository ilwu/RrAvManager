using System.Drawing;

namespace RrAvManager.parser
{
    /// <summary>
    /// 存放解析資料的容器
    /// </summary>
    internal class VideoInfo
    {
        /// <summary>
        /// 片名
        /// </summary>
        public string NAME;

        /// <summary>
        /// 品番
        /// </summary>
        public string SNO;

        /// <summary>
        /// 發售日
        /// </summary>
        public string RELEASE_DATE;

        /// <summary>
        /// 片長
        /// </summary>
        public string LENGTH;

        /// <summary>
        /// 製作商
        /// </summary>
        public string MAKER;

        /// <summary>
        /// 發行者
        /// </summary>
        public string ISSUER;

        /// <summary>
        /// 說明
        /// </summary>
        public string INTRO;

        /// <summary>
        /// 演員
        /// </summary>
        public string ACTOR;

        /// <summary>
        /// 導演
        /// </summary>
        public string DIRECTOR;

        /// <summary>
        /// COVER
        /// </summary>
        public Image COVER;
    }
}