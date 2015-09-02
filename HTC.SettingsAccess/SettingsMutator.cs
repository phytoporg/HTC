using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTC
{
    namespace SettingsAccess
    {
        public class SettingsMutator
        {
            private KeyValueConfigurationCollection _keyValueConfigCollection;
            private Configuration _config;
            public SettingsMutator(Configuration config)
            {
                _config = config;
                _keyValueConfigCollection = config.AppSettings.Settings;
            }

            public void SetConfigValue(string value, string key)
            {
                _config.AppSettings.Settings.Add(
                    new KeyValueConfigurationElement(value, key)
                    );
            }

            public bool CommitChanges()
            {
                if (_config.GetSection("appSettings").SectionInformation.IsLocked)
                {
                    return false;
                }
                else
                {
                    _config.Save();
                    return true;
                }
            }
        }
    }
}
