using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Task1
    {
        public int l;
        public int r;
        public bool IsVisited = false;

        public Task1(int l, int r)
        {
            this.l = l;
            this.r = r;
        }
        public Task1(int v) :this(v,v)
        {
        }

        public int IndexNext(char direct)
        {
            if (direct=='r')
            {
                IsVisited = true;
                return r;
            }
            else if(direct == 'l')
            {
                IsVisited = true;
                return l;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
