using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InherPolyAbst.Program;

namespace InherPolyAbst
{
    internal class Program
    {
        public class Student
        {

            protected int ID;
            protected string Fname;
            protected string Lname;
            private List<int> Scores;

        public Student()
        {
            Console.WriteLine( "");
                this.Scores= new List<int>();
        }
            public Student(int ID, string Fname, string Lname)
            {
                this.ID = ID;
                this.Fname = Fname;
                this.Lname = Lname;
                this.Scores= new List<int>();
            }
            public virtual string FullName()
            {
                return string.Format("{0} {1}", this.Fname, this.Lname);
            }
            public void NewScore(int s)
            {
                this.Scores.Add(s);
            }
            public virtual int GetScore(int idx)
            {
                if (idx < 0 || idx >= this.Scores.Count)
                {
                    throw new Exception("Not a valid index");
                }
                return this.Scores[idx];
            }
        }
        public class GraduateStudent : Student
        {
            public string Thesis { get; set; }
            private string ReasonToChange;

            public GraduateStudent() : base(0 , "None","None")
            {
                Console.WriteLine("");
            }
            public GraduateStudent(int ID , string Fname , string Lname ) :base(ID,Fname,Lname)
            {
                Console.WriteLine("");

            }
            public string FullNameWithID()
            {
                string Result =string.Format("{0} {1}",this.ID ,  base.FullName());
                return Result;
            }
            public void ChangeThesis(string NewThesis)
            {
                Console.WriteLine("");
                this.Thesis = NewThesis;
            }
            public void ChangeThesis(string NewThesis,string Reason)
            {
                Console.WriteLine("");
                this.Thesis = NewThesis;
                this.ReasonToChange = Reason;
            }
            public override string ToString()
            {
                return string.Format("{0} {1} ", this.Lname, this.Fname);
            }
            public sealed override int GetScore(int idx)
            {
                return base.GetScore(idx);
            }
        }
        public class JUSTGradeuatStudent : GraduateStudent
        {
            public JUSTGradeuatStudent(int ID , string Fname , string Lname ):base(ID,Fname,Lname) { }

            public override string FullName()
            {
                return string.Format("{0} {1} ", this.Lname, this.Fname);
            }
        }
        public class UndergraduateStudent : Student
        {
            public UndergraduateStudent()
            {
                Console.WriteLine("");
            }
            public UndergraduateStudent(int ID, string Fname, string Lname)
                : base(ID, Fname, Lname)
            {
                Console.WriteLine("");
                //this.ID = ID;
            }
        }



        static void Main(string[] args)
        {
            Student S1 = new Student();
            Student S2 = new Student(1, "Qusai", "Tahat");
            Console.WriteLine(S2.FullName());
            Console.WriteLine("------------------------");
            UndergraduateStudent U1 = new UndergraduateStudent();
            U1.NewScore(10);
            Console.WriteLine(U1.GetScore(0));

            UndergraduateStudent U2 = new UndergraduateStudent(2, "Ibrahim", "Miqdadi");
            Console.WriteLine(U2.FullName());

            Console.WriteLine("----------------------");
            GraduateStudent G1 = new GraduateStudent(5, "Ibrahim", "Qusai");
            Console.WriteLine(G1.FullName());
            G1.NewScore(20);
            Console.WriteLine(G1.GetScore(0));
            Console.WriteLine(G1.FullNameWithID());
            G1.ChangeThesis("Programming languages");
            G1.ChangeThesis("Scripting languages", "I have more information about them.");

            Console.WriteLine("----------------------");
            JUSTGradeuatStudent J1 = new JUSTGradeuatStudent(10, "Rami", "Matarneh");
            Console.WriteLine(J1.FullName());
        }
    }
}
