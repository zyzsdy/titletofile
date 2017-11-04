using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteToFile
{
    public class Config
    {
        private const string regKeyPath = "SOFTWARE\\writetofile";

        private string isWriteTime = "False";
        private string timeFormatString;
        private string timeSaveLocation;
        private string titlePrefix;
        private string titleSuffix;
        private string titleSaveLocation;

        public bool IsWriteTime
        {
            get
            {
                return isWriteTime == "True";
            }
            set
            {
                Write("isWriteTime", value ? "True" : "False");
                isWriteTime = value ? "True" : "False";
            }
        }
        public string TimeFormatString
        {
            get
            {
                return timeFormatString;
            }
            set
            {
                Write("timeFormatString", value);
                timeFormatString = value;
            }
        }
        public string TimeSaveLocation
        {
            get
            {
                return timeSaveLocation;
            }
            set
            {
                Write("timeSaveLocation", value);
                timeSaveLocation = value;
            }
        }

        public string TitleSuffix
        {
            get
            {
                return titleSuffix;
            }
            set
            {
                Write("titleSuffix", value);
                titleSuffix = value;
            }
        }

        public string TitlePrefix
        {
            get
            {
                return titlePrefix;
            }
            set
            {
                Write("titlePrefix", value);
                titlePrefix = value;
            }
        }

        public string TitleSaveLocation
        {
            get
            {
                return titleSaveLocation;
            }
            set
            {
                Write("titleSaveLocation", value);
                titleSaveLocation = value;
            }
        }

        public Config()
        {
            Init();
        }
        private void Init()
        {
            var hkcu = Registry.CurrentUser;
            Debug.Assert(hkcu != null, "hkcu != null");
            hkcu.CreateSubKey(regKeyPath);
            var regKey = hkcu.OpenSubKey(regKeyPath);
            Debug.Assert(regKey != null, "regKey != null");
            var subkeyNames = regKey.GetValueNames();

            foreach (var keyName in subkeyNames)
            {
                switch (keyName)
                {
                    case "isWriteTime":
                        isWriteTime = regKey.GetValue("isWriteTime").ToString();
                        break;
                    case "timeFormatString":
                        timeFormatString = regKey.GetValue("timeFormatString").ToString();
                        break;
                    case "timeSaveLocation":
                        timeSaveLocation = regKey.GetValue("timeSaveLocation").ToString();
                        break;
                    case "titlePrefix":
                        titlePrefix = regKey.GetValue("titlePrefix").ToString();
                        break;
                    case "titleSuffix":
                        titleSuffix = regKey.GetValue("titleSuffix").ToString();
                        break;
                    case "titleSaveLocation":
                        titleSaveLocation = regKey.GetValue("titleSaveLocation").ToString();
                        break;
                    default:
                        throw new Exception("Not support this keyname");
                }
            }
            hkcu.Close();
        }

        private static void Write(string key, string value)
        {
            var hkcu = Registry.CurrentUser;
            var regKey = hkcu.OpenSubKey(regKeyPath, true);
            regKey?.SetValue(key, value);
            hkcu.Close();
        }
    }
}
