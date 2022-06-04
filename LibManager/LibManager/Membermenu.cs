using System;
namespace LibManager
{
    public class Membermenu
    {
        /*
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
        */
        //static int first = 0, second = 0, third = 0;

        public static void Init(IMemberCollection thisMembersCollection, IMovieCollection thisMovieCollection, 
            IMember thisMember)
        {


            bool status = true;

            while (status)
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
                            //Console.WriteLine(thisMovieCollection.Search(movietitle).Borrowers.ToString());

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
                        if (thisMovieCollection.Search(movietitle2) != null)
                        {
                            // Add this member to the borrowers //////////////////////////////////////////////
                            thisMovieCollection.Search(movietitle2).AddBorrower(thisMember);
                            // Add this movie to this member's borrowers list
                            thisMember.MoviesBorrowed.Insert(thisMovieCollection.Search(movietitle2));
                        }
                        else
                        {
                            Console.WriteLine("ERROR: this movie does not exists in library!");
                        }
 
                        break;

                    // Return a movie DVD to the community library
                    case "4":
                        // Prompt the user for a tile and read it
                        Console.Write("Title of the movie : ");
                        string movietitle3 = Console.ReadLine();

                        if(thisMovieCollection.Search(movietitle3) != null)
                        {
                            // Remove the member from the borrowers list of that particular movie /////////////////////////
                            thisMovieCollection.Search(movietitle3).RemoveBorrower(thisMember);
                            // Removed this movie from this member's borrowed list
                            thisMember.MoviesBorrowed.Delete(thisMovieCollection.Search(movietitle3));

                            // Print a message to console
                            Console.WriteLine();
                            Console.WriteLine(movietitle3 + " is returned successfully!");
                        }
                        else
                        {
                            Console.WriteLine("ERROR: this movie does not exists in library!");
                        }

                        break;

                    // List current movies that are currently borrowed by the registered member
                    case "5":
                        //////////////////////////////////////////////////////////////////
                        Console.WriteLine("List of movies borrowed by " + thisMember.ToString());
                        Console.WriteLine();
                        // Print all the movies to the console
                        foreach(IMovie movie in thisMember.MoviesBorrowed.ToArray())
                        {
                            if (movie != null)
                            {
                                Console.WriteLine(movie.ToString());
                            }
                        }
                        
                        break;

                    // Display the top three most frequently borrowed movies
                    case "6":

                        int first = 0, second = 0, third = 0;

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
                        Mainmenu.Init(thisMembersCollection,thisMovieCollection);
                        break;
                }
            }
        }
    }
}
