using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public static class AppConfig
    {

        private const string KEY_CONNECT_STRING = "ConnectionStrings";

        public static string GetConnectionString(string name)
        {

            // Ưu tiên biến môi trường
            var envConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            if (!string.IsNullOrEmpty(envConnectionString))
            {
                Console.WriteLine(">>>>Use Variable Environment to connect Server!!!");
                return envConnectionString;
            }

            // Nếu không có, đọc từ appsettings.json
            // Đọc file chung
            var json = File.ReadAllText("appsettings.json");
            var config = JObject.Parse(json);

            // Nếu có file override, đọc và ghi đè
            if (File.Exists("appsettings.development.json"))
            {
                var devJson = File.ReadAllText("appsettings.development.json");
                var devConfig = JObject.Parse(devJson);
                config.Merge(devConfig, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Replace
                });
            }

            Console.WriteLine(">>>>Use appsettings to connect Server!!!");
            return config[KEY_CONNECT_STRING]?[name]?.ToString();
        }
    }
}
