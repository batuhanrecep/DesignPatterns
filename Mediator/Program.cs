using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Mediator design pattern centralizes communication between objects by having them interact through a mediator object,
            //reducing direct dependencies and promoting loose coupling, which simplifies complex interactions and enhances maintainability.

            Mediator mediator = new Mediator();
            Teacher kaan = new Teacher(mediator);
            kaan.Name = "Kaan";
            mediator.Teacher = kaan;
            Student su = new Student(mediator);
            su.Name = "Su";
            su.Name = "Su";
            Student nil = new Student(mediator);
            nil.Name = "Nil";
            mediator.Students = new List<Student> { nil, su };

            kaan.SendNewImageUrl("slide1.jpg");
            kaan.RecieveQuestion("Is it true",nil);

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {
        }
        public string Name { get; set; }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher received a question from {0}, question: {1}",student.Name,question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide: {0}",url);
            Mediator.UpdateImage(url);
        }

        public void AnserQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}",student.Name,answer);
        }
        
    }

    class Student:CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }
        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} received image: {0}",url,Name);
        }

        public void ReceieveAnswer(string answer)
        {
            Console.WriteLine("{1} received answer: {0}", answer, Name);
        }

        public string Name { get; set; }

        
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question,student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReceieveAnswer(answer);
        }
    }
}
