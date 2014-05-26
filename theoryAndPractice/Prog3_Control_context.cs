using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        //(не)контролируемый контекст
        static void Main(string[] args)
        {
            Console.WriteLine("Input your Age");
            string s = Console.ReadLine();
            int i = Int32.Parse(s);
            Console.WriteLine("i = " + i);
            Console.ReadKey();

        }
    }
}
