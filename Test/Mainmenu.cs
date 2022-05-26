using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Test
{
    public class Mainmenu
    {
        int temp = 0;

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
        static void Main(string[] args)
        {
            string choice;

            bool status = true; 

            while(status == true)
            {
                PrintMainMenu();
                status = false;

            }
            switch(choice = Console.ReadLine())
            {
                case "1":
                    break;
                case "2":
                    break;
                case "0":
                    PrintMainMenu();
                    break;
            }
        }
    }
}
