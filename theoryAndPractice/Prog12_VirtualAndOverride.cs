using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Для организации полиморфного вызова методов применяется пара ключе-
вых слов virtual и override: virtual указывается для метода базового клас-
са, который мы хотим сделать полиморфным, override – для методов произ-
43
водных классов. Эти методы должны совпадать по имени и сигнатуре с пере-
крываемым методом класса-предка.
 */
namespace PracticCSharp
{
    class Program
    {
        static void Main()
        {
            CPet cpet, cat;
            cpet = new CPet();
            cat = new Cat();
            cpet.Speak();
            cat.Speak();
            Console.ReadKey(true);
        }

        class CPet
        {
            public virtual void Speak()
            {
                Console.WriteLine("I'm Pet!");
            }
        }

        class Cat : CPet
        {
            public override void Speak()
            {
                Console.WriteLine("I'm Cat!");
            }
        }
        
    }
}
