using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 10;




            string[] str = new string[]
            {
                "10 15",
                "20 12",
                "30 18",
                "10 1",
                "90 9",
                "1 7",
                "8 10",
                "13 8",
                "5 1",
                "3 8",
            };
            var Bamb = new List<Task1>();
            foreach (var item in str)
            {
                var mas = item.Trim().Split(' ');
                var p = Convert.ToInt32(mas[0]);
                var inc = Convert.ToInt32(mas[1]);
                Bamb.Add(new Task1(p, inc));
            }

            int profit = 0;
            while (Bamb.Count>0)
            {
                int max =Bamb.Max(x => x.Price);
                int indmax = Bamb.FindLastIndex(x => x.Price == max);
                int countBamb = 0;

                for (int i = 0; i < indmax; i++)
                {
                    countBamb += Bamb[0].Increased;
                    Bamb.RemoveAt(0);
                }
                countBamb += Bamb[0].Increased;
                profit += Bamb[0].Price * countBamb;
                Bamb.RemoveAt(0);
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
