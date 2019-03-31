using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MyStudent
{
    class ClasProgram
    {
        static void Main(string[] args)
        {
           
            Student[] St = { new Student("Olay",MyPerson.Sex.women,new DateTime(1999,3,5), "1234778s",100),
                new Student("Voloday",MyPerson.Sex.men,new DateTime(2000,6,5), "1764356s",15),
                new Student("Stepan",MyPerson.Sex.men,new DateTime(1994,9,5), "123789s",69),
                new Student("Iryna",MyPerson.Sex.women,new DateTime(1959,5,5), "187634s",88),
                new Student("Solomay",MyPerson.Sex.women,new DateTime(2015,3,16), "123567s",78) };
            Random random = new Random();
            for (int i = 0; i < St.Length; ++i)
            {
                for (int j = 0; j < Student.Subjects; ++j)
                {
                    St[i][j] = random.Next(51, 100);
                    
                }
            }
            foreach (var f in St)
            {
                Console.WriteLine("{0} has MaxVlue {1}\n has SumPoint {2} \n has AveragePoint {3}",
                    f, f.MaxVlue(), f.SumPoint(), f.AveragePoint());

            }
            Console.ReadLine();
            Console.WriteLine("Point");
            foreach (var x in St[0])
            {
                    Console.WriteLine(x);
                
            }

            Array.Sort(St);
            Console.WriteLine("Sort");
            foreach (Student f in St) Console.WriteLine(f);
            Console.ReadLine();
            
            Console.WriteLine("C = " + St  );
            
            Console.ReadLine();
        }
        class MyPerson                            //батьківський клас
        {
            public enum Sex { men, women, none };
            protected string name;
            protected Sex sex;
            protected DateTime data;
            public string Name
            {
                get
                {
                    return name;
                }

                set
                {
                    name = value;
                }
            }
            public Sex Sexx
            {
                get
                {
                    return sex;
                }

                set
                {
                    sex = value;
                }
            }
            public DateTime Data
            {
                get
                {
                    return data;
                }

                set
                {
                    data = value;
                }
            }
            public MyPerson()   //конструктор за замовчуванням
            {
                this.name = " Noname ";
                this.sex = Sex.none;
                this.data = new DateTime(1999, 2, 21);
            }
            public MyPerson(string a, Sex b, DateTime c)    //конструктор з параметрами
            {
                name = a;
                sex = b;
                data = c;
            }
            public override string ToString()
            {
                return string.Format("MyPerson [ {0} - {1} - {2}]\n", name, sex, data);
            }
        }

        class Student : MyPerson, IEnumerable, IComparable    //клас-нащадок
        {
            static string[] Subject;
            public const int Subjects = 5;
            int[] point;

            int amount;
            public string BookID;

            public string BOOKID
            {
                get
                {
                    return BookID;
                }

                set
                {
                    BookID = value;
                }
            }
            static Student()      //конструктор за замовчуванням
            {
                Subject = new string[Subjects]
                { "Mathematics", "Programming", "Algorithms","English","Statistics"};

            }
            public Student(string name, Sex sex, DateTime data, string bookID, int pointt)    //конструктор з параметрами
            : base(name, sex, data)                                                  
            {
                this.BookID = bookID;
                this.point = new int[Subjects];
                this.amount = 0;

            }


            public void showPoint()   //метод для виведення оцінок 
            {
                for (int i = 0; i < point.Length; ++i)
                {
                    Console.WriteLine("{0}:{1}", Subject[i], point[i]);
                }
            }
            public int this[string s]
            {
                get
                {
                    int p = Array.IndexOf(Subject, s);
                    return point[p];

                }
                set
                {
                    int p = Array.IndexOf(Subject, s);
                    point[p] = value;
                }
            }
            public int this[int i]
            {
                get
                {
                    return point[i];
                }
                set
                {
                    if (value >= 0 && value <= 100)
                        point[i] = value;
                    else throw new Exception("Error");
                }
            }
            public double MaxVlue()    //обчислення найбільшої оцінки 
            {
                int max = int.MinValue;
                for (int i = 0; i < point.Length; i++)
                    if (point[i] > max)
                    {
                        max = point[i];
                    }
                return max;

            }
            public void AddPoint(int mark, int k)
            {
                point[k] += mark;
            }
            public static Student operator +(Student c1, int p)
            {
                c1.AddPoint(p, 0);
                return c1;
            }
            public static bool operator >(Student c1, Student c2)
            {
                return c1.AveragePoint() > c2.AveragePoint();
            }
            public static bool operator <(Student c1, Student c2)
            {
                return c1.AveragePoint() < c2.AveragePoint();
            }

            public double AveragePoint()  //обчислення середнього арефметичного
            {
                int sum = 0;
                for (int i = 0; i < point.Length; i++)
                    sum += point[i];
                return sum / point.Length;
            }
            public double SumPoint()      //сумування оцінок
            {
                int sum = 0;
                for (int i = 0; i < point.Length; i++)
                    sum += point[i];
                return sum;
            }
            public IEnumerator GetEnumerator() 
            {
                return point.GetEnumerator();
            }

            public int CompareTo(object obj)
            {
                return this.AveragePoint().CompareTo((obj as Student).AveragePoint());
            }
            
        }
       

    }
