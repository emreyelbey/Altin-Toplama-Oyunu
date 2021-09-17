using System;
using System.IO;
namespace AltınToplamaOyunu2
{
    public class Log
    {
        string dosya;
        public FileStream fs;
        public StreamWriter sw;

        public Log(string dosya_adi)
        {
            dosya = "..\\..\\..\\Loglama\\" + dosya_adi + ".txt";
            fs = new FileStream(dosya, FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs);
        }

        public void DosyaYazdır(string str)
        {
            if (File.Exists(dosya))
            {
                sw.WriteLine(str);
                sw.Flush();
            }
        } 
    }
}
