using Microsoft.Extensions.Configuration;
using System;

namespace ConsoleUI.Configuration
{
    public class ConfigProvider : IConfigProvider //TODO jako singleton
    {
        private readonly IConfiguration _config;

        public ConfigProvider(IConfiguration config)
        {
            _config = config;
        }

        public int GetMapHeight()
        {
            return Convert.ToInt16(_config.GetSection("Game")["MapHeight"]);
        }

        public int GetMapWidth()
        {
            return Convert.ToInt16(_config.GetSection("Game")["MapWidth"]);
        }

        public int GetGameLeftOffset()
        {
            return Convert.ToInt16(_config.GetSection("Game")["GameLeftOffset"]);
        }

        public int GetGameTopOffset()
        {
            return Convert.ToInt16(_config.GetSection("Game")["GameTopOffset"]);
        }
    }
}
