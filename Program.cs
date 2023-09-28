using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dekodolo2
{
    class Program
    {
        static void Main(string[] args)
        {
            var karakterek = new List<Karakter>();
            using StreamReader sr = new StreamReader(
                path:@"..\..\..\src\bank.txt",
                Encoding.UTF8
                );

            while (!sr.EndOfStream)
            {
                char b = char.Parse(sr.ReadLine());
                bool[,] m = new bool[4, 7];
                for (int s = 0; s < 4; s++)
                {
                    string sor = sr.ReadLine();
                    for (int o = 0; o < sor.Length; o++)
                    {
                        m[s, o] = sor[o] == '1' ? true : false;
                    }
                }
                karakterek.Add(new Karakter(b, m));
            }
        }
    }
}
