using RrAvManager.util.def;
using System;
using System.Drawing;
using System.Net;

namespace RrAvManager.util
{
    internal class ImageWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            var w = base.GetWebRequest(uri);
            w.Timeout = EvnDef.IMAGE_DOWNLOAD_TIMEOUT * 1000;
            return w;
        }

        /// <summary>
        ///     載圖檔
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Image DownloadImage(string url)
        {
            try
            {
                using (var myWebClient = new ImageWebClient())
                {
                    return CommUtil.BufferToImage(myWebClient.DownloadData(new Uri(url)));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("下載圖檔失敗:" + url + "\n" + ex.StackTrace);
            }
        }
    }
}