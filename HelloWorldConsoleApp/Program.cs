using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HelloWorld.ConsoleApp.Models;

namespace HelloWorld.ConsoleApp
{
    class Program
    {
        private static readonly UserContext _context;

		static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string answer = "";
            while (answer != "Y" && answer != "y" && answer != "n" && answer != "N")
            {
                Console.WriteLine("Do you have a moment to answer some questions? (Y/N)");
                answer = Console.ReadLine();
            }
            if (answer == "Y" || answer == "y")
            {
                User user = new User();
                string firstName = "";
                string lastName = "";
                string email = "";
                DateTime birthdate;
                Console.WriteLine("Awesome! What's your first Name?");
                firstName = Console.ReadLine();
                Console.WriteLine("Hi, " + firstName + "! Now what's your last name?");
                lastName = Console.ReadLine();
                Console.WriteLine("And your email address?");
                email = Console.ReadLine();
                Console.WriteLine("Okay, last thing! When is your birthday (Might send you something cool). (MM/DD/YYYY)");
                birthdate = DateTime.Parse(Console.ReadLine());
				Console.WriteLine("Thank you so much! You're awesome!");

				user.firstName = firstName;
                user.lastName = lastName;
                user.birthdate = birthdate;
                user.email = email;

                _context.Users.Add(user);


			}

            if (answer == "N" || answer == "n")
            {
                Console.WriteLine("No Problem! Have a great day. :)");

            }
        }


    }
}
