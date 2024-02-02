using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_3
{
    internal class Program
    {
        class Student
        {
            public int id;
            public string name;
            public int age;
            public string address;
            public float gpa;
            public Student(int idInit, string nameInit, int ageInit, string addressInit, float gpaInit)
            {
                id = idInit;
                name = nameInit;
                age = ageInit;
                address = addressInit;
                gpa = gpaInit;
            }
        }
        static void Main(string[] args)
        {
            string studentFolderName = "students";
            bool running = true;
            string chooseText = "Please Choose: ";

            while (running)
            {
                DisplayMenu();
                Console.Write(chooseText);
                switch (SanitizeIntInput())
                {
                    case 1:
                        CreateStudent(studentFolderName);
                        break;
                    case 2:
                        Console.Write("Please input ID: ");
                        EditStudent(SanitizeIntInput(), studentFolderName);
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:
                        ViewAllStudents(studentFolderName);
                        break;
                    case 0:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid option, try again.");
                        break;
                }
            }
        }
        static void DisplayMenu()
        {
            using (StreamReader file = File.OpenText("menu.txt"))
            {
                string textLine = file.ReadLine();
                while (textLine != null)
                {
                    Console.WriteLine(textLine);
                    textLine = file.ReadLine();
                }
            }
        }
        static int SanitizeIntInput()
        {
            bool finished = false;
            string input = "";
            int intInput = 0;
            while (!finished)
            {
                input = Console.ReadLine();
                finished = int.TryParse(input, out intInput);
                if (!finished)
                {
                    Console.WriteLine("Invalid input, please enter a whole number.");
                }
            }
            return intInput;
        }
        static string SanitizeStringInput(string failString = "")
        {
            bool finished = false;
            string input = "";
            while (!finished)
            {
                input = Console.ReadLine();
                if(input == "")
                {
                    Console.WriteLine("Invalid input, please input a string.");
                    Console.Write(failString);
                }
                else
                {
                    finished = true;
                    Console.Write(failString);
                }
            }
            return input;
        }
        static float SanitizeFloatInput(string failString = "")
        {
            bool finished = false;
            string input = "";
            float floatInput = 0f;
            while (!finished)
            {
                input = Console.ReadLine();
                finished = float.TryParse(input, out floatInput);
                if (!finished)
                {
                    Console.WriteLine("Invalid input, please input float.");
                    Console.Write(failString);
                }
            }
            return floatInput;
        }
        static void CreateStudent(string studentFolderName)
        {
            int id = 0;
            string name;
            int age;
            string address;
            float gpa;
            Console.Write("Input Student Name: ");
            name = SanitizeStringInput();
            Console.WriteLine("");
            Console.Write("Input Student Age: ");
            age = SanitizeIntInput();
            Console.WriteLine("");
            Console.Write("Input Student Address: ");
            address = SanitizeStringInput();
            Console.WriteLine("");
            Console.Write("Input Student GPA: ");
            gpa = SanitizeFloatInput();
            Console.WriteLine("");

            while (true)
            {
                if (File.Exists($"{studentFolderName}\\{id}"))
                {
                    id++;
                }
                else
                {
                    using(StreamWriter file = new StreamWriter($"{studentFolderName}\\{id}"))
                    {
                        file.WriteLine(id); file.WriteLine(name); file.WriteLine(age); file.WriteLine(address); file.WriteLine(gpa);
                    }
                    break;
                }
            }

        }
        static void ViewAllStudents(string studentFolderName)
        {
            Console.WriteLine("ID |  Name |  Age |  Address |  GPA");
            foreach(string file in Directory.GetFiles(studentFolderName))
            {
                using (StreamReader sr = new StreamReader(file))
                { 
                    Console.WriteLine($"  {sr.ReadLine()} |  {sr.ReadLine()} |  {sr.ReadLine()} |  {sr.ReadLine()} |  {sr.ReadLine()}");
                }
            }
        }
        static void EditStudent(int id, string studentFolderName)
        {
            if (!File.Exists($"{studentFolderName}\\{id}"))
            {
                Console.WriteLine("Id does not exist!");
                return;
            }
            string oldName = "";
            int oldAge = 0;
            string oldAddress = "";
            float oldGpa = 0;
            string name;
            int age;
            string address;
            float gpa;
            using (StreamReader sr = new StreamReader($"{studentFolderName}\\{id}"))
            {
                sr.ReadLine();
                oldName = sr.ReadLine();
                int.TryParse(sr.ReadLine(), out oldAge);
                oldAddress = sr.ReadLine();
                float.TryParse(sr.ReadLine(), out oldGpa);
            }

            Console.WriteLine($"Old Name was {oldName}");
            Console.Write("Enter new name: ");
            name = SanitizeStringInput();
            Console.Write("Enter new Age: ");
            age = SanitizeIntInput();
            Console.Write("Enter new Address: ");
            address = SanitizeStringInput();
            Console.Write("Enter new GPA: ");
            gpa = SanitizeFloatInput();

            File.Delete(($"{studentFolderName}\\{id}"));
            using(StreamWriter sw = new StreamWriter($"{studentFolderName}\\{id}"))
            {
                sw.WriteLine(id);
                sw.WriteLine(name);
                sw.WriteLine(age);
                sw.WriteLine(address);
                sw.WriteLine(gpa);
            }

        }
    }
    
}
