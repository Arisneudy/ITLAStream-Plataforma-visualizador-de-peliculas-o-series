using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public class ConverterVideo
    {

        public static string Convertir(string videoLink)
        {
            if (videoLink.Contains("youtu.be"))
            {
                videoLink = videoLink.Replace("youtu.be/", "www.youtube.com/embed/");
                int index = videoLink.IndexOf('?');
                if (index != -1)
                {
                    videoLink = videoLink.Substring(0, index);
                }

                return videoLink;
            }
            else if (videoLink.Contains("youtube.com/watch"))
            {
                var uri = new Uri(videoLink);
                var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
                var videoId = query["v"];
                if (!string.IsNullOrEmpty(videoId))
                {
                    videoLink = $"https://www.youtube.com/embed/{videoId}";
                }
            }

            return videoLink;
        }
    }
}
