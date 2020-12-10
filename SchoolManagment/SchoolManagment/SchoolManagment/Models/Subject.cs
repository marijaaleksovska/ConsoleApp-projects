using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagment.Models
{
    class Subject
    {
        public string Name { get; set; }
        public void Print()
        {
            Console.WriteLine($"{Name}");
        }

    }
}
