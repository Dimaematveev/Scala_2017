using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 7;
            int[] h = new int[]
            {
                1,3,2,9,2,5,4
            };

            int max = h[0];
            int count = 1;
            for (int i = 1; i < N; i++)
            {
                if (h[i]==h[i-1])
                {
                    count++;
                }
                else
                {
                    int maxtemp= h[i - 1] * count;
                    if (maxtemp>max)
                    {
                        max = maxtemp;
                    }
                    count = 1;
                }
            }
            {
                int maxtemp = h[N-1] * count;
                if (maxtemp > max)
                {
                    max = maxtemp;
                }
            }


            Console.WriteLine(max);
            Console.ReadKey();
        }
    }
}
