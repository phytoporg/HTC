using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTC
{
    namespace YouTube
    {
        public class YouTubeVideoMetadata
        {
            public readonly string Name;
            public readonly string Url;

            public YouTubeVideoMetadata(string name, string url)
            {
                Name = name;
                Url = url;
            }
        }
    }
}
