using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Sifreler.txt";

            string writeText = "";

            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Close();
            string metin = Console.ReadLine();
            char[] dizi = new char[5];
            for (int i = 0; i < metin.Length; i++)
            {
                for (int j = i+1; j < metin.Length; j++)
                {
                    if(metin.Substring(i, 1) == metin.Substring(j, 1))
                    {
                        metin = metin.Remove(j, 1);
                        j--;
                    }
                }
            }
            dizi = metin.ToCharArray();
            int sayac = 1;
            for (int i = 0; i < metin.Length; i++)
            {
                for (int j = 0; j < metin.Length; j++)
                {
                    for (int k = 0; k < metin.Length; k++)
                    {
                        for (int h = 0; h < metin.Length; h++)
                        {
                            for (int l = 0; l < metin.Length; l++)
                            {
                                writeText = sayac + " " + dizi[h] + "" + dizi[k] + "" + dizi[j] + "" + dizi[i] + "" + dizi[l];
                                File.AppendAllText(fileName, Environment.NewLine + writeText);
                                //Console.Write(sayac+ " " + dizi[h] + "" + dizi[k] + "" + dizi[j] + "" + dizi[i] + ""+dizi[l]);
                                //Console.WriteLine();
                                sayac++;
                            }
                        }

                    }
                }
            }
            Console.ReadKey();
        }
    }
}
