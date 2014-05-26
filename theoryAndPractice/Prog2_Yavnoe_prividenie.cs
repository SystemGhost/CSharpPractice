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
            int i = 1000000;
            int j = 1000000;

            int out1 = i * j;
            int out2 = unchecked(i * j);
            int out3 = checked(i * j);
            
            Console.WriteLine(out1 + "\t" + out2 + "\t" + out3);
            Console.ReadKey();

        }
    }
}
