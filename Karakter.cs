using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekodolo2
{
    class Karakter
    {
        public char Betu { get; set; }
        public bool[,] Matrix { get; set; }

        public string Kirajzol()
        {
            string karakterKep = string.Empty;
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    karakterKep += Matrix[i, j] ? "x" : " ";
                }
                karakterKep += '\n';
            }
            return karakterKep;
        }

        public bool Felismer(Karakter felism)
        {
            for (int s = 0; s < Matrix.GetLength(0); s++)
            {
                for (int o = 0; o < Matrix.GetLength(1); o++)
                {
                    if (this.Matrix[s, o] != felism.Matrix[s, o]) return false;
                }
            }
            return true;
        }

        public Karakter(char betu, bool[,] matrix)
        {
            Betu = betu;
            Matrix = matrix;
        }
    }
}
