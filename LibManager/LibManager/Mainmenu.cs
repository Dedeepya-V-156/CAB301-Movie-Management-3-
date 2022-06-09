using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibManager
{
    public class Mainmenu
    {
  
        public static void Init(IMemberCollection thisMembersCollection, IMovieCollection thisMovieCollection)
        {

            //welcome message
            Console.Clear();
            Console.WriteLine("============================================================");
            Console.WriteLine("Welcome to Community Library Movie DVD Management System");
            Console.WriteLine("============================================================");
            Console.WriteLine();
            start:
            //Main menu message
            Console.WriteLine("1. Staff Login ");
            Console.WriteLine("2. Member Login ");
            Console.WriteLine("0. Exit ");
            Console.WriteLine();
            Console.WriteLine("Enter you choice ==> (1/2/0) ");

            bool status = true;

            while (status)
            {

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Staff Entry");
                        // Ask for username
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        string password = UserInterface.GetPassword("Password");
                        // If username and password correct, redirect the staff to staff menu
                        if (username == "staff" && password == "today123")
                        {
                            Staffmenu.Init(thisMembersCollection, thisMovieCollection);
                        }
                        // otherwise display an error message
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("ERROR: Staff login details are incorrect, please try again");
                            Console.WriteLine();
                            goto start;
                        }
                        break;

                    case "2": 
                        Console.WriteLine("Member Entry");
                        // Ask registered member for full name & password
                        Console.Write("First Name: ");
                        string FirstName = Console.ReadLine().ToLower();
                        Console.Write("Last Name: ");
                        string LastName = Console.ReadLine().ToLower();
                        string password2 = UserInterface.GetPassword("Password");
                        IMember loggedInMember = new Member(FirstName, LastName);
                        // Check member exists and password is correct, send the member to member menu
                        if (thisMembersCollection.Find(loggedInMember) != null)
                        {
                            if (thisMembersCollection.Find(loggedInMember).Pin == password2)
                            {
                                Membermenu.Init(thisMembersCollection, thisMovieCollection, thisMembersCollection.Find(loggedInMember));
                            }
                            // Display an error if password is not correct
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("ERROR: Member login details are incorrect, please try again");
                                Console.WriteLine();
                                goto start;
                            }
                        }
                        // Display an error if member doesn't exists in member collection
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("ERROR: Member login details are incorrect, please try again");
                            Console.WriteLine();
                            goto start;
                        }
                        break;

                    case "0":
                        // Exit the system
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Error make a valid choice from 0 - 2 ");
                        break;

                }               

            }
            
        }

    }
}
