using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lotto
{
    class Program
    {
        static int[] GenerateDraw(Random random)
        {
            int[] t = new int[5];
            for (int i = 0; i < t.Length; i++)
            {
                int next = random.Next(1, 91);
                int k = 0;
                while (k < i && t[k] != next)
                {
                    k++;
                }
                if (k == i)
                    t[i] = next;
                else
                    i--;
            }
            return t;
        }

        static string OutDraw(int[] t)
        {
            //string sep = "";
            //string s = "";
            //for (int i = 0; i < t.Length; i++)
            //{
            //    s += sep + t[i];
            //    sep = ", ";
            //}
            //return s;
            return string.Join(", ", t);
        }

        static int[,] GenerateLotto(Random random)
        {
            int[,] szelvenyek = new int[20, 5];
            for (int i = 0; i < szelvenyek.GetLength(0); i++)
            {
                int[] szelveny = GenerateDraw(random);
                for (int k = 0; k < szelveny.Length; k++)
                {
                    szelvenyek[i, k] = szelveny[k];
                }
            }
            return szelvenyek;
        }

        static string OutLotto(int[,] szelvenyek, int[] kihuzott)
        {
            string s = "";

            for (int i = 0; i < szelvenyek.GetLength(0); i++)
            {
                int talalat = 0;
                s += "Lotto #" + (i + 1) + ":\t";
                for (int j = 0; j < szelvenyek.GetLength(1); j++)
                {
                    s += szelvenyek[i, j] + " ";
                    if (Inside(kihuzott, szelvenyek[i, j]))
                        talalat++;
                }
                s += "\tTalálatok száma: " + talalat + "\n";
            }

            return s;
        }

        static bool Inside(int[] t, int value)
        {
            int i = 0;
            while (i < t.Length && t[i] != value)
                i++;
            return i < t.Length;
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            int[] t = GenerateDraw(random);
            Console.WriteLine(OutDraw(t));

            int[,] szelvenyek = GenerateLotto(random);
            Console.WriteLine(OutLotto(szelvenyek, t));

            Console.ReadKey();
        }
    }
}
