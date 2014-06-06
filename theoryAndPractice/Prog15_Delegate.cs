using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Делегаты
 */
namespace PracticCSharp
{
    class Program
    {
        static void Main()
        {
            int[] A = { 1, 20, 30 };
            PrintMethod first, second, result;
            first = new PrintMethod(MainClass.ConsolePrint);
            MainClass C = new MainClass();
            second = new PrintMethod(C.FormatPrint);
            result = first + second;
            ArrayPrint.print(A, result);

            Console.ReadKey(true);
        }
        delegate void PrintMethod(int x);

        class ArrayPrint
        {
            public static void print(int[] A, PrintMethod P) {
                foreach(int element in A)
                P(element);
                }
        }

        class MainClass
        {
            public static void ConsolePrint(int i)
            {
                Console.WriteLine(i);
            }
            public void FormatPrint(int i)
            {
                Console.WriteLine("Element is {0}", i);
            }
            
        }
    }      
}
