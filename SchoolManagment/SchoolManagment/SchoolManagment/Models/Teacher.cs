using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagment.Models
{
    class Teacher
    {
        public Teacher()
        {
            Subjects = new List<Subject>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Subject> Subjects { get; set; } 
        public void Print()
        {
            Console.WriteLine($"{ID} {Name} {Surname}");
        }
    }
}
