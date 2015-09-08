using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.IO;

using HTC.SettingsAccess;

namespace HTC
{
    /// <summary>
    /// Interaction logic for OptionsPage.xaml
    /// </summary>
    public partial class OptionsPage : Page
    {
        public OptionsPage()
        {
            InitializeComponent();
        }

        private string SelectWorkingDirectory()
        {
            //
            // Check app config for working local directory path
            // If it doesn't exist or the retrieved directory is invalid, subject user
            // to select the working directory.
            //
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            while (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK);

            return dialog.SelectedPath;
        }

        void BrowseButton_Clicked(object sender, RoutedEventArgs e)
        {
            WorkingDirectoryText.Text = SelectWorkingDirectory();
        }

        void SaveButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(WorkingDirectoryText.Text))
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var mutator = new SettingsMutator(config);

                mutator.SetConfigValue(ConfigurationValues.WorkingDirectory, WorkingDirectoryText.Text);
            }
            else
            {
                WorkingDirectoryText.Text = "Directory does not exist";
            }
        }
         
        void BrowseText_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.Text = string.Empty;
            }
        }
    }
}
