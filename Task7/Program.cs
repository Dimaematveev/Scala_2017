using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = new int[] { 54, 72, 64, 58 };
            int n_nok = 1;
            for (int i = 0; i < N.Length; i++)
            {
                n_nok = nok_recur(n_nok, N[i]);
            }
            Console.WriteLine(n_nok);
            Console.ReadKey();
        }
        static int nok_recur(int num1, int num2)
        {
            return num1 * num2 / nod_recur(num1, num2);
        }
        static int nod_recur(int num1, int num2)
        {
            
            int n = num1 % num2;
            num1 = num2;
            num2 = n;
            if (n > 0)
                return nod_recur(num1, num2);
            else
                return num1;
        }
    }
}
