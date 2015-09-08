using System.Windows.Controls;

using System.Diagnostics;

namespace HTC
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    { 

        private Frame _downloadTabFrame = null;
        private Frame _optionsTabFrame = null;

        void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tabControl = sender as TabControl;
            if (tabControl != null)
            {
                var selectedItem = tabControl.SelectedItem as TabItem;
                Debug.WriteLine(selectedItem.Name);

                if (selectedItem == DownloadTab)
                {
                    if (_downloadTabFrame == null) {
                        _downloadTabFrame = new Frame();
                        var downloadPage = new DownloadPage();
                        _downloadTabFrame.Content = downloadPage;
                    }

                    selectedItem.Content = _downloadTabFrame;
                }
                else if (selectedItem == OptionsTab)
                {
                    if (_optionsTabFrame == null)
                    {
                        _optionsTabFrame = new Frame();
                        var optionsPage = new OptionsPage();
                        _optionsTabFrame.Content = optionsPage;
                    }

                    selectedItem.Content = _optionsTabFrame;
                }
            }
        }

        public HomePage()
        {
            InitializeComponent();
        }
    }
}
