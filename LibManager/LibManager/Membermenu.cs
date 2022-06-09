
using System;
namespace LibManager
{
    public class Membermenu
    {
        // Determine top three movies borrowed in the library system
        // Pre-condition: nil
        // Post-condition: an array containing top 3 borrowed movies are returned
        private static IMovie[] top3Elements(IMovieCollection movies)
        {
            
            int first = movies.ToArray()[0].NoBorrowings, second = 0, third = 0;
            
            Console.WriteLine("Top three most borrowed movies are: ");
            IMovie[] top3 = new IMovie[3];
            // Assign the first movie in ToArray as first element of top3 array
            top3[0] = movies.Search(movies.ToArray()[0].Title);

            // Go through all the movies stored in ToArray (starting from second element) to find top 3 most borrowed movies
            for (int i = 1; i < movies.ToArray().Length; i++)
            {
                if (movies.ToArray()[i].NoBorrowings > first)
                {
                    third = second;
                    second = first;
                    first = movies.ToArray()[i].NoBorrowings;
                    top3[2] = top3[1];
                    top3[1] = top3[0];
                    top3[0] = movies.Search(movies.ToArray()[i].Title);
                }
                else if (movies.ToArray()[i].NoBorrowings > second)
                {
                    third = second; 
                    second = movies.ToArray()[i].NoBorrowings;
                    top3[2] = top3[1];
                    top3[1] = movies.Search(movies.ToArray()[i].Title);
                }
                else if (movies.ToArray()[i].NoBorrowings > third)
                {
                    third = movies.ToArray()[i].NoBorrowings;
                    top3[2] = movies.Search(movies.ToArray()[i].Title);
                }
            }
            return top3;
        }

        public static void Init(IMemberCollection thisMembersCollection, IMovieCollection thisMovieCollection, 
            IMember thisMember)
        {

            bool status = true;

            while (status)
            {
                // Display Member Menu 
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

                        // Check there is any movie in the library, print the title and available copies
                        if (allMovies.Length != 0)
                        {
                            foreach (IMovie movie in allMovies)
                            {
                                    Console.Write(movie.Title + " available copies: ");
                                    Console.WriteLine(movie.AvailableCopies);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no movie in the library!");
                        }

                        break;

                    // Displaying the information of a movie when provided with title
                    case "2":
                        // Prompt the user for a tile and read it
                        Console.Write("Title of the movie : ");
                        string movietitle = Console.ReadLine();

                        // Check if movie exists, show all movie information
                        if (thisMovieCollection.Search(movietitle) != null)
                        {
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

                        //Check if movie exists, and member borrowed less than 5 movies
                        if (thisMovieCollection.Search(movietitle2) != null)
                        {
                            if (thisMember.MoviesBorrowed.Number < 5) 
                            {
                                // Add this member to the borrowers
                                thisMovieCollection.Search(movietitle2).AddBorrower(thisMember);
                                // Add this movie to this member's borrowers list
                                thisMember.MoviesBorrowed.Insert(thisMovieCollection.Search(movietitle2));
                            }
                            else
                            {
                                Console.WriteLine("Error: cannot borrow more than five movies");
                            }
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

                        //Check if movie exists
                        if (thisMovieCollection.Search(movietitle3) != null)
                        {
                            // Remove the member from the borrowers list of that particular movie 
                            thisMovieCollection.Search(movietitle3).RemoveBorrower(thisMember);
                            // Removed this movie from this member's borrowed list
                            thisMember.MoviesBorrowed.Delete(thisMovieCollection.Search(movietitle3));

                        }
                        else
                        {
                            Console.WriteLine("ERROR: this movie does not exists in library!");
                        }

                        break;

                    // List current movies that are currently borrowed by the registered member
                    case "5":
                        Console.WriteLine("List of movies borrowed by " + thisMember.ToString());
                        Console.WriteLine();
                        // Display all the movies borrowed by this member
                        foreach(IMovie movie in thisMember.MoviesBorrowed.ToArray())
                        {
                                Console.WriteLine(movie.ToString());
                        }
                        
                        break;

                    // Display the top three most frequently borrowed movies
                    case "6":

                        // Check if movie collection is not empty, and is borrowed, display the top 3 borrowed movies
                        if (!thisMovieCollection.IsEmpty())
                        {
                            IMovie[] top3 = top3Elements(thisMovieCollection);

                            foreach (IMovie movie in top3)
                            {
                                if (movie != null)
                                {
                                    if (movie.NoBorrowings != 0)
                                    {
                                        Console.WriteLine(movie.Title + " " + movie.NoBorrowings);
                                    }

                                }

                            }

                        }
                        else
                            Console.WriteLine("Error no movies in the library!");

                        break;

                    case "0":
                        // Return to main menu
                        status = false;
                        Mainmenu.Init(thisMembersCollection,thisMovieCollection);
                        break;

                    default:
                        Console.WriteLine("Error make a valid choice from 0 - 6 ");
                        break;
                }
            }
        }
    }
}
