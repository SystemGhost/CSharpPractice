// Нам понадобятся следующие пространства имен
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

/*
 *  СЕРИАЛИЗАЦИЯ
 */


class Test
{
 static void Main()
    {
       //Создаем группу
        Group g = new Group();
        g.GL.Add(new Student("Vova", 20, 4.5));
        g.GL.Add(new Student("Ira", 20, 5));
        g.GL.Add(new Student("Peter", 19, 4));

        // Выводим некоторую информацию о группе
        Console.WriteLine(g.CalcMSG());
        Console.WriteLine(g.FindTheBest().Name);

        // Создаем поток – это будет файл
        Stream fs = new FileStream("data.dat", FileMode.Create);

        // Создаем объект для сериализации в двоичном формате
        BinaryFormatter fmt = new BinaryFormatter();

        // Сериализуем и затем закрываем поток
        fmt.Serialize(fs, g);
        fs.Close();

        // Теперь десериализация. Создаем поток
        fs = new FileStream("data.dat", FileMode.Open);

        // Десериализация. Обратите внимание на приведение типов
        Group d = (Group)fmt.Deserialize(fs);

        // Выводим информацию о группе

        Console.WriteLine(d.CalcMSG());
        Console.WriteLine(d.FindTheBest().Name);
        Console.ReadKey(true);
    }
 /*
  * Чтобы реализовать сериализацию пользовательского типа, он должен
быть помечен специальным атрибутом – [Serializable]
  */

 [Serializable]
 class Student
    {
        public string Name;
        public int Age;
        public double MeanScore;

        public Student(string Name, int Age, double MeanScore)
        {
            this.Name = Name;
            this.Age = Age;
            this.MeanScore = MeanScore;
        }
    }
    [Serializable]
    class Group: IDeserializationCallback
    {
        public ArrayList GL = new ArrayList();
        /*
         * Сериализация некоторых полей может не иметь смысла (на-
пример, эти поля вычисляются при работе с объектом или хранят конфиденци-
альные данные). Для таких полей можно применить атрибут [NonSerialized].
         */
        [NonSerialized]                     // Не надо сохранять – просто посчитаем
        public double MSG;
        [NonSerialized]
        public Student BestStudent;

        public double CalcMSG()
        {
            double sum = 0;
            foreach (Student s in GL)
                sum += s.MeanScore;
            MSG = sum / GL.Count;
            return MSG;
        }
        public Student FindTheBest()
        {
            BestStudent = (Student)GL[0];

            foreach (Student s in GL)
            {
                if (s.MeanScore > BestStudent.MeanScore)
                {
                    BestStudent = s;
                }
            }
            return BestStudent;
        }
        /*
         *Однако если некоторые поля класса были помечены как [NonSerialized],
то возможно после десериализации потребуется просчитать значения
данных полей. Допустимое решение – реализовать в классе интерфейс IDeserializationCallback
из пространства имен System.Runtime.Serialization.
Данный интерфейс содержит единственный метод – OnDeserialization, кото-
105
рый вызывается исполняемой средой автоматически после десериализации
объекта. 
         */

        // После десериализации просчитаем средний балл и
        // найдем лучшего студента. Работа с параметром метода
        // исполняемой средой на данный момент не поддерживается!
        public void OnDeserialization(object o)
        {
            CalcMSG();
            FindTheBest();
        }

    }
}