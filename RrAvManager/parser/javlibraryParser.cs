using HtmlAgilityPack;
using rbt.util.exception;
using RrAvManager.util;
using RrAvManager.util.def;
using RrAvManager.util.exception;
using System.Drawing;
using System.Web;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace RrAvManager.parser
{
    internal class JavlibraryParser
    {
        public VideoInfo parseJavlibrary(string searchSno)
        {
            HtmlWeb webClient = new HtmlWeb();

            //取得搜尋網址 javlibrary
            string url = EvnDef.LIBURL_JAVLIBRARY + HttpUtility.UrlEncode(searchSno.Trim());

            //取回網頁
            HtmlDocument doc = webClient.Load(url);

            //節點 node
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[3]/div[2]/div[2]/table[1]");

            if (nodes == null)
            {
                throw new MessageException("找不到資料!");
            }

            VideoInfo videoInfo = parseJavlibrarySingle(doc.DocumentNode);

            doc = null;
            nodes = null;
            webClient = null;

            return videoInfo;
        }

        /// <summary>
        /// 解析 Javlibrary 單片資料
        /// </summary>
        private VideoInfo parseJavlibrarySingle(HtmlNode javlibContentNode)
        {
            //=================================================
            //建立資料容器
            //=================================================
            VideoInfo videoInfo = new VideoInfo();

            //=================================================
            //影像 (ps:xpath 又從 root 開始計算)
            //=================================================
            HtmlNodeCollection nodes = javlibContentNode.SelectNodes("/html[1]/body[1]/div[3]/div[2]/div[2]/table[1]/tr[1]/td[1]/div[1]/img[1]");

            if (nodes == null)
            {
                throw new HtmlPathErrorException("影像:/html[1]/body[1]/div[3]/div[2]/div[2]/table[1]/tr[1]/td[1]/div[1]/img[1]\n" + javlibContentNode.InnerHtml.Trim());
            }
            Image imgCover = ImageWebClient.DownloadImage(nodes[0].Attributes["src"].Value);
            if (imgCover != null)
            {
                videoInfo.COVER = CommUtil.ResizeImage(imgCover, 600, 400);
            }

            //=================================================
            //其他欄位
            //=================================================
            //video_info 下面所有的 div
            var divNodesVideoInfo = javlibContentNode.SelectNodes("/html[1]/body[1]/div[3]/div[2]/div[2]/table[1]/tr[1]/td[2]/div[1]/div");
            if (divNodesVideoInfo == null)
            {
                throw new HtmlPathErrorException("影片資訊:/html[1]/body[1]/div[3]/div[2]/div[2]/table[1]/tr[1]/td[2]/div[1]/div\n" + javlibContentNode.InnerHtml.Trim());
            }

            //取得內容
            for (int i = 0; i < divNodesVideoInfo.Count; i++)
            {
                //取得 td層
                var tdNodes = javlibContentNode.SelectNodes("/html[1]/body[1]/div[3]/div[2]/div[2]/table[1]/tr[1]/td[2]/div[1]/div[" + (i + 1) + "]/table/tr/td[2]");
                if (tdNodes == null) continue;

                //取得內容 (td 層有多個. 判斷 class 為 text)
                string context = tdNodes[0].InnerText.Replace("&nbsp;", "").Trim();

                switch (divNodesVideoInfo[i].Id)
                {
                    case "video_id": //品番
                        videoInfo.SNO = context;
                        break;

                    case "video_date"://發售日
                        videoInfo.RELEASE_DATE = context;
                        break;

                    case "video_length"://片長
                        videoInfo.LENGTH = context;
                        break;

                    case "video_director": //導演
                        //txtVdoInfoSno.Text = context;
                        break;

                    case "video_maker"://製作商
                        videoInfo.MAKER = context;
                        break;

                    case "video_label"://發行商
                        videoInfo.ISSUER = context;
                        break;

                    case "video_genres"://類別

                        var spanNodes = javlibContentNode.SelectNodes("/html[1]/body[1]/div[3]/div[2]/div[2]/table[1]/tr[1]/td[2]/div[1]/div[" + (i + 1) + "]/table/tr/td[2]/span");
                        context = "";
                        foreach (var spanNode in spanNodes)
                        {
                            context += "、" + CommUtil.HmlToText(spanNode.InnerText);
                        }
                        if (context.Length > 0)
                        {
                            context = context.Substring(1);
                        }
                        videoInfo.INTRO = context;
                        break;

                    case "video_cast"://演員
                        videoInfo.ACTOR = context;
                        break;
                }

                //=================================================
                //片名
                //=================================================
                nodes = javlibContentNode.SelectNodes("/html[1]/body[1]/div[3]/div[2]/div[1]/h3[1]/a[1]");
                if (nodes != null)
                {
                    //將品番取代掉
                    videoInfo.NAME = CommUtil.HmlToText(nodes[0].InnerText).Replace(videoInfo.SNO, "");
                }
                else
                {
                    throw new HtmlPathErrorException("片名:/html[1]/body[1]/div[3]/div[2]/div[1]/h3[1]/a[1]\n" + javlibContentNode.InnerHtml.Trim());
                }
            }

            return videoInfo;
        }
    }
}