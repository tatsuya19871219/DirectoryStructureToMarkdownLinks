using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryStructureToMarkdownLinks
{
    static class SettingKeys
    {
        public static string AutoCheckMaxDepth = "AutoCheckMaxDepth";
        public static string DotDirAllowed = "DotDirExpandAllowed";
        public static string ReadmeEnabled = "ReadmeNotificationEnabled";
        public static string AutoCheckEnabled = "AutoCheckInOpen";
        public static string IgnoreDirs = "IgnoreDirs";
        public static string IgnoreFiles = "IgnoreFiles";
    }

    internal class SettingsManager
    {

        private static SettingsManager _instance = null;
        public static SettingsManager Current 
        {
            get
            {
                if (_instance == null) 
                    _instance = new SettingsManager();

                return _instance;
            }
        }

        public object this[string key]
        {
            get { return Current.Get(key); }
            set { Current.Set(key, value); }
        }

        readonly private Properties.Settings _settings;

        readonly private List<string> _keys = new List<string>();

        

        private SettingsManager() 
        {
            _settings = Properties.Settings.Default;

            _keys.Add(SettingKeys.AutoCheckMaxDepth);
            _keys.Add(SettingKeys.DotDirAllowed);
            _keys.Add(SettingKeys.ReadmeEnabled);
            _keys.Add(SettingKeys.AutoCheckEnabled);

            _keys.Add(SettingKeys.IgnoreDirs);
            _keys.Add(SettingKeys.IgnoreFiles);
        }

        private object Get(string key)
        {
            if (!_keys.Contains(key)) throw new ArgumentException("Unlisted key is given");

            return _settings[key];
        }

        private void Set(string key, object value)
        {
            _settings[key] = value;
        }

        public void Save()
        {
            _settings.Save();
        }

        public void Reset()
        {
            _settings.Reset();
        }
    }
}
