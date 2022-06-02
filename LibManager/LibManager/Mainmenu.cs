using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibManager
{
    public class Mainmenu
    {

        // int temp = 0;

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
        
        //////Change parameters to IMemberCollection and IMovieCollection types
        public static void Init(IMemberCollection thisMembersCollection, IMovieCollection thisMovieCollection)
        {
            bool status = true;

            while (status == true)
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


                        break;

                    case "0":
                        status = false;
                        break;
                }
                

            }
            
        }



    }
}
