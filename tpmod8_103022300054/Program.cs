// See https://aka.ms/new-console-template for more information
using tpmod8_103022300054;

class Program
{
    static void Main()
    {
        CovidConfig config = CovidConfig.LoadConfig();
        Console.WriteLine("Program Ubah Suhu");
        Console.WriteLine("\nMengubah satuan suhu...");
        config.UbahSatuan();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        if (!double.TryParse(Console.ReadLine(), out double suhu))
        {
            Console.WriteLine("Input suhu tidak valid.");
            return;
        }

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        if (!int.TryParse(Console.ReadLine(), out int hariDemam))
        {
            Console.WriteLine("Input hari tidak valid.");
            return;
        }

        bool suhuNormal = false;
        if (config.satuan_suhu == "celcius")
        {
            suhuNormal = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (config.satuan_suhu == "fahrenheit")
        {
            suhuNormal = suhu >= 97.7 && suhu <= 99.5;
        }

        if (suhuNormal && hariDemam < config.batas_hari_deman)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
    }
}
