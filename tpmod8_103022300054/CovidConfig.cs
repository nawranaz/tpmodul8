using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmod8_103022300054
{
    internal class CovidConfig
    {
        private const string ConfigFileName = "covid_config.json";

        public string satuan_suhu { get; set; } = "celcius";
        public int batas_hari_deman { get; set; } = 14;
        public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public CovidConfig() { }

        public static CovidConfig LoadConfig()
        {
            if (File.Exists(ConfigFileName))
            {
                string json = File.ReadAllText(ConfigFileName);
                var config = JsonSerializer.Deserialize<CovidConfig>(json);
                if (config != null)
                {
                    return config;
                }
            }

            var defaultConfig = new CovidConfig();
            defaultConfig.SaveConfig();
            return defaultConfig;
        }

        public void SaveConfig()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigFileName, json);
        }

        public void UbahSatuan()
        {
            satuan_suhu = satuan_suhu == "celcius" ? "fahrenheit" : "celcius";
            SaveConfig();
            Console.WriteLine($"Satuan suhu berhasil diubah ke: {satuan_suhu}");
        }
    }

}

