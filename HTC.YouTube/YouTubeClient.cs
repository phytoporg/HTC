using System.Collections.Generic;
using System.Linq;

using Google.GData.YouTube;
using Google.YouTube;

namespace HTC
{
    namespace YouTube
    {
        public class YouTubeClient
        {
            private const string DeveloperKey = "AIzaSyCYpM-4IxQGIa5SGHSG3qd-KLJY-t85lW0";
            private const string ServiceName = "youtube";
            private const string ApiVersion = "v3";

            static YouTubeRequest _request = null;

            public YouTubeClient()
            {
                if (_request == null)
                {
                    var settings = new YouTubeRequestSettings("HTC", DeveloperKey);
                    _request = new YouTubeRequest(settings);
                }
            }

            List<YouTubeVideoMetadata> SearchForVideos(string queryString)
            {
                var query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);
                query.Query = queryString;
                query.SafeSearch = YouTubeQuery.SafeSearchValues.None;

                var videoFeed = _request.Get<Video>(query);
                var listOfResults = new List<YouTubeVideoMetadata>(videoFeed.Entries.Count());
                foreach (var video in videoFeed.Entries)
                {
                    var videoMetadata = new YouTubeVideoMetadata(
                        name: video.Title,
                        url: video.WatchPage.AbsoluteUri
                        );
                }
                return null;
            }
        }
    }
}
