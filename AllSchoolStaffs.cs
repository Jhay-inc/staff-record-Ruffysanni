using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StaffRecordApplication
{
    public class AllSchoolStaffs
    {
        //private readonly int numInput;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string DateCreated { get; set; }
        public DateTime Id { get; set; }
        public string IdCard { get; set; }

        //Enter details
        public void EnterStaffDetails()
        {

            Console.WriteLine("Enter staff details here:\n");

            Console.WriteLine("Choose category of staff:\n\nPress 1 for Academic staff OR\n\n2 for Non-Academic staff");

            string input1 = Console.ReadLine();
            //string input2 = Console.ReadLine();
            if (input1 != "1" && input1 != "2")
            {
                Console.WriteLine("Invalid entry!!!");
            }
            else
            {
                Console.WriteLine("Welcome to the Academic staff page.\n");
                Console.WriteLine("Login as an existing staff (Press 1) or Login as a New Staff (Press 2)..");
                string existingStaff = Console.ReadLine();
                //string newStaff = Console.ReadLine();
                if (existingStaff != "1" && existingStaff != "2")
                {
                    Console.WriteLine("Wrong input!");
                }
                else
                {
                    if(existingStaff == "1") 
                    {
                        LoginStaff();
                    }else 
                    {
                        Console.WriteLine("You are welcome...\nPlease enter your details to register.");
                        RegisterNewStaff();
                    }
                   
                }

                Console.WriteLine();
                DisplayStaffDetail();
            }
        }

        public void LoginStaff()
        {
            Console.WriteLine("Enter login details:\n\n1. Enter 1 as principal\n\n2. Enter 2 as Teacher\n\n3. Enter 3 as exam officer\n\n4. Enter 4 as Admin Officer");
            Console.WriteLine("Enter firstname: ");
            FirstName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter lastname: ");
            LastName = Console.ReadLine();
            Console.WriteLine();

            //Validating email
            string email;
            bool isValidEmail;
            do
            {
                Console.WriteLine("Enter Email: ");
                email = Console.ReadLine();
                isValidEmail = IsValid(email);


                if (!isValidEmail)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not a valid email address. Please retry!");
                    Console.ResetColor();

                }
            }
            while (!isValidEmail);

            Console.WriteLine("Enter password: ");
            Password = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter your department: ");
            Department = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter role...");
            if ((Role == "pdrincipal") || (Role == "admin officer") || (Role == "Exam officer") || (Role == "Teacher"))
            {
                Role = Console.ReadLine();
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
            Console.WriteLine();

            Console.WriteLine("Enter lastname: ");
            LastName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter email address: ");
            Email = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter password: ");
            Password = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Confirm password: ");
            Password = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter your department: ");
            Department = Console.ReadLine();
            Console.WriteLine();
        }

        private static bool IsValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }

        public void DisplayStaffDetail()
        {
            string fullName = FirstName + " " + LastName;
            Console.WriteLine($"Welcome {fullName}\nEmail: {Email}\nDepartment: {Department}\nRole: {Role}");
        }
    }
}
