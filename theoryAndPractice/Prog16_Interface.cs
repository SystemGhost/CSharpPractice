using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Интерфейсы
 *  концепция, позволяющая имитировать множественное на-
следование.
 * Класс или структура
могут реализовывать определенный интерфейс. В этом случае они берут на се-
бя обязанность предоставить полную реализацию элементов интерфейса (хотя
бы пустыми методами). Можно сказать так: интерфейс – это контракт, пункты
которого суть свойства, индексаторы, методы и события. Если пользователь-
ский тип реализует интерфейс, он берет на себя обязательство выполнить этот
контракт.
 */
namespace PracticCSharp
{
    class Program
    {
        static void Main()
        {
            // обьявим Злую курицу через 2 интерфейса
            IAngry Angry;
            IBird Bird;
            Angry = new AngryChicken();
            Bird = new AngryChicken();

            Bird.Fly();
            Console.WriteLine("Speed of AngryChicken = " + Bird.Speed +" m/s.");
            Angry.Angry();

            Console.ReadKey(true);
        }

        interface IBird
        {
            //Считается, что все элементы интерфейса имеют
            //public уровень доступа
            //метод
            void Fly();

            //Для свойства, объ-
            //явленного в интерфейсе, указываются только ключевые слова get и (или) set.
            //свойство
            double Speed { get; set; }
        }
        
        //второй интерфейс, агрессивный
        interface IAngry
        {
            void Angry();
        }

        class AngryChicken : IBird, IAngry
        {
            public void Fly()
            {
                Console.WriteLine("Chicken does not fly. So the Chicken is very angry!");
            }
            public void Angry()
            {
                Console.WriteLine("AngryChicken red eyes watching you!");
            }

            public double Speed
            {
                get { return 30.0;}
                set { }
            }
        }
    }      
}
