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

        static int first = 0, second = 0, third = 0;
        static IMovie[] top3;
        private static IMovie[] FindTopThree(IMovie[] allMovies)
        {
            foreach (IMovie movie in allMovies)
            {
                if (movie.NoBorrowings > first)
                {
                    third = second;
                    second = first;
                    first = movie.NoBorrowings;
                    top3[0].Title = movie.Title;
                }
                else if (movie.NoBorrowings > second)
                {
                    third = second;
                    second = movie.NoBorrowings;
                    top3[1].Title = movie.Title;
                }
                else 
                {
                    third = movie.NoBorrowings;
                    top3[2].Title = movie.Title;
                }
            }
            return top3;
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
                // Displaying the information about all the movies in alphabetical order and number of available copies
                case "1": 
                    IMovie[] allMovies = thisMovieCollection.ToArray();
                    foreach (IMovie movie in allMovies)
                    {
                        Console.Write(movie.Title + " available copies: ");
                        Console.WriteLine(movie.AvailableCopies);
                    }

                    break;
                // Displaying the information of a movie when provided with title
                case "2": 
                    Console.Write("Title of the movie : ");
                    string movietitle = Console.ReadLine();
                    if (thisMovieCollection.Search(movietitle) != null)
                    {
                        movietitle.ToString();

                    }
                    else
                        Console.WriteLine("Error the movie does not exist!");
                    break;

                // Borrow a movie DVD from the library
                case "3":
                    // Prompt the user for a tile and read it
                    Console.Write("Title of the movie : ");
                    string movietitle2 = Console.ReadLine();
                    thisMovieCollection.Search(movietitle2).AddBorrower(member);
                    break;

                case "4":
                    // Prompt the user for a tile and read it
                    Console.Write("Title of the movie : ");
                    string movietitle3 = Console.ReadLine();
                    // Remove the member from the borrower list of that particular movie
                    thisMovieCollection.Search(movietitle3).RemoveBorrower(member);
                    // Increase the available copies of that particular movie
                    thisMovieCollection.Search(movietitle3).AvailableCopies++;
                    break;

                case "5":
                    Console.WriteLine("List of movies borrowed by " + member.ToString());
                    //member.MoviesBorrowed
                    break;

                case "6":
                    Console.WriteLine("Top three most borrowed movies are: " );
                    IMovie[] topMovies = FindTopThree(thisMovieCollection.ToArray());
                    foreach (IMovie movie in topMovies)
                    {
                        Console.WriteLine(movie.Title + " " + movie.NoBorrowings);
                    }
                    
                    break;

                case "0":
                    Mainmenu.PrintMainMenu();
                    break;
            }
        }
    }
}
