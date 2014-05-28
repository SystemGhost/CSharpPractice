using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Элементы класса System.String
 */
namespace PracticCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "ab";
            string b = "ab";
            string c = " az";

            Console.WriteLine(String.Compare(a, b));        //сравнение поочередно кодов символов
            Console.WriteLine(String.Compare(a, c));
            
            Console.WriteLine("{0}, {1}, {2}, {3}", a,b,c, String.Concat(a, b, c)); //сцепление строк и возращение новой строки
            //String.Join(a, b);
            //Console.WriteLine("{0}, {1}, {2}", a, b,String.Join(a, b));

            string txt = "Убивай, вновь и вновь " + "Бог войны любит кровь " + "Черепа, груды тел " + "Путь укажет восемь стрел.";
            string[] splitString, Words;

            splitString = txt.Split(',');               //Разделения на отдельные слова по разделитлю

            foreach (string x in splitString)
                Console.WriteLine(x+ " ");

            Words = txt.Split(',', ' ');
            foreach (string x in Words)
                Console.WriteLine(x + " ");

            string d = "DunnoLol", f = "Emperor", g = "Chaos";

            Console.WriteLine("1)" + d.Insert(5, g));                                           //вставка
            Console.WriteLine("2)"+ d.Remove(5));                                               //удаление
            Console.WriteLine("3)" + d.Replace("Lol", f));                                      //замена
            Console.WriteLine("4)" + d.Substring(5));                                           //выделение подстроки
            Console.WriteLine("5)" + d.StartsWith("Dun") + " " + d.EndsWith("Dun"));            ///проверка есть подстрока в начале или в конце.
          


            Console.ReadKey(true);
        }
    }
}
