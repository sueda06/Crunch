using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileName = @"C:\Sifreler2.txt";

            string writeText = "";

            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Close();
            string sayi = Console.ReadLine();
            int[] dizi = new int[4];
            for (int i = 0; i < sayi.Length; i++)
            {
                for (int j = i+1; j < sayi.Length; j++)
                {
                    if (Convert.ToInt32(sayi.Substring(i, 1)) == Convert.ToInt32(sayi.Substring(j, 1)))
                    {
                        sayi=sayi.Remove(j, 1);
                        j--;
                    }
                }
            }
            for (int i = 0; i < sayi.Length; i++)
            {
                dizi[i] = Convert.ToInt32(sayi.Substring(i, 1));
            }

            int sayac = 1;
            for (int i = 0; i < sayi.Length; i++)
            {
                for (int j = 0; j <sayi.Length; j++)
                {
                    for (int k = 0; k < sayi.Length; k++)
                    {
                        for (int h = 0; h < sayi.Length; h++)
                        {
                            writeText = sayac + " " + dizi[h] + "" + dizi[k] + "" + dizi[j] + "" + dizi[i];
                            File.AppendAllText(fileName, Environment.NewLine + writeText);
                            //Console.Write(sayac+" "+dizi[h]+""+dizi[k]+""+dizi[j]+""+dizi[i]);
                            //Console.WriteLine();
                            sayac++;
                        } 
                        
                    }
                }
            }
            Program e = new Program();
            e.dosyadanOku();
            Console.ReadKey();
        }

        public void dosyadanOku()
        {
            string dosya_yolu = @"C:\sifreler2.txt";
            //Okuma işlem yapacağımız dosyanın yolunu belirtiyoruz.
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            //Bir file stream nesnesi oluşturuyoruz. 1.parametre dosya yolunu,
            //2.parametre dosyanın açılacağını,
            //3.parametre dosyaya erişimin veri okumak için olacağını gösterir.
            StreamReader sw = new StreamReader(fs);
            //Okuma işlemi için bir StreamReader nesnesi oluşturduk.
            string yazi = sw.ReadLine();
            while (yazi != null)
            {
                ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
                cmdStartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                cmdStartInfo.RedirectStandardOutput = true;
                cmdStartInfo.RedirectStandardError = true;
                cmdStartInfo.RedirectStandardInput = true;
                cmdStartInfo.UseShellExecute = false;
                cmdStartInfo.CreateNoWindow = true;

                Process cmdProcess = new Process();
                cmdProcess.StartInfo = cmdStartInfo;
                cmdProcess.EnableRaisingEvents = true;
                cmdProcess.Start();
                cmdProcess.BeginOutputReadLine();
                cmdProcess.BeginErrorReadLine();

                cmdProcess.StandardInput.WriteLine(yazi);
                cmdProcess.StandardInput.WriteLine("exit");

                cmdProcess.WaitForExit();


                Console.WriteLine(yazi);
                yazi = sw.ReadLine();
            }
            //Satır satır okuma işlemini gerçekleştirdik ve ekrana yazdırdık
            //Son satır okunduktan sonra okuma işlemini bitirdik
            sw.Close();
            fs.Close();
            //İşimiz bitince kullandığımız nesneleri iade ettik.
        }
    }
}
