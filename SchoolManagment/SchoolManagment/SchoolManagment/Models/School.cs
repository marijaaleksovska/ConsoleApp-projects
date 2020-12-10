using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagment.Models
{
    class School
    {
        public School()
        {
            Teachers = new List<Teacher>();
            Students = new List<Student>();
            Subjects = new List<Subject>();
        }
        public List<Teacher> Teachers { get; set; } 
        public List<Student> Students { get; set; }
        public List<Subject> Subjects { get; set; }

        public void CreateStudent()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Current Year: ");
            int year = int.Parse(Console.ReadLine());
            var student = new Student
            {
                ID = id,
                Name = name,
                Surname = surname,
                CurrentYear = year
            };


             Students.Add(student);
            
        }

        public void ViewAllStudents()
        {
            foreach (var student in Students)
            {
                student.Print();

            }
        }

        public void CreateTeacher()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            var teacher = new Teacher
            {
                ID = id,
                Name = name,
                Surname = surname
            };

            Teachers.Add(teacher);
            
        }

        public void AddStudentToSubject()
        {
            Console.Write("Student ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Subject Name: ");
            string name = Console.ReadLine();
            
            var student = new Student();
            var sub = new Subject();
            foreach (var s in Students)
            {
                if (s.ID == id)
                {
                    student = s;
                }

            }
            foreach (var subject in Subjects)
            {
                if (subject.Name == name)
                {
                    sub = subject;
                }
            }

            student.Subjects.Add(sub);
            
            
        }

        public void SubjectInfo()
        {
            Console.WriteLine("Subject Name: ");
            string name = Console.ReadLine();
            
            var subject = new Subject();
            foreach (var s in Subjects)
            {
                if (s.Name == name)
                {
                    subject = s;
                }

            }
            Console.WriteLine($"Subject Info:");
            subject.Print();
            Console.WriteLine("All  students learning it: ");
            foreach (var student in Students)
            {
                foreach (var sub in student.Subjects)
                {
                    if (sub.Name == name)
                    {
                        student.Print();

                    }

                }


            }

            var teacher = new Teacher();
            foreach (var t in Teachers)
            {
                foreach (var sub in t.Subjects)
                {
                    if (sub.Name == name)
                    {
                        teacher = t;
                    }

                }

            }
            Console.WriteLine($"Teacher teaching it: ");
            teacher.Print();

            
        }

        public void StudentInfo()
        {
            Console.WriteLine("Student`s ID: ");
            int id = int.Parse(Console.ReadLine());
           
            var student = new Student();
            foreach (var s in Students)
            {
                if (s.ID == id)
                {
                    student = s;
                }

            }
            Console.WriteLine("Student Info: ");
            student.Print();
            Console.WriteLine("Subjects Attending:");
            foreach (var subject in student.Subjects)
            {
                Console.WriteLine(subject.Name);

            }

            
        }

        public void TeacherInfo()
        {
            Console.WriteLine("Teacher`s ID: ");
            int id = int.Parse(Console.ReadLine());
            
            
            var teacher = new Teacher();
            foreach (var t in Teachers)
            {
                if (t.ID == id)
                {
                    teacher = t;
                }

            }
            Console.WriteLine("Teacher Info: ");
            teacher.Print();
            Console.WriteLine("Subjects Teaching:");
            foreach (var subject in teacher.Subjects)
            {
                Console.WriteLine(subject.Name);

            }

            
        }

        public void AddTeacherToSubject()
        {
            Console.Write("Teacher ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Subject Name: ");
            string name = Console.ReadLine();
            
            var teacher = new Teacher();
            var sub = new Subject();
            foreach (var t in Teachers)
            {
                if (t.ID == id)
                {
                    teacher = t;
                }

            }
            foreach (var subject in Subjects)
            {
                if (subject.Name == name)
                {
                    sub = subject;
                }
            }


            teacher.Subjects.Add(sub);



        }

        public void ViewAllSubjects()
        {
            foreach (var subject in Subjects)
            {
                subject.Print();

            }
        }

        public void CreateSubject()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            var subject = new Subject
            {
                Name = name
            };


            Subjects.Add(subject);

         }

        public void ViewAllTeachers()
        {
            foreach (var teacher in Teachers)
            {
                teacher.Print();
            }
        }
    }
}
