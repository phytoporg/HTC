using System.Configuration;
using System.Linq;

namespace HTC
{
    namespace SettingsAccess
    {
        public class SettingsAccessor
        {
            private readonly KeyValueConfigurationCollection _keyValueConfigCollection;
            public SettingsAccessor(Configuration config)
            {
                _keyValueConfigCollection = config.AppSettings.Settings;
            }

            public bool GetConfigValue(string key, out string value)
            {
                value = string.Empty;
                if (!_keyValueConfigCollection.AllKeys.Contains(key))
                {
                    return false;
                }
                else
                {
                    value = _keyValueConfigCollection[key].Value;
                    return true;
                }
            }
        }
    }
}
