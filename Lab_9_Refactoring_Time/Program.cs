// ===============================
// AUTHOR     : Jonathan Lubaway
// CREATE DATE: October 23rd, 2019
// PURPOSE    : Improve your student information system from the previous lab by using a collection.
// ===============================
using System;
using System.Collections.Generic;

namespace Lab_8_Get_To_Know_Your_Classmates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call the Classmate info Method
            GetClassMateInfo();
        }

        // This method defines and sets up a class with info about them
        public static void GetClassMateInfo()
        {

            // Sets up a two-dimensional list that represents the class and their interests

            List<string> vince = new List<string>
            {
                "Vince",
                "Fajitas",
                "Physical Education",
                "Basketball",
                "Blue"
            };
            List<string> spinelli = new List<string>
            {
                "Spinelli",
                "Fries",
                "Band",
                "Playing Guitar",
                "Red"
            };
            List<string> mikey = new List<string>
            {
                "Mikey",
                "Spaghetti",
                "History",
                "Reading",
                "Green"
            };
            List<string> tj = new List<string>
            {
                "T.J.",
                "Burgers",
                "Math",
                "Hanging with friends",
                "Yellow"
            };
            List<string> gretchen = new List<string>
            {
                "Gretchen",
                "Sandwiches",
                "Science",
                "Chemistry",
                "Purple"
            };
            List<string> gus = new List<string>
            {
                "Gus",
                "Roast Lamb",
                "Art",
                "Drawing",
                "Orange"
            };

            List<List<string>> classmates = new List<List<string>>
            {
                vince,
                spinelli,
                mikey,
                tj,
                gretchen,
                gus
            };

            Console.WriteLine("Welcome to our class. Our students are: ");
            for (int i = 0; i < classmates.Count; i++)
            {
                Console.WriteLine($"{i+1}: {classmates[i][0]}");
            }

            int currentStudent = -1;

            string check = ParseLife("Would you rather use a students \"number\" or \"name\"");

            currentStudent = ParseStudent(check, classmates.Count);

            ValidateInput(classmates[currentStudent]);

            Console.WriteLine();
            GetContinue();
        }

        // This determines whether someone wants to look up a student by name or number
        public static int ParseStudent(string check, int max)
        {
            int currentStudent = 0;

                switch (check)
                {
                    case "number":
                        currentStudent = ParseRange(1, max, "Which student would you like to know more about? " +
                          $"(Enter a number from 1-6)") - 1;

                        break;
                    case "name":
                        currentStudent = ParseName("Which student would you like to know more about? " +
                             "(Enter a name)");
                        break;
                    default:
                        break;
                }

            return currentStudent;
        }

        // This method prompts the user to get some information
        public static string GetUserInput(string message)
        {
            Console.Write(message + " ");
            string input = Console.ReadLine();
            Console.WriteLine();
            if (input.Length == 0)
            {
                Console.WriteLine("Please input a valid string.");
                return GetUserInput(message);
            }
            return input;
        }

        // This method takes information from the user and makes sure it is an integer and is in range
        public static int ParseRange(int min, int max, string message)
        {
            // This try catch makes sure that whatever the user inputs is an integer
            try
            {
                int number = int.Parse(GetUserInput(message));

                // This if statement makes sure that the number is within range
                if (number >= min && number <= max)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine($"Not within the range given.({min}-{max})\n");
                    return ParseRange(min, max, message);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a number.\n");
                return ParseRange(min, max, message);
            }
        }

        // This method makes sure the user calls the correct name
        public static int ParseName(string message)
        {
            string name = GetUserInput(message);
            int student = -1;
            switch (name)
            {
                case "Vince":
                    student = 0;
                    break;
                case "Spinelli":
                    student = 1;
                    break;
                case "Mikey":
                    student = 2;
                    break;
                case "T.J.":
                    student = 3;
                    break;
                case "Gretchen":
                    student = 4;
                    break;
                case "Gus":
                    student = 5;
                    break;
                default:
                    Console.WriteLine("Please enter a valid name.\n");
                    return ParseName(message);
            }
            return student;
        }

        // This method makes sure the answer to the favorites question is valid
        public static void ValidateInput(List<string> student)
        {
            // Prompts the user to pick a topic they want to know about a classmate
            string favorites = GetUserInput($"What would you like to know about them? " +
                                            $"(Enter \"food\", \"subject\", \"hobby\", or \"color\")");

            switch (favorites)
            {
                case "food":
                    Console.WriteLine($"{student[0]}'s favorite food is " + student[1]);
                    break;
                case "subject":
                    Console.WriteLine($"{student[0]}'s favorite subject is " + student[2]);
                    break;
                case "hobby":
                    Console.WriteLine($"{student[0]}'s favorite hobby is " + student[3]);
                    break;
                case "color":
                    Console.WriteLine($"{student[0]}'s favorite hobby is " + student[4]);
                    break;
            }

            GetContinueStudent(student);
        }

        public static void GetContinueStudent(List<string> student)
        {
            string input = GetUserInput("Do you want to continue with the current student? (y/n)");
            if (input == "y")
            {
                ValidateInput(student);
            }
            else if (input == "n")
            {
                Console.WriteLine("Thank you!");
            }
            else
            {
                GetContinue();
            }
        }

        // This method checks to see if the user wants to run through the program again
        public static void GetContinue()
        {
            string input = GetUserInput("Do you want to look at or add another classmate? (y/n)");
            if (input == "y")
            {
                GetClassMateInfo();
            }
            else if (input == "n")
            {
                Console.WriteLine("Thank you!");
            }
            else
            {
                GetContinue();
            }

        }

        // This method determines whether this program should be longer or not
        public static string ParseLife(string message)
        {
            string check = GetUserInput(message);
            switch (check)
            {
                case "name":
                    return check;
                case "number":
                    return check;
                default:
                    Console.WriteLine("Please return \"name\" or \"number\".\n");
                    return ParseLife(message);
            }
        }

        public static List<string> AddNewStudent()
        {
            List<string> student = new List<string>();
            student.Add(GetUserInput("What is the student's favorite food?"));
            student.Add(GetUserInput("What is the student's favorite color?"));
            student.Add(GetUserInput("What is the student's name?"));
            student.Add(GetUserInput("What is the student's favorite subject?"));
            student.Add(GetUserInput("What is the student's favorite hobby?"));
            return student;
        }
    }
}
