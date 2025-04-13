using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace tpmodul8_103022300015
{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; } = "celcius";
        public int batas_hari_demam { get; set; } = 14;
        public string pesan_ditolak { get; set; } = "anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string pesan_diterima { get; set; } = "anda dipersilahkan masuk ke dalam gedung ini";

        private const string FilePath = "covid_config.json";

        public static CovidConfig LoadConfig()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<CovidConfig>(json);
            }
            else
            {
                CovidConfig config = new CovidConfig();
                config.SaveConfig();
                return config;
            }
        }

        public void SaveConfig()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public void UbahSatuan()
        {
            satuan_suhu = (satuan_suhu == "celcius") ? "fahrenheit" : "celcius";
            SaveConfig();
        }
    }
}
