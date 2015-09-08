namespace HTC
{
    namespace YouTube
    {
        public class YouTubeVideoMetadata
        {
            public string Name { get; set; }
            public string Url {
                get
                {
                    return string.Format(@"http://youtube.com/watch?v={0}", Id);
                }
            }

            public string Id { get; set; }

            public YouTubeVideoMetadata(string name, string id)
            {
                Name = name;
                Id = id;
            }
        }
    }
}
