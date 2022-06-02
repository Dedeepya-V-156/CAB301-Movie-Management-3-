using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibManager
{
    public class Mainmenu
    {


        public static void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("============================================================");
            Console.WriteLine("Welcome to Community Library Movie DVD Management System");
            Console.WriteLine("============================================================");
            Console.WriteLine();
            Console.WriteLine("=========================Main Menu==========================");
            Console.WriteLine();
            Console.WriteLine("1. Staff Login ");
            Console.WriteLine("2. Member Login ");
            Console.WriteLine("0. Exit ");
            Console.WriteLine();
            Console.WriteLine("Enter you choice ==> (1/2/0) ");

        }


        

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
        
        public static void Init(IMemberCollection thisMembersCollection, IMovieCollection thisMovieCollection)
        {
            bool status = true;

            while (status)
            {
                PrintMainMenu();
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Staff Entry");
                        if (StaffLogin())
                        {
                            Staffmenu.Init(thisMembersCollection, thisMovieCollection);
                        }

                        break;

                    case "2":
                        Console.WriteLine("Member Entry");
                        Console.Write("First Name: ");
                        string FirstName = Console.ReadLine().ToLower();
                        Console.Write("Last Name: ");
                        string LastName = Console.ReadLine().ToLower();
                        string password = UserInterface.GetPassword("Password");
                        IMember thisMember = new Member(FirstName, LastName);
                        if (thisMembersCollection.Find(thisMember) != null)
                        {
                            if (thisMembersCollection.Find(thisMember).Pin == password)
                            {
                                Membermenu.Init(thisMembersCollection, thisMovieCollection, thisMember);
                            }
                        }

                        break;

                    case "0":
                        status = false;
                        break;
                }
                

            }
            
        }



    }
}
