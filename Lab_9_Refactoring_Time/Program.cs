// ===============================
// AUTHOR     : Jonathan Lubaway
// CREATE DATE: October 23rd, 2019
// PURPOSE    : Improve your student information system from the previous lab by using a collection.
// ===============================
using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab_8_Get_To_Know_Your_Classmates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sets up the StudentInfo classes with info also I apologize if this is not correct I have not done classes in a while

            StudentInfo vince = new StudentInfo();
            vince.StudentName = "Vince";
            vince.FavoriteFood = "Fajitas";
            vince.FavoriteSubject = "Physical Education";
            vince.FavoriteHobby = "Basketball";
            vince.FavoriteColor = "Blue";

            StudentInfo spinelli = new StudentInfo();
            spinelli.StudentName = "Spinelli";
            spinelli.FavoriteFood = "Fries";
            spinelli.FavoriteSubject = "Band";
            spinelli.FavoriteHobby = "Playing Guitar";
            spinelli.FavoriteColor = "Red";

            StudentInfo mikey = new StudentInfo();
            mikey.StudentName = "Mikey";
            mikey.FavoriteFood = "Spaghetti";
            mikey.FavoriteSubject = "History";
            mikey.FavoriteHobby = "Reading";
            mikey.FavoriteColor = "Green";

            StudentInfo tj = new StudentInfo();
            tj.StudentName = "T.J.";
            tj.FavoriteFood = "Burgers";
            tj.FavoriteSubject = "Math";
            tj.FavoriteHobby = "Hanging with friends";
            tj.FavoriteColor = "Yellow";

            StudentInfo gretchen = new StudentInfo();
            gretchen.StudentName = "Gretchen";
            gretchen.FavoriteFood = "Sandwiches";
            gretchen.FavoriteSubject = "Science";
            gretchen.FavoriteHobby = "Chemistry";
            gretchen.FavoriteColor = "Purple";

            StudentInfo gus = new StudentInfo();
            gus.StudentName = "Gus";
            gus.FavoriteFood = "Roast Lamb";
            gus.FavoriteSubject = "Art";
            gus.FavoriteHobby = "Drawing";
            gus.FavoriteColor = "Orange";


            // A list with the student info classes
            List<StudentInfo> classmates = new List<StudentInfo>
            {
                vince,
                spinelli,
                mikey,
                tj,
                gretchen,
                gus
            };

            // Call the Classmate info method
            GetClassmateInfo(classmates);
        }

        // This method defines and sets up a class with info about them
        public static void GetClassmateInfo(List<StudentInfo> classmates)
        {
            classmates.Sort(SortClass);

            // Prints the current students to the console
            Console.WriteLine("Welcome to our class. Our students are: ");
            for (int i = 0; i < classmates.Count; i++)
            {
                Console.WriteLine($"{i+1}: {classmates[i].StudentName}");
            }

            bool addLook = AddOrKnow();

            if (!addLook)
            {
                int currentStudent = -1;

                string check = ParseLife("Would you rather use a students \"number\" or \"name\"");

                currentStudent = ParseStudent(check, classmates.Count, classmates);

                ValidateInput(classmates[currentStudent]);
            } else
            {
                classmates.Add(AddNewStudent());
            }
            Console.WriteLine();
            GetContinue(classmates);
        }

        public static bool AddOrKnow()
        {
            string check = GetUserInput("Do you want to add a student or know more about one? (\"add\" or \"know\")");
            if (check == "add")
            {
                return true;
            }
            return false;
        }

        // This determines whether someone wants to look up a student by name or number
        public static int ParseStudent(string check, int max, List<StudentInfo> classmates)
        {
            int currentStudent = 0;

                switch (check)
                {
                    case "number":
                        currentStudent = ParseRange(1, max, "Which student would you like to know more about? " +
                          $"(Enter a number from 1-{max})") - 1;

                        break;
                    case "name":
                        currentStudent = ParseName("Which student would you like to know more about? " +
                             "(Enter a name)", classmates);
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
        public static int ParseName(string message, List<StudentInfo> classmates)
        {
            string name = GetUserInput(message);

            for (int i = 0; i < classmates.Count; i++)
            {
                if (classmates[i].StudentName.ToLower() == name.ToLower())
                {
                    return i;
                }
            }

            Console.WriteLine("Please enter a valid name.");

            return ParseName(message, classmates);
        }

        // This method makes sure the answer to the favorites question is valid
        public static void ValidateInput(StudentInfo student)
        {
            // Prompts the user to pick a topic they want to know about a classmate
            string favorites = GetUserInput($"What would you like to know about them? " +
                                            $"(Enter \"food\", \"subject\", \"hobby\", or \"color\")");

            switch (favorites)
            {
                case "food":
                    Console.WriteLine($"{student.StudentName}'s favorite food is " + student.FavoriteFood);
                    break;
                case "subject":
                    Console.WriteLine($"{student.StudentName}'s favorite subject is " + student.FavoriteSubject);
                    break;
                case "hobby":
                    Console.WriteLine($"{student.StudentName}'s favorite hobby is " + student.FavoriteHobby);
                    break;
                case "color":
                    Console.WriteLine($"{student.StudentName}'s favorite color is " + student.FavoriteColor);
                    break;
            }

            GetContinueStudent(student);
        }

        // This method sees if a user wants to continue with the current student
        public static void GetContinueStudent(StudentInfo student)
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
                GetContinueStudent(student);
            }
        }

        // This method checks to see if the user wants to run through the program again
        public static void GetContinue(List<StudentInfo> classmates)
        {
            string input = GetUserInput("Do you want to look at or add another classmate? (y/n)");
            if (input == "y")
            {
                GetClassmateInfo(classmates);
            }
            else if (input == "n")
            {
                Console.WriteLine("Have a good day!");
            }
            else
            {
                GetContinue(classmates);
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

        // This method adds a new student to the school class
        public static StudentInfo AddNewStudent()
        {
            StudentInfo student = new StudentInfo();
            student.StudentName = GetUserInput("What is the student's name?");
            student.FavoriteFood = GetUserInput("What is the student's favorite food?");
            student.FavoriteSubject = GetUserInput("What is the student's favorite subject?");
            student.FavoriteHobby = GetUserInput("What is the student's favorite hobby?");
            student.FavoriteColor = GetUserInput("What is the student's favorite color?");
            return student;
        }

        // This method sorts the school class
        public static int SortClass(StudentInfo student1, StudentInfo student2)
        {
            return String.Compare(student1.StudentName, student2.StudentName);
        }

        // This class is a student confusing right?
        public class StudentInfo
        {
            // Variables needed for the class
            private string _studentName;
            private string _favoriteFood;
            private string _favoriteSubject;
            private string _favoriteHobby;
            private string _favoriteColor;

            // Getters and Setters for each variable
            public string StudentName
            {
                get { return _studentName; }
                set { _studentName = value; }
            }
            public string FavoriteFood
            {
                get { return _favoriteFood; }
                set { _favoriteFood = value; }
            }
            public string FavoriteSubject
            {
                get { return _favoriteSubject; }
                set { _favoriteSubject = value; }
            }
            public string FavoriteHobby
            {
                get { return _favoriteHobby; }
                set { _favoriteHobby = value; }
            }
            public string FavoriteColor
            {
                get { return _favoriteColor; }
                set { _favoriteColor = value; }
            }
        }
    }
}
