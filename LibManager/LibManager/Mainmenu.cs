using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibManager
{
    public class Mainmenu
    {
        /*
        private static bool StaffLogin()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            string password = UserInterface.GetPassword("Password");
            if (username == "staff" && password == "today123")
            {
                return true;
            }
            return false;
        }
        */
        public static void Init(IMemberCollection thisMembersCollection, IMovieCollection thisMovieCollection)
        {

            //welcome messade
            Console.Clear();
            Console.WriteLine("============================================================");
            Console.WriteLine("Welcome to Community Library Movie DVD Management System");
            Console.WriteLine("============================================================");
            Console.WriteLine();
            start:
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

                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        string password = UserInterface.GetPassword("Password");
                        if (username == "staff" && password == "today123")
                        {
                            Staffmenu.Init(thisMembersCollection, thisMovieCollection);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("ERROR: Staff login details are incorrect, please try again");
                            Console.WriteLine();
                            goto start;
                        }
                        break;

                    case "2": // Jack, updated the member entry so that a member reference is passed to Init instead of a new Member object.
                        Console.WriteLine("Member Entry");
                        Console.Write("First Name: ");
                        string FirstName = Console.ReadLine().ToLower();
                        Console.Write("Last Name: ");
                        string LastName = Console.ReadLine().ToLower();
                        string password2 = UserInterface.GetPassword("Password");
                        IMember loggedInMember = new Member(FirstName, LastName);
                        if (thisMembersCollection.Find(loggedInMember) != null)
                        {
                            if (thisMembersCollection.Find(loggedInMember).Pin == password2)
                            {
                                Membermenu.Init(thisMembersCollection, thisMovieCollection, thisMembersCollection.Find(loggedInMember));
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("ERROR: Member login details are incorrect, please try again");
                                Console.WriteLine();
                                goto start;
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("ERROR: Member login details are incorrect, please try again");
                            Console.WriteLine();
                            goto start;
                        }
                        break;

                    case "0":
                        System.Environment.Exit(0);
                        //status = false;
                        break;
                    default: break;

                }               

            }
            
        }

    }
}
