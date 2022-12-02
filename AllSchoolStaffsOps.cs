using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace StaffRecordApplication
{
    public class AllSchoolStaffsOps : AllStaffsData
    {
        //private readonly int numInput;

       

        //Enter details
        public void EnterStaffDetails()
        {

            Console.WriteLine("Enter staff details here:\n");

            Thread.Sleep(3000);

            Console.WriteLine("Choose category of staff:\n\nPress 1 for Academic staff OR\n\n2 for Non-Academic staff");

            string input1 = Console.ReadLine();
            //string input2 = Console.ReadLine();
            if (input1 != "1" && input1 != "2")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid entry!!!");
                Console.ResetColor();
            }
            else if(input1 == "1")
            {
                Console.WriteLine("Welcome to the Academic staff page.\n");
                Console.WriteLine("Login as an existing staff (Press 1) or Login as a New Staff (Press 2)..");
                string existingStaff = Console.ReadLine();
                //string newStaff = Console.ReadLine();
                if (existingStaff != "1" && existingStaff != "2")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("=======================>> Wrong input! <================== ");
                    Console.ResetColor();
                }
                else
                {
                    if(existingStaff == "1") 
                    {
                        LoginStaff();
                    }else if(existingStaff == "2")
                    {
                        Console.WriteLine("=======================>> You are welcome...<================== \n" +
                            "===========================> Register new user: <================================");
                        Thread.Sleep(3000);
                        RegisterNewStaff();
                    }
                   
                }

                Console.WriteLine();
                Thread.Sleep(3000);
                DisplayStaffDetail();
            }
            else 
            {
                if (input1 == "2")
                {
                    Console.WriteLine("===========================>> Welcome to the Non Academic staff page! <<================================");
                    
                    Console.WriteLine("==================================>> Enter details to login here: <<===================================");
                }
            }
        }

        public void LoginStaff()
        {
            Console.WriteLine("====================== Welcome to Danamiis Staff login page!=======================\n");
            Console.WriteLine("====================== Enter your login details below==============================\n");

            Console.WriteLine(">>>> Enter firstname: ");
            FirstName = Console.ReadLine();
            FirstNametLetterToUperCase(FirstName);
            Console.WriteLine();

            Console.WriteLine(">>>> Enter lastname: ");
            LastName = Console.ReadLine();
            LastNametLetterToUperCase(LastName);
            Console.WriteLine();

            //Validating email
            string email;
            bool isValidEmail;
            do
            {
                Console.WriteLine(">>>> Enter Email: ");
                email = Console.ReadLine();
                isValidEmail = IsValid(email);


                if (!isValidEmail)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("****Not a valid email address. Please retry!****");
                    Console.ResetColor();

                }
            }
            while (!isValidEmail);

            //Validating password...
            Console.WriteLine(">>>> Enter password: ");
            //Password = Console.ReadLine();
            PassWordChecker();


            Console.WriteLine();

            Console.WriteLine(">>>> Enter your department: ");
            Department = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter role...");
            Role = Console.ReadLine();
            if (Role == "principal")
            {
                //Assigning the principal roles
                PrinicipalExclusiveMethods prinicipalMethods = new PrinicipalExclusiveMethods();
                Console.WriteLine("Press 1 to add staff \nPress 2 to remove staff \nPress 3 to change staff role \nPress 4 to transfer staff role  " +
                    "\nPress 5 to remove self from the list \n");
                //prinicipalMethods.AddStaff();
                Console.WriteLine();
                string stringPrincipal = Console.ReadLine();
                if (stringPrincipal != "1" || stringPrincipal != "2" || stringPrincipal != "3" || stringPrincipal != "4" || stringPrincipal != "5")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong user input!!!");
                    Console.ResetColor();
                }
                else
                {
                    if (stringPrincipal == "1")
                    {
                        prinicipalMethods.AddStaff();
                    } 
                    else if (stringPrincipal == "2")
                    {
                        prinicipalMethods.RemoveStaff();
                    }
                    else if (stringPrincipal == "3")
                    {
                        prinicipalMethods.ChangeUserRole();
                    }
                    else if (stringPrincipal == "4")
                    {
                        prinicipalMethods.TransferRole();
                    }
                    else if (stringPrincipal == "5")
                    {
                        prinicipalMethods.RenoveSelfMethod();
                    }
                }
            }
            else
            {
                string noRole = "Nil";
                Role = noRole;
            }

        }


        public void RegisterNewStaff()
        {
            Console.WriteLine("Enter firstname: ");
            FirstName = Console.ReadLine();
            FirstNametLetterToUperCase(FirstName);
            Console.WriteLine();

            Console.WriteLine("Enter lastname: ");
            LastName = Console.ReadLine();
            LastNametLetterToUperCase(LastName);
            Console.WriteLine();

            Console.WriteLine("Enter email address: ");
            Email = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter password: ");
            PassWordChecker();
            //Password = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Confirm password: ");
            PassWordChecker();
            //Password = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter your department: ");
            Department = Console.ReadLine();
            Console.WriteLine();
        }

        public void PassWordChecker()
        {
            Password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && Password.Length > 0)
                {
                    Console.Write("\b \b");
                    Password = Password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    Password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);


            Console.WriteLine();
        }


        //Validating email
        private static bool IsValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }

        //Validating password
        public static bool IsValidPassword(string item)
        {
            Regex validateGuidRegex = new Regex("^(?=.?[A-Z])(?=.?[a-z])(?=.?[0-9])(?=.?[#?!@$%^&*-]).{6,}$");
            return validateGuidRegex.IsMatch(item);
        }

        public static string FirstNametLetterToUperCase(string FirstName)
        {
            //nameString = FirstName;
            //if (string.IsNullOrEmpty(nameString))
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FirstName.ToLower());
        }

        public static string LastNametLetterToUperCase(string LastName)
        {
            //nameString = FirstName;
            //if (string.IsNullOrEmpty(nameString))
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LastName.ToLower());
        }

        public void DisplayStaffDetail()
        {
            string fullName = FirstName + " " + LastName;
            Console.WriteLine($"Welcome {fullName}\nEmail: {Email}\nDepartment: {Department}\nRole: {Role}");
        }
    }
}
