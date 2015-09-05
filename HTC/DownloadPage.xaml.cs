using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Collections.Generic;

namespace HTC
{
    /// <summary>
    /// Interaction logic for DownloadPage.xaml
    /// </summary>
    public partial class DownloadPage : Page
    {
        public DownloadPage()
        {
            InitializeComponent();

            FillListViewWithDummyData();
        }

        private partial class YouTubeSearchResult
        {
            public string Name { get; set; }
            public string URL { get; set; }
        }

        void FillListViewWithDummyData()
        {
            var results = new List<YouTubeSearchResult>();
            results.Add(new YouTubeSearchResult() { Name = "Sunshine and Celery Stalks", URL = @"https://www.youtube.com/watch?v=cP0f5rvVkAU&index=30&list=RDMMNvVena0EY28" });
            results.Add(new YouTubeSearchResult() { Name = "Funny Little Frog", URL = @"https://www.youtube.com/watch?v=lvS902DLEVI&index=27&list=RDMMNvVena0EY28" });
            results.Add(new YouTubeSearchResult() { Name = "Tales of Symphonia Music - Fighting of the Spirits", URL = @"https://www.youtube.com/watch?v=25-BEGZCc0U&list=RDMMNvVena0EY28&index=27" });
            SearchResults.ItemsSource = results;
        }

        public void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            Debug.Assert(textBox != null);

            textBox.Text = string.Empty;
        }
    }
}
