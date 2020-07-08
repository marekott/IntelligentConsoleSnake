using System;
using System.Collections.Specialized;
using System.Configuration;

namespace ConsoleUI
{
    public class ConfigProvider : IConfigProvider //TODO jako singleton
    {
        private readonly NameValueCollection _appSettings;

        public ConfigProvider()
        {
            _appSettings = ConfigurationManager.AppSettings;
        }

        public int GetMapHeight()
        {
            return Convert.ToInt16(_appSettings["MapHeight"]);
        }

        public int GetMapWidth()
        {
            return Convert.ToInt16(_appSettings["MapWidth"]);
        }

        public int GetGameLeftOffset()
        {
            return Convert.ToInt16(_appSettings["GameLeftOffset"]);
        }

        public int GetGameTopOffset()
        {
            return Convert.ToInt16(_appSettings["GameTopOffset"]);
        }
    }
}
