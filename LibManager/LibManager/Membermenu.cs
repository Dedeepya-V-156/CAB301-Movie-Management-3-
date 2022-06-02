using System;
namespace LibManager
{
    public class Membermenu
    {
        private static void PrintMemberMenu()
        {
            Console.WriteLine("========================= Member Menu ==========================");
            Console.WriteLine();
            Console.WriteLine("1. Browse all the movies");
            Console.WriteLine("2. Display all the information about a movie, given the title of the movie");
            Console.WriteLine("3. Borrow a movie DVD");
            Console.WriteLine("4. Return a movie DVD");
            Console.WriteLine("5. List current borrowing movies");
            Console.WriteLine("6. Display the top 3 movies rented by the members");
            Console.WriteLine("0. Return to the main menu");
            Console.WriteLine();
            Console.WriteLine("Enter your choice ==> (1/2/3/4/5/6/0) ");


        }

        //Emma: I don't think we need this
        /*
        public static void MemberDetails()
        {
            Console.Write("Enter the first name");
            string Fname = Console.ReadLine();
            Console.WriteLine("Enter the last name");
            string Lname = Console.ReadLine();
            Console.WriteLine("Enter the password");
            string password = Console.ReadLine();
            int pword = Int32.Parse(password);
            //return movietitle;
        }
        */

        public static void Init(IMemberCollection thisMembersCollection, IMovieCollection thisMovieCollection, IMember member)
        {
            
            string choice;

            bool status = true;

            while (status == true)
            {
                PrintMemberMenu();
                status = false;

            }
            switch (choice = Console.ReadLine())
            {
                case "1": 
                  break;

                case "2": // Displaying the information of a movie when provided with title
                    Console.Write("Title of the movie : ");
                    string movietitle = Console.ReadLine();
                    if (thisMovieCollection.Search(movietitle) != null)
                    {
                        movietitle.ToString();

                    }
                    else
                        Console.WriteLine("Error the movie does not exist!");
                    break;

                case "3":     
                        break;
                case "4":
                    // Prompt the user for a tile and read it
                    Console.Write("Title of the movie : ");
                    string movietitle2 = Console.ReadLine();
                    // Remove the member from the borrower list of that particular movie
                    thisMovieCollection.Search(movietitle2).RemoveBorrower(member);
                    // Increase the available copies of that particular movie
                    thisMovieCollection.Search(movietitle2).AvailableCopies++;
                    break;

                case "5":
                    Console.WriteLine("List of movies borrowed by " + member.ToString());
                    //member.MoviesBorrowed
                    break;
                case "6":
                    break;
                case "0":
                    Mainmenu.PrintMainMenu();
                    break;
            }
        }
    }
}
