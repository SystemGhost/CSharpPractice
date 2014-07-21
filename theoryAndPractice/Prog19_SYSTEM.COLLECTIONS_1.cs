using System;
using System.Collections;
using System.IO;

/*
 * ПРОСТРАНСТВО ИМЕН SYSTEM.COLLECTIONS
 */
/*
 * Имея в своем распоряжении класс CStudent, мы можем организовать мас-
сив из объектов данного класса. Однако методы сортировки из класса Array
для такого массива работать не будут. Для того чтобы выполнялась сортировка,
необходимо, чтобы класс реализовывал интерфейс System.IComparable.
 */
delegate double Function(double x);
class Test
{
    #region CStudent
    class CStudent: IComparable
    {
        public string name;
        public int course;
        public double ball;

        public CStudent(string name, int course, double ball)
        {
            this.name = name;
            this.course = course;
            this.ball = ball;
        }

        public override string ToString()
        {
            return String.Format("Name={0,10}, Course={1,3}, Ball={2,4}", name, course, ball);
        }
        public int CompareTo(object o)
        {
            CStudent temp = (CStudent)o;
            if (ball > temp.ball) return 1;
            if (ball < temp.ball) return -1;
            return 0;
        }
        /*
         * Интерфейс IComparable определен следующим образом:
                interface IComparable 
         *      {
                    int CompareTo(object o);
                }
         *  Метод CompareTo() сравнивает текущий объект с объектом o. Метод дол-
            жен возвращать ноль, если объекты «равны», любое число больше нуля, если
            текущий объект «больше», и любое число меньше нуля, если текущий объект
            «меньше» сравниваемого.
         */

    }
    #endregion CStudent
    /*
     * Интерфейс IComparer из пространства имен System.Collections предос-
    тавляет стандартизированный способ сравнения любых двух объектов:
    
    interface IComparer {
    int Compare(object o1, object o2);
    }
    
    Использование IComparer позволяет осуществить сортировку по несколь-
    ким критериям. Для этого каждый критерий описывается вспомогательным
    классом, реализующим IComparer и определенный способ сравнения.
     */
    #region SecondaryClasses
    class SortStudentByBall : IComparer
    {
        public int Compare(object o1, object o2)
        {
            CStudent s1 = (CStudent)o1;
            CStudent s2 = (CStudent)o2;
            if (s1.ball > s2.ball) return 1;
            if (s1.ball < s2.ball) return -1;
            return 0;
        }
    }

    class SortStudentByName : IComparer
    {
        public int Compare(object o1, object o2)
        {
            CStudent s1 = (CStudent)o1;
            CStudent s2 = (CStudent)o2;
            return String.Compare(s1.name, s2.name);
        }
    }
   /* Теперь для сортировки по разным критериям можно использовать пере-
груженную версию метода Array.Sort(), принимающую в качестве второго
параметра объект класса, реализующего интерфейс IComparer.*/
    #endregion SecondaryClasses
    #region Room
    /*
             * Было бы удобно для перебора элементов в объектах нашего класса исполь-
                зовать команду foreach. Для этого необходимо организовать в классе под-
                держку интерфейса IEnumerable1. Интерфейс IEnumerable устроен очень про-
                сто. Он содержит единственный метод, задача которого – вернуть интерфейс
                IEnumerator.
             
                interface IEnumerable 
                {
                IEnumerator GetEnumerator();
                }
             * В свою очередь, интерфейс IEnumerator имеет следующее описание:
             
                interface IEnumerator {
                // Передвинуть курсор данных на следующую позицию
                bool MoveNext();
                // Свойство для чтения – текущий элемент
                object Current { get; }
                // Установить курсор перед началом набора данных
                void Reset();
                }
             */
    class Room: IEnumerable, IEnumerator
    {
        private CStudent[] H;
        //Внутренее поле для курсора данных
        private int pos = -1;

        //This is bad, but must it.
        public Room()
        {
            H = new CStudent[3];
            H[0] = new CStudent("Alex", 1, 7.0);
            H[1] = new CStudent("Ivan", 1, 9.0);
            H[2] = new CStudent("Peter", 1, 5.0);
        }

        //класс сам реализует IEnumerator
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            if (pos < H.Length)
            {
                pos++;
                return true;
            }
            else return false;
        }

        public void Reset()
        {
            pos = -1;
        }

        public object Current
        {
            get{return H[pos];}
        }
        
        
    }
    #endregion Room
    static void Main()
    {
        CStudent[] Group = {new CStudent("Alex", 1, 6.0),
                               new CStudent("Ivan", 1, 9.0),
                               new CStudent("Gans", 1, 9.9),
                               new CStudent("Anna", 1, 7.5)
                           };
        //Класс CStudent теперь можно использовать таким образом:
        Console.WriteLine("Unsorted group:");
        foreach (CStudent s in Group)
        {
            Console.WriteLine(s);
        }

        Array.Sort(Group);
        Array.Reverse(Group);

        Console.WriteLine("Sorted group");
        foreach (CStudent s in Group)
        {
            Console.WriteLine(s);
        }
        //*********************************

        //Сортировка массива студентов по баллу(System.Collections.ICompare)
        Array.Sort(Group, new SortStudentByBall());
        //Сортировка массива студентов по имени
        Array.Sort(Group, new SortStudentByName());

        //*********************************
        //Теперь для перебора элементов класса Room мы можем использовать такой код:
        Console.WriteLine("***");
        Room Room_1003 = new Room();
        foreach (CStudent S in Room_1003)
        {
            Console.WriteLine(S);
        }

        Console.ReadKey(true);
    }
}