using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  
 */
namespace PracticCSharp
{
    class Program
    {
        static void Main()
        {
            CExampleClass C = new CExampleClass();
            C.setField(200);
            C.setField(-200);   // Нет обработчиков, нет и реакции
            // Если бы при генерации события в CExampleClass
            // отсутствовала проверка на null, то предыдущая
            // строка вызвала бы исключительную ситуацию

            C.onErrorEvent += new Proc(MainClass.firstReaction);
            C.setField(-10);
            C.onErrorEvent += new Proc(MainClass.secondReaction);
            C.setField(-20);
            Console.ReadKey(true);
        }
        //        Данный класс будет включать метод с целым параметром, устанавливающий
        //значение поля класса. Если значение параметра отрицательно, генерируется со-
        //бытие, определенное в классе
        delegate void Proc(int i);

        class CExampleClass
        {
            int field;

            public event Proc onErrorEvent;

            public void setField(int i)
            {
                field = i;
                if (i < 0)
                {
                    if (onErrorEvent != null) onErrorEvent(i);
                }
            }
        }
        class MainClass
        {
            public static void firstReaction(int i)
            {
                Console.WriteLine("{0} is bad value", i);
            }
            public static void secondReaction(int i)
            {
                Console.WriteLine("Are you stupid?");
            }
        }
    }      
}
