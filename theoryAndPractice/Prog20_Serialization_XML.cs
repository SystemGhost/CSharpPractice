// Нам понадобятся следующие пространства имен
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;

/*
 *  СЕРИАЛИЗАЦИЯ В XML
 */


class Test
{
 static void Main()
    {
       /*Рассмотрим пример XML-сериализации. Будем сохранять в формате XML
данные классов Student и Group. При описании этих классов воспользуемся
некоторыми атрибутами. Ниже представлен код программы, выполняющей
создание объектов, сериализацию и десериализацию.*/
        Group g = new Group();
        g.GL.Add(new Student("Vova", 20, 4.5));
        g.GL.Add(new Student("Ira", 20, 5));
        g.GL.Add(new Student("Peter", 19, 4));

        Stream fs = new FileStream("data1.dat", FileMode.Create);
        // Указываем тип того объекта, который сериализуем
        XmlSerializer x = new XmlSerializer(typeof(Group));
        //Серелизуем
        x.Serialize(fs, g);
     //закрываем
        fs.Close();
     //Востанавливаем
        fs = new FileStream("data1.dat", FileMode.Open);

        Group d = (Group)x.Deserialize(fs);
        fs.Close();
        Console.ReadKey(true);
    }


 class Student
    {
        public string Name;
    [XmlAttribute("Age")]
        public int Age;
        public double MeanScore;

        public Student() { }
        public Student(string Name, int Age, double MeanScore)
        {
            this.Name = Name;
            this.Age = Age;
            this.MeanScore = MeanScore;
        }
    }

    [XmlRoot("StudentGroup")]
    [XmlInclude(typeof(Student))]
    class Group
    {
        [XmlArray("GroupList")]
        [XmlArrayItem("Student")]
        public ArrayList GL = new ArrayList();

        [XmlIgnore]
        public double MSG;
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

    }
}