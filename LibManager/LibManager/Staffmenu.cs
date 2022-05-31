using System;
using System.Collections.Generic;

namespace LibManager
{
    public class Staffmenu
    {
        

        private static void PrintStaffMenu()
        {
            //Console.Clear();
            Console.WriteLine("========================= Staff Menu ==========================");
            Console.WriteLine();
            Console.WriteLine("1. Add new DVD's of a new movie to the system");
            Console.WriteLine("2. Remove DVD's of a movie from the system");
            Console.WriteLine("3. Register a new member with the system");
            Console.WriteLine("4. Remove a registered memeber from the system");
            Console.WriteLine("5. Display a member's contact number given the member's first name");
            Console.WriteLine("6. Display all memebers who are currently renting a particular movie");
            Console.WriteLine("0. Return to the main menu");
            Console.WriteLine();
            Console.WriteLine("Enter your choice ==> (1/2/3/4/5/6/0) ");
        }

        public static Movie GetMovieinfo()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();

            int optionGenre = UserInterface.GetOption("Please select one of the following:",
            "Action", "Comedy", "History", "Drama", "Western");
            List<MovieGenre> typesGenre = new List<MovieGenre>() {
                            MovieGenre.Action,
                            MovieGenre.Comedy,
                            MovieGenre.Drama,
                            MovieGenre.History,
                            MovieGenre.Western
                        };
            var thisGenre = typesGenre[optionGenre];

            int optionClass = UserInterface.GetOption("Please select one of the following:",
            "G", "PG", "M", "M15Plus");
            List<MovieClassification> typesClass = new List<MovieClassification>() {
                            MovieClassification.G,
                            MovieClassification.M,
                            MovieClassification.PG,
                            MovieClassification.M15Plus
                        };
            var thisClass = typesClass[optionClass];

            Console.Write("Duration: ");
            int thisduration = Convert.ToInt32(Console.ReadLine());
            

            return new Movie(title, thisGenre, thisClass, thisduration, 1);
        }

        public static void Init(MemberCollection thisMembersCollection, MovieCollection thisMovieCollection)
        {
            bool status = true;

            while (status == true)
            {
                PrintStaffMenu();
                switch (Console.ReadLine())
                {
                    case "1": //Add new DVD's of a new movie to the system
                        Movie thisMovie = GetMovieinfo();


                        if (!thisMovieCollection.Search(thisMovie))
                        {
                            thisMovieCollection.Insert(thisMovie);
                        }
                        else
                        {
                            thisMovieCollection.Search(thisMovie.Title).TotalCopies++;
                            Console.WriteLine(thisMovieCollection.Search(thisMovie.Title).TotalCopies);
                        }
                        break;

                    case "2": //Remove DVD's of a movie from the system
                        Console.Write("Title: ");
                        string thisMovieTitle = Console.ReadLine();
                        if (thisMovieCollection.Search(thisMovieTitle).TotalCopies > 1)
                        {
                            thisMovieCollection.Search(thisMovieTitle).TotalCopies--;
                        }
                        else if (thisMovieCollection.Search(thisMovieTitle).TotalCopies == 1)
                        {
                            thisMovieCollection.Delete(thisMovieCollection.Search(thisMovieTitle));
                        }
                        else
                        {
                            Console.Write("Movie doesnt exist.");
                        }
                        
                        
                        break;

                    case "3": //Register a new member with the system

                        break;

                    case "4": //Remove a registered memeber from the system

                        break;

                    case "5": //Display a member's contact number given the member's first name

                        break;

                    case "6": //Display all memebers who are currently renting a particular movie

                        break;

                    case "0":
                        status = false;
                        break;
                }
                

            }

        }
    }
}
