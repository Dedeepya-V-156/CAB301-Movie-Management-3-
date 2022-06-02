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

        public static void Init(IMemberCollection thisMembersCollection, IMovieCollection thisMovieCollection, IMember member)
        {
            bool status = true;

            while (status)
            {
                PrintMemberMenu();
                switch (Console.ReadLine())
                {
                    // Displaying the information about all the movies in alphabetical order and number of available copies
                    case "1":

                        IMovie[] allMovies = thisMovieCollection.ToArray();
                        // If there is any movie in the library print the title and available copies
                        if (allMovies.Length != 0)
                        {
                            foreach (IMovie movie in allMovies)
                            {
                                if(movie != null) ////////////////// A TEMPORARY FIX
                                {
                                    //////////////////TEST NUMBER OF AVAILABLE COPIES
                                    Console.Write(movie.Title + " available copies: ");
                                    Console.WriteLine(movie.AvailableCopies);
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no movie in the library!");
                        }

                        break;

                    // Displaying the information of a movie when provided with title
                    case "2":
                        Console.Write("Title of the movie : ");
                        string movietitle = Console.ReadLine();
                        if (thisMovieCollection.Search(movietitle) != null)
                        {
                            //Modified by Emma so that it shows movie info
                            Console.WriteLine(thisMovieCollection.Search(movietitle).ToString());

                        }
                        else
                            Console.WriteLine("ERROR: the movie does not exist!");
                        break;

                    // Borrow a movie DVD from the community library
                    case "3":
                        // Prompt the user for a tile and read it
                        Console.Write("Title of the movie : ");
                        string movietitle2 = Console.ReadLine();
                        Console.WriteLine();
                        thisMovieCollection.Search(movietitle2).AddBorrower(member);
                        break;

                    // Return a movie DVD to the community library
                    case "4":
                        // Prompt the user for a tile and read it
                        Console.Write("Title of the movie : ");
                        string movietitle3 = Console.ReadLine();
                        // Remove the member from the borrower list of that particular movie
                        thisMovieCollection.Search(movietitle3).RemoveBorrower(member);
                        Console.WriteLine();
                        Console.WriteLine(movietitle3 + " is returned successfully!");
                        break;

                    // List current movies that are currently borrowed by the registered member
                    case "5":
                        Console.WriteLine("List of movies borrowed by " + member.ToString());
                        //member.MoviesBorrowed
                        break;

                    // Display the top three most frequently borrowed movies
                    case "6":
                        Console.WriteLine("Top three most borrowed movies are: ");
                        IMovie[] top3= new IMovie[3];

                        foreach (IMovie movie in thisMovieCollection.ToArray())
                        {
                            if (movie != null)
                            {
                                if (movie.NoBorrowings > first)
                                {
                                    third = second;
                                    second = first;
                                    first = movie.NoBorrowings;
                                    top3[0] = thisMovieCollection.Search(movie.Title);
                                }
                                else if (movie.NoBorrowings > second)
                                {
                                    third = second;
                                    second = movie.NoBorrowings;
                                    top3[1] = thisMovieCollection.Search(movie.Title);
                                }
                                else
                                {
                                    third = movie.NoBorrowings;
                                    top3[2] = thisMovieCollection.Search(movie.Title);
                                }

                            }
                        }
                        foreach (IMovie movie in top3)
                        {
                            if (movie != null)
                            {
                                Console.WriteLine(movie.Title + " " + movie.NoBorrowings);

                            }
                        }

                        break;

                    case "0":
                        status = false;
                        Mainmenu.PrintMainMenu();
                        break;
                }
            }
        }
    }
}
