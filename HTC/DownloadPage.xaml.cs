using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Collections.Generic;

using HTC.YouTube;

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
        }

        public void SearchButton_Clicked(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                throw new System.Exception("Expected a button!");
            }

            //
            // Don't bother to conduct a search if the query is empty.
            //
            var queryText = QueryText.Text;
            if (queryText != string.Empty)
            {
                var client = new YouTubeClient();
                var results = client.SearchForVideos(queryText);

                SearchResults.ItemsSource = results;
            }
        }

        public void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            Debug.Assert(textBox != null);

            textBox.Text = string.Empty;
        }
    }
}
