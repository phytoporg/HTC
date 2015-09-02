using System.Configuration;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;

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
                var dialog = new FolderBrowserDialog();
                while (dialog.ShowDialog() != DialogResult.OK);

                var sm = new SettingsMutator(config);
                sm.SetConfigValue(ConfigurationValues.WorkingDirectory, dialog.SelectedPath);
                sm.CommitChanges();
            }

            //
            // Do other stuff.
            //
        }

        public HomePage()
        {
            InitializeComponent();
            MaybeSelectWorkingDirectory();
        }
    }
}
