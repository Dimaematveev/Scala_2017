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
            //t.ToConsole();
            

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
