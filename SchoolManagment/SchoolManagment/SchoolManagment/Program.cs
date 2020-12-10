using SchoolManagment.Models;
using System;

namespace SchoolManagment
{
    class Program
    {
        static void Main(string[] args)
        {
            var school = new School();

            Choose(school);
        }

        private static void Choose(School school)
        {
            
            Console.WriteLine("Choose:\n 1-Create Student\n 2-View All Students\n 3-Create Teacher\n 4-View All Teachers\n 5-Create Subject\n 6-View All Subjects\n 7-Add student to listen to chosen subject\n 8-Add teacher to teach chosen subject\n 9-See info about Teacher\n 10-See info about Student\n 11-See info about Subject\n");
            bool result = Int32.TryParse(Console.ReadLine(), out int choice);
            if (result)
            {
                switch (choice)
                {
                    case 1:
                        //Create Student
                        school.CreateStudent();
                        ChooseAgain(school);

                        break;
                    case 2:
                        //View All Students
                        school.ViewAllStudents();
                        ChooseAgain(school);
                        break;
                    case 3:
                        //Create Teacher
                        school.CreateTeacher();
                        ChooseAgain(school);

                        break;
                    case 4:
                        //View All Teachers
                        school.ViewAllTeachers();
                        ChooseAgain(school);
                        break;
                    case 5:
                        //Create Subject
                        school.CreateSubject();
                        ChooseAgain(school);

                        break;
                    case 6:
                        //View All Subjects
                        school.ViewAllSubjects();
                        ChooseAgain(school);

                        break;
                    case 7:
                        //Add student to listen to chosen subject
                        school.AddStudentToSubject();
                        ChooseAgain(school);
                        break;
                    case 8:
                        //Add teacher to teach chosen subject
                        school.AddTeacherToSubject();
                        ChooseAgain(school);
                        break;
                    case 9:
                        //Teacher Info
                        school.TeacherInfo();
                        ChooseAgain(school);
                        break;
                    case 10:
                        //Student Info
                        school.StudentInfo();
                        ChooseAgain(school);
                        break;
                    case 11:
                        //Subject Info
                        school.SubjectInfo();
                        ChooseAgain(school);
                        break;

                }

            }
            else
            {
                Console.WriteLine("Error: Invalid input");
            }
        }

        private static void ChooseAgain (School school)
        {
            Console.WriteLine("Do you want to choose again? Type y-Yes or n-No");
            if (Console.ReadLine().ToLower() == "y")
            {
                Choose(school);
            }
            else
            {
                Console.Clear();
            }
        }

    }
}
