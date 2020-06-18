using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Task1
    {
        public int Price;
        public int Increased;
        public Task1(int price,int increased)
        {
            Price = price;
            Increased = increased;
        }

        public override string ToString()
        {
            return $"Цена:{Price}, Вырос на:{Increased}";
        }
    }
}
