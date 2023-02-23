﻿using System;
using System.Collections.Generic;
using System.Configuration;
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

        //public object this[string key]
        //{
        //    get { return Current.Get(key); }
        //    set { Current.Set(key, value); }
        //}

        readonly private Properties.Settings _settings;

        readonly private List<string> _keys = new List<string>();

        readonly private Dictionary<string, Type> _types = new();

        private SettingsManager() 
        {
            _settings = Properties.Settings.Default;

            _keys.Add(SettingKeys.AutoCheckMaxDepth);
            _keys.Add(SettingKeys.DotDirAllowed);
            _keys.Add(SettingKeys.ReadmeEnabled);
            _keys.Add(SettingKeys.AutoCheckEnabled);

            _keys.Add(SettingKeys.IgnoreDirs);
            _keys.Add(SettingKeys.IgnoreFiles);

            foreach(SettingsProperty prop in _settings.Properties)
            {
                // Store property types
                string keyProp = prop.Name;
                Type typeProp = prop.PropertyType;

                // Check key is in keys (Known key?)
                if (!_keys.Contains(keyProp)) throw new NotSupportedException("Unknown property key is given.");

                // Add prop type
                _types.Add(keyProp, typeProp);

            }

        }

        private object Get(string key)
        {
            if (!_keys.Contains(key)) throw new ArgumentException("Unlisted key is given");

            return _settings[key];
        }

        public T Get<T>(string key)
        {
            if (typeof(T) != _types[key]) throw new InvalidCastException("Type mismatch.");

            object obj = Get(key);

            return (T)obj;
        }

        //private void Set(string key, object value)
        //{
        //    _settings[key] = value;
        //}

        public void Set<T>(string key, T value)
        {
            if (typeof(T) != _types[key]) throw new InvalidCastException("Type mismatch.");

            _settings[key] = value;
        }


        //
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