using System.Configuration;
using System.IO;
using System.Windows.Controls;

using System.Diagnostics;

using HTC.SettingsAccess;

namespace HTC
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    { 
        private void MaybeSelectWorkingDirectory()
        {
            //
            // Check app config for working local directory path
            // If it doesn't exist or the retrieved directory is invalid, subject user
            // to select the working directory.
            //
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var sa = new SettingsAccessor(config);
            string workingDirPath = string.Empty;
            if (!sa.GetConfigValue(ConfigurationValues.WorkingDirectory, out workingDirPath) || 
                !Directory.Exists(workingDirPath))
            {
                /* This is annoying while debugging... add this later when it's actually required.
                var dialog = new System.Windows.Forms.FolderBrowserDialog();
                while (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK);

                var sm = new SettingsMutator(config);
                sm.SetConfigValue(ConfigurationValues.WorkingDirectory, dialog.SelectedPath);
                sm.CommitChanges();
                */
            }

            //
            // Do other stuff.
            //
        }

        private Frame _downloadTabFrame = null;

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
            }
        }

        public HomePage()
        {
            InitializeComponent();
            MaybeSelectWorkingDirectory();
        }
    }
}
