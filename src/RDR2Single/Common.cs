using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RDR2Single
{
    class Common
    {
        public static string DataPath { get; } = "x64/data/";
        public static int CodeMaxLength { get; } = 13;

        public static string ConfigPath
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, "config.json");
            }
        }

        public static bool CheckIsGamePath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }
            string gameDataPath = Path.Combine(path, DataPath);
            return Directory.Exists(gameDataPath);
        }

        public static bool SaveConfig(string path, string code)
        {
            try
            {
                ConfigModel config = new ConfigModel()
                {
                    Path = path,
                    Code = code,
                    UpdateTime = DateTime.Now,
                };
                string fileContent = JsonSerializer.Serialize(config, new JsonSerializerOptions()
                {
                    WriteIndented = true,
                });
                File.WriteAllText(ConfigPath, fileContent);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static (bool result, ConfigModel config) LoadConfig()
        {
            try
            {
                if (!File.Exists(ConfigPath))
                {
                    return (false, null);
                }
                string content = File.ReadAllText(ConfigPath);
                if (string.IsNullOrEmpty(content))
                {
                    return (false, null);
                }
                ConfigModel config = JsonSerializer.Deserialize<ConfigModel>(content);
                if(config  == null)
                {
                    return (false, null);
                }
                return (true, config);
            }
            catch
            {
                return (false, null);
            }
        }
    }
}
