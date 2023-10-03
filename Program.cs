using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Dekodolo2
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = Beolvas(@"..\..\..\src\bank.txt");

            Console.WriteLine("5.Feladat:");
            Console.WriteLine($"Karakterek száma: {bank.Count}");

            Console.WriteLine("6.Feladat:");
            char input = '\0';
            bool result = false;
            do
            {
                Console.WriteLine("Karakter input: ");
                result = char.TryParse(Console.ReadLine(), out input);
            } while (!result || input < 65 || input > 90);

            Console.WriteLine("7.Feladat:");
            var megj = bank.SingleOrDefault(k => k.Betu == input);
            if (megj is not null) Console.WriteLine(megj.Kirajzol());
            else Console.WriteLine("Nincsen a karakter a bankban!");

            var dekodolando = Beolvas(@"..\..\..\src\dekodol.txt");

            Console.WriteLine("9.Feladat: Dekódolás");
            foreach (var dekk in dekodolando)
            {
                var bankk = bank.SingleOrDefault(k => k.Felismer(dekk));
                Console.Write(bankk is null ? "?" : bankk.Betu);
            }
            Console.WriteLine();
        }

        static List<Karakter> Beolvas(string eleresiUt)
        {
            var karakterek = new List<Karakter>();
            using StreamReader sr = new StreamReader(
                eleresiUt,
                Encoding.UTF8
                );

            while (!sr.EndOfStream)
            {
                char b = char.Parse(sr.ReadLine());
                bool[,] m = new bool[7, 4];
                for (int s = 0; s < 7; s++)
                {
                    string sor = sr.ReadLine();
                    for (int o = 0; o < sor.Length; o++)
                    {
                        m[s, o] = sor[o] == '1';
                    }
                }
                karakterek.Add(new Karakter(b, m));
            }
            return karakterek;
        }
    }
}
