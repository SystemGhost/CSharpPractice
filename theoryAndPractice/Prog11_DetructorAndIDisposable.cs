using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Интерфейс IDisposable, содержащий единственный метод Dispose(), куда
помещается завершающий код работы с объектом. Класс, объекты которого
требуется освобождать «вручную», реализовывает интерфейс IDisposable
 */
namespace PracticCSharp
{
    class Program
    {
        static void Main()
        {
            //C# имеет специальную обрамляющую конструкцию using, которая гаран-
            //тирует вызов метода Dispose() для объектов, использующихся в своем блоке.
            using (classWithDestructor A = new classWithDestructor("A"))
            {
                A.doSomething();
                // компилятор поместит сюда вызов A.Dispose()
            }
            Console.ReadKey(true);
        }

        class classWithDestructor : IDisposable
        {
            public string name;

            public classWithDestructor(string name)
            {
                this.name = name;
            }

            public void doSomething()
            {
                Console.WriteLine("I'm working!");
            }
            //реализуем метод освобождения
            public void Dispose()
            {
                Console.WriteLine("Dispose called for " + name);
            }

            ~classWithDestructor()
            {
                //lдеструктор вызывает Dispose На всякий случай
                Dispose();
                Console.WriteLine("Bye!");
            }
        }
    }
}
