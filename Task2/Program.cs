using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            char direction = 'l';
            int N = 10;
            string[] str = new string[]
            {
                "8",
                "3 5",
                "-1",
                "7 9",
                "2",
                "4 6",
                "0 1",
                "9 3",
                "1",
                "2"
            };
            var sites = new List<Task1>();
            foreach (var item in str)
            {
                var nums = item.Trim().Split(' ');
                if (nums.Length==2)
                {
                    var n1 = Convert.ToInt32(nums[0]);
                    var n2 = Convert.ToInt32(nums[1]);
                    sites.Add(new Task1( n1, n2));
                }
                else if (nums.Length == 1)
                {
                    var v = Convert.ToInt32(nums[0]);
                    sites.Add(new Task1(v));
                }
                else
                {
                    continue;
                }
            }

            List<int> visit = new List<int>();
            var ind = 0;
            do
            {
                visit.Add(ind);
                if (sites[ind].IsVisited == true)
                {
                    break;
                }
                ind = sites[ind].IndexNext(direction);
                Console.WriteLine(ind);
            } while (ind!=-1);

            if (ind==-1)
            {
                Console.WriteLine("no");
            }
            else
            {
                while (visit[0] != ind)
                {
                    visit.RemoveAt(0);
                }
                visit.RemoveAt(0);
                foreach (var item in visit.OrderBy(x=>x))
                {
                    Console.Write($"{item} ");
                }
            }

            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
