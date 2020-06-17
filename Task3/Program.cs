using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var zat = new int[] { 1, 5, 1, 1, 1, 1, 1, 1, 1, 1 };
            var prov = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var ot= Prov(zat, prov, 1);

            Console.WriteLine(ot);
            Console.ReadKey();
        }

        public static int Prov(int[] zat, int[] prov, int num)
        {
            if (num >= 109) 
            {
                return -1;
            }
            var k = num.ToString();
            for (int i = 0; i < k.Length; i++)
            {
                prov[Convert.ToInt32(k[i].ToString())]++;
            }
            for (int i = 0; i < 10; i++)
            {
                if (zat[i]!=prov[i])
                {
                    return Prov(zat, prov, ++num);
                }
            }
            return num;
        }
    }
}
