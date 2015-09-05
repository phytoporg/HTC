using System.Collections.Generic;
using Google.Apis.Discovery;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace HTC
{
    namespace YouTube
    {
        public class YouTubeClient
        {
            private const string DeveloperKey = "AIzaSyB9xVtrdR5jXev0U0VV7y-pFWbTkezA7U8";
            private const string ApplicationName = "FightTableHTC";
            private const string ServiceName = "youtube";
            private const string ApiVersion = "v3";

            static YouTubeService _service = null;

            public YouTubeClient()
            {
                if (_service == null)
                {
                    _service = new YouTubeService(new BaseClientService.Initializer()
                    {
                        ApiKey = DeveloperKey,
                        ApplicationName = ApplicationName
                    });
                }
            }

            public List<YouTubeVideoMetadata> SearchForVideos(string queryString)
            {
                var searchListRequest = _service.Search.List("snippet");
                searchListRequest.Q = queryString;
                searchListRequest.MaxResults = 50;

                var searchListResponse = searchListRequest.Execute();
                var results = new List<YouTubeVideoMetadata>();
                foreach (var searchResult in searchListResponse.Items)
                {
                    if (searchResult.Id.Kind != "youtube#video")
                    {
                        continue;
                    }

                    var videoMetadata = new YouTubeVideoMetadata(
                        name: searchResult.Snippet.Title,
                        id: searchResult.Id.VideoId
                        );
                    results.Add(videoMetadata);
                }

                return results;
            }
        }
    }
}
