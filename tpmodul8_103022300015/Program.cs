using System;
using tpmodul8_103022300015;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config =  CovidConfig.LoadConfig();

        config.UbahSatuan();

        Console.WriteLine($"satian suhu setelah diubah: {config.satuan_suhu}: ");

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu = double.Parse( Console.ReadLine() );

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        double hariDemam = double.Parse( Console.ReadLine() );

        bool suhuValid = false;
        if (config.satuan_suhu == "celcius")
        {
            suhuValid = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (config.satuan_suhu == "fahrenheit") 
        {
            suhuValid = suhu >= 97.7 && suhu <= 99.5;
        }

        bool hariValid = hariDemam < config.batas_hari_demam;

        if (suhuValid && hariValid)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        { 
        Console.WriteLine(config.pesan_ditolak);
        }
    }
}