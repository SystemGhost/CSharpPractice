using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Элементы класса System.Array
 */
namespace PracticCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = {{1,3,5 }, {10,20,30 } };
            Console.WriteLine(array.Rank);                                      //возращает размерность массива; 2
            Console.WriteLine(array.Length);                                    //возращает число элементов массива; 6
            Console.WriteLine(array.GetLowerBound(0));                          //возвращает нижнюю границу для указанного измерения; 0
            Console.WriteLine(array.GetUpperBound(1));                        //возвращает верхнюю границу для указанного измерения; 2

            //Сортировка и поиск в одномерном массиве
            int[] array2 = {1, -3, 5, 10, 2, 5, 30};
            Console.WriteLine(Array.IndexOf(array2, 5));                        //поиск с начала
            Console.WriteLine(Array.LastIndexOf(array2, 5));                     //поиск с конца

            Array.Reverse(array2);                                              //реверс
            Array.Sort(array2);                                                 //сортировка
            foreach (int x in array2)
                Console.Write(x + " ");
            Console.WriteLine();

            Console.WriteLine("\n" + Array.BinarySearch(array2, 10));                  //бинарный поиск

            Console.ReadKey(true);
        }
    }
}
