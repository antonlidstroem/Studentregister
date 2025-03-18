using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentregister
{
    internal class UI
    {
        public StudentRegister register { get; set; }
        public UI()
        {
            register = new StudentRegister();
            HandleMenu();
        }
        private void HandleMenu()
        {
            int choice;

            do
            {
                printMenu();
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: // Registrera ny student
                        register.NewStudent();
                        break;
                    case 2:// Ändra student
                        register.EditStudent();
                        break;
                    case 3: //Avregistrera student
                        register.RemoveStudent();
                        break;
                    case 4: // Lista alla studenter
                        ShowAllStudents();
                        break;
                    case 5: // Lista alla studenter
                        register.RemoveAllStudents();
                        break;
                    default:
                        break;
                }
                if (choice != 0)
                {
                    BackToMenu();
                }
            } while (choice != 0);
        }
        private void BackToMenu()
        {
            Console.WriteLine("Tryck enter för att fortsätta till menyn.");
            Console.ReadLine();
            Console.Clear();
        }
        private void ShowAllStudents()
        {
            Console.Clear();

            foreach (Student s in register.GetAllStudents())
            {
                Console.WriteLine($"ID: {s.StudentId}");
                Console.WriteLine($"Förnamn: {s.FirstName}");
                Console.WriteLine($"Efternamn: {s.LastName}");
                Console.WriteLine($"Stad: {s.City}");
                Console.WriteLine();
            }
        }
        internal void printStudentChoice(Student tempStudent)
        {
            Console.WriteLine("Du har valt:");
            Console.WriteLine($"ID: {tempStudent.StudentId}");
            Console.WriteLine($"Förnamn: {tempStudent.FirstName}");
            Console.WriteLine($"Efternamn: {tempStudent.LastName}");
            Console.WriteLine($"Stad: {tempStudent.City}");
            Console.WriteLine();
        }
        private void printMenu()
        {
            Console.WriteLine("MENY");
            Console.WriteLine("1. Registrera student");
            Console.WriteLine("2. Ändra student");
            Console.WriteLine("3. Avregistrera student");
            Console.WriteLine("4. Lista alla studenter");
            Console.WriteLine("5. Avregistrera alla studenter");
            Console.WriteLine("0. Avsluta");
            Console.WriteLine("Gör ditt val: ");
        }
    }
}
