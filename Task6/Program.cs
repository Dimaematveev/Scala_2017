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

            T6 t6 = new T6(h[0]);
            for (int i = 1; i < N; i++)
            {
                t6.Add(h[i]);
            }
            

            Console.WriteLine(t6.Max());
            Console.ReadKey();
        }
    }

    public class T6
    {
        public List<Item> Item ;

        public T6(int val)
        {
            Item = new List<Item>();
            Item.Add(new Task6.Item(val));
        }

        public void Add(int val)
        {
            Item.Add(new Task6.Item(val, Item.Last()));
        }

        public int Max()
        {
           
            return Item.Max(x=>x.Max());
        }
    }
    public class Item
    {
        public int value;
        public Dictionary<int,int> Square;

        public Item(int value)
        {
            this.value = value;
            Square = new Dictionary<int, int>();
            for (int i = 1; i <= value; i++)
            {
                Square.Add(i, i);
            }
        }
        public Item(int value, Item item)
        {
            this.value = value;
            Square = new Dictionary<int, int>();
            for (int i = 1; i <= value; i++)
            {
                Square.Add(i, i);
                if (item != null && item.Square.ContainsKey(i))
                {
                    Square[i] += item.Square[i];
                }
            }
        }

        public int Max()
        {
            return Square.Max(x => x.Value);
        }
    }
}
