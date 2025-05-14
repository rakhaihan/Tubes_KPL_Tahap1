using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace Library.ConfigurationLibrary
{
    public class ConfigManager
    {
        public AppConfig Config { get; set; }
        private readonly string _configFilePath;
        public ConfigManager(string configFilePath = "AppConfig.json")
        {
            _configFilePath = configFilePath ?? throw new ArgumentNullException(nameof(configFilePath));
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteConfigFile();
            }
        }

        private void ReadConfigFile()
        {
            string jsonData = File.ReadAllText(_configFilePath);
            Config = JsonSerializer.Deserialize<AppConfig>(jsonData) ?? throw new InvalidOperationException("Gagal deserialisasi konfigurasi.");
        }

        private void WriteConfigFile()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Config, options);
            File.WriteAllText(_configFilePath, json);
        }

        private void SetDefault()
        {
            Config = new AppConfig(10, 20, 30, true, false, "Siswa");
        }
    }
}
