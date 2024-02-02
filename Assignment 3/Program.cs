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
            DisplayMenu();
            while (true)
            {
                
                switch
                break;
            }
            Console.ReadLine();
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
        }
    }
    
}
