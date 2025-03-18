using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;

namespace Studentregister
{
    public class StudentRegister
    {
        private StudentDbContext dbCtx;
        private UI UI;

        public StudentRegister()
        {
            dbCtx = new StudentDbContext();
        }
        internal void AddStudent(Student s)
        {
            dbCtx.Add(s);
            Save();
        }
        internal void Save()
        {
            dbCtx.SaveChanges();
        }
        internal List<Student> GetAllStudents()
        {
            return dbCtx.Students.ToList();
        }
        internal Student GetStudent(int id)
        {
            List<Student> tempListOfStudents = dbCtx.Students.ToList();

            Student tempStudent = null;

            foreach (Student s in tempListOfStudents)
            {
                if (s.StudentId == id)
                {
                    tempStudent = s;
                }
            }
            return tempStudent;
        }
        internal Student UserPickStudent()
        {
            Console.WriteLine("Fyll i ID på den student du vill ändra");
            return GetStudent(Convert.ToInt32(Console.ReadLine()));

        }
        internal void EditStudent()
        {
            Student tempStudent;
            try
            {
                tempStudent = UserPickStudent();

                Console.WriteLine("Vill du ändra förnamn, efternamn eller stad? (skriv med gemener))");
                string choice2 = Console.ReadLine();
                Console.WriteLine("Fyll i vad du vill ersätta värdet med:");
                string choice3 = Console.ReadLine();

                if (tempStudent != null) { 
                if (choice2 == "förnamn")
                {
                    tempStudent.FirstName = choice3;
                }
                else if (choice2 == "efternamn")
                {
                    tempStudent.LastName = choice3;
                }
                else if (choice2 == "stad")
                {
                    tempStudent.City = choice3;
                }
            }
            else {
                Console.WriteLine("Felaktig inmatning");
            }

                Save();
            }
            catch (Exception)
            {
                Console.WriteLine("Felaktig inmatning");
            }
        }
        internal void NewStudent()
        {
            Console.WriteLine("Fyll i förnamn:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Fyll i efternamn:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Fyll i stad:");
            string city = Console.ReadLine();

            Student s = new Student(firstName, lastName, city);
            AddStudent(s);
        }
        internal void RemoveStudent()
        {
            Student tempStudent = UserPickStudent();
            try
            {
                dbCtx.Students.Remove(tempStudent);
                Save();
            }
            catch (Exception)
            {
                Console.WriteLine("Felaktig inmatning");
            }
        }
        internal void RemoveAllStudents()
        {
            dbCtx.RemoveRange(dbCtx.Students);
            Save();
        }
    }
}
