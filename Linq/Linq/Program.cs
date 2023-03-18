using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Program
    {
        public class student {
        
            public int id { get; set; }
            public string Fname { get; set; }
            public string Lname { get; set; }
            public int Age { get; set; }
            public student(int id, string Fname, string Lname, int Age)
            {
                this.id = id;
                this.Fname = Fname;
                this.Lname = Lname;
                this.Age = Age;
            }
            public override string ToString()
            {
                return string.Format("{0}: {1} {2} [{3}]" , this.id ,this.Fname ,this.Lname,this.Age);
            }
        }
        public static void QuereyStudents()
        {
            // 1)create 5 Student object
            student s1 = new student(1, "Qusai", "Tahat", 22);
            student s2 = new student(2, "Shaden", "Obedat", 20);
            student s3 = new student(3, "Hussien", "Mahasneh", 20);
            student s4 = new student(4, "Dalia", "Ababneh", 20);
            // 2)data source
            student[] students=new student[] { s1, s2, s3, s4 };
            // 3)create LINQ query
            var q3 = from Row in students
                     select Row;
            // 4)Execute the LINQ query
            foreach ( student s in q3 ) {
                Console.WriteLine(s);
            }

        }
        public static void QuereyStudentsWhithWhere()
        {
            student s1 = new student(1, "Qusai", "Tahat", 22);
            student s2 = new student(2, "Shaden", "Obedat", 20);
            student s3 = new student(3, "Hussien", "Mahasneh", 20);
            student s4 = new student(4, "Dalia", "Ababneh", 20);
            student[] students = new student[] { s1, s2, s3, s4 };

            var q3 = from Row in students
            where Row.id == 1 || Row.Lname=="Tahat" || Row.Age >20  || Row.Fname.StartsWith("H")
                     select Row;
            Console.WriteLine("Array and List of object where Id=1 , Lanme=Tahat , Age > 20 and Row with start H");
            foreach (student s in q3)
            {
                Console.WriteLine(s);
            }

        }
        public static void QuereyStudentsWhithSelect()
        {
            student s1 = new student(1, "Qusai", "Tahat", 22);
            student s2 = new student(2, "Shaden", "Obedat", 20);
            student s3 = new student(3, "Hussien", "Mahasneh", 20);
            student s4 = new student(4, "Dalia", "Ababneh", 20);
            student[] students = new student[] { s1, s2, s3, s4 };

            var q3 = from Row in students
                     where Row.Age <= 20 && (Row.Fname.StartsWith("H") || Row.Lname.EndsWith("t"))
                     select string.Format("{0} {1} ", Row.Fname, Row.Lname);
            Console.WriteLine("Array and List of object where  Row with start Fname  H and Row  Lname Ends t");
            foreach (string s  in q3)
            {
                Console.WriteLine(s);
            }

        }
        public static void QuereyStudentsWhithSelectnew()
        {
            student s1 = new student(1, "Qusai", "Tahat", 22);
            student s2 = new student(2, "Shaden", "Obedat", 20);
            student s3 = new student(3, "Hussien", "Mahasneh", 20);
            student s4 = new student(4, "Dalia", "Ababneh", 20);
            student[] students = new student[] { s1, s2, s3, s4 };

            var q3 = from Row in students
                     where Row.Age <= 20 && (Row.Fname.StartsWith("H") || Row.Lname.EndsWith("t"))
                     select new { First = Row.Fname , Last = Row.Lname };
            Console.WriteLine("Array and List of object where  Row with start Fname  H and Row  Lname Ends t\nAnd Select new");
            foreach (object s in q3)
            {
                Console.WriteLine(s);
            }

        }

        public static void QuereyNumbers()
        {
            // Create an array of integers as a data source 
            // Create a List of integer numbers
            // not difference
            int[] Number = new int[] { 1, 2, 3, 5, 6, 7, 8, 9 };
            //List<int> Number = new List<int> { 1, 2, 3 ,5,6,7,8,9};
            // 2.Create LINQ querey 

            var q1 = from Num in Number
                     select Num;
            //3.Execute the LINQ querey
            Console.WriteLine("--------------Queerey Numbers With Integer-----------");
            foreach (int n in q1)
            {
                Console.Write("{0} ", n);

            }
            Console.WriteLine();
        }
        public static void QuereyNumbersWhithWhere()
        {          
            List<int> Number = new List<int> { 0,1, 2, 3 ,4,5,6,7,8,9};
            var q1 = from Num in Number
                     where Num > 3
                     select Num;
            Console.WriteLine("--------------Queerey Numbers Where number > 3 -----------");
            foreach (int n in q1)
            {
                Console.Write("{0} ", n);

            }
            Console.WriteLine();
            Console.WriteLine("--------------Queerey Numbers Where number Even -----------");
            var q2 = from Num in Number
                     where ((Num %2) == 0) //even number we can add a conditon ( && ) , ( || )
                     select Num;
            foreach (var i in q2)
            {
                Console.Write("{0} ",i);
            }
            Console.WriteLine();

        }
        public static void QuereyNumbersWhithSelect()
        {
            int[] Number = new int[] { 1, 2, 3, 5, 6, 7, 8, 9 };
            var q1 = from Num in Number
                     select Num*2;
            Console.WriteLine("--------------Queerey Numbers With Selcet Key Word Select (Num*2)-----------");
            foreach (int n in q1)
            {
                Console.Write("{0} ", n);

            }
            Console.WriteLine();
        }
        public static void QuereyNames()
        {
            string[] Names = new string[] { "Qusai", "Ibrahim", "Nadine", "Samera" };
            List<string> names = new List<string>() { "Qusai", "Ibrahim", "Nadine", "Samera" };
            var q2 = from string Row in Names
                     select Row;
            Console.WriteLine("--------------Queerey Names With String--------------");

            foreach (String item in q2)
            {
                Console.WriteLine("{0} ",item);
            }
        }
        public static void QuereyNamesWithWhere()
        {
            List<string> names = new List<string>() { "Qusai", "Ibrahim", "Nadine", "Samera" };
            var q2 = from string Row in names
                     where Row.StartsWith("Q") || Row.EndsWith("m") || Row.Length== 6
                     select Row;
            Console.WriteLine("--------------Queerey Names Where Row start with Q and Row Ends with m  and Row Length = 6 --------------");

            foreach (String item in q2)
            {
                Console.WriteLine("{0} ", item);
            }
        }
        public static void QuereyNamesWithSelect()
        {
            List<string> names = new List<string>() { "Qusai", "Ibrahim", "Nadine", "Samera" };
            var q2 = from string Row in names
                     select Row.ToUpper();
            Console.WriteLine("--------------Queerey Names With Selcet Row Start UpperCase --------------");

            foreach (String item in q2)
            {
                Console.WriteLine("{0} ", item);
            }
        }


        static void Main(string[] args)
            {
            Console.WriteLine("----------------------------------------------\n3 GuideLine foe LinQ");
            Console.WriteLine("1.Obtin the Data sources\n2.Create LINQ querey\n3.Execute LINQ querey\n----------------------------------------------");
            Console.WriteLine("Create And Execute a LINQ query\n1)Array and List\n2)Integer and string element");
            QuereyNumbers();
            QuereyNames();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Array and List of object");
            QuereyStudents();
            QuereyNumbersWhithWhere();
            QuereyNamesWithWhere();
            Console.WriteLine("----------------------------------------------");
            QuereyStudentsWhithWhere();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Select KeyWord");
            QuereyNumbersWhithSelect();
            QuereyNamesWithSelect();
            Console.WriteLine("----------------------------------------------");
            QuereyStudentsWhithSelect();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("How to Return New Object");
            QuereyStudentsWhithSelectnew();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("OrderBy");
            Console.WriteLine("Just write orderby Row After where Lines ");
            Console.WriteLine("----------------------------------------------");



        }
    }
}


