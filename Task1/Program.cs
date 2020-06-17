using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = new Task("FileInput.txt", "FileOutput.txt");
            var z =t.TreeToLine();
            int? maxLen = z.Max(x => x?.Max(y => y?.Length));

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
