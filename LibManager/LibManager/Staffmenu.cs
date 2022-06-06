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
            Console.WriteLine("5. Display a member's contact number given the member's name");
            Console.WriteLine("6. Display all memebers who are currently renting a particular movie");
            Console.WriteLine("0. Return to the main menu");
            Console.WriteLine();
            Console.WriteLine("Enter your choice ==> (1/2/3/4/5/6/0) ");
        }
        

        public static void Init(IMemberCollection thisMembersCollection, IMovieCollection thisMovieCollection)
        {
            bool status = true;

            while (status)
            {
                PrintStaffMenu();
                switch (Console.ReadLine())
                {
                    //Add DVD's of a new/existing movie to the system
                    case "1": 
                        Console.Write("Title: ");
                        string title = Console.ReadLine();
                        int optionGenre;
                        // If movie doesn't exists in the library
                        if (thisMovieCollection.Search(title) == null)
                        {
                            if (title.Length == 0)
                            {
                                Console.WriteLine("Enter a valid movie name!");
                                break;

                            }
                                optionGenre = UserInterface.GetOption("Please select one of the following:",
                                "Action", "Comedy", "History", "Drama", "Western");
                                List<MovieGenre> typesGenre = new List<MovieGenre>()
                            {
                                MovieGenre.Action,
                                MovieGenre.Comedy,
                                MovieGenre.Drama,
                                MovieGenre.History,
                                MovieGenre.Western
                            };
                            

                            var thisGenre = typesGenre[optionGenre];

                            int optionClass = UserInterface.GetOption("Please select one of the following:",
                            "G", "PG", "M", "M15Plus");
                            List<MovieClassification> typesClass = new List<MovieClassification>() 
                            {
                                MovieClassification.G,
                                MovieClassification.M,
                                MovieClassification.PG,
                                MovieClassification.M15Plus
                            };
                            var thisClass = typesClass[optionClass];
                            
                            Console.Write("Duration: ");
                            int thisduration = Convert.ToInt32(Console.ReadLine());

                            // Added by Emma to save total copies as well
                            Console.Write("Total Copies: ");
                            int thisTotalCopies = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine();
                            IMovie thisMovie = new Movie(title, thisGenre, thisClass, thisduration, thisTotalCopies);
                            thisMovieCollection.Insert(thisMovie);

                            Console.WriteLine(thisMovie.ToString() + " is added successfully!!!");
                            Console.WriteLine();
                        }
                        else
                        {
                            //Added by Emma: more than one copy of DVD can be added at a time
                            Console.WriteLine("Please enter number of copies to add: ");
                            int copies = Convert.ToInt32(Console.ReadLine());
                            thisMovieCollection.Search(title).TotalCopies = thisMovieCollection.Search(title).TotalCopies + copies;
                            thisMovieCollection.Search(title).AvailableCopies = thisMovieCollection.Search(title).AvailableCopies + copies;

                            Console.WriteLine();
                            Console.WriteLine("Number of copies for " + title + " is now: " + thisMovieCollection.Search(title).TotalCopies);
                            Console.WriteLine();
                        }

                        break;

                    case "2": //Remove DVD's of a movie from the system
                        Console.Write("Title: ");
                        string thisMovieTitle = Console.ReadLine();
                        // Check if movie exists
                        if (thisMovieCollection.Search(thisMovieTitle) != null)
                        {
                            // Check if movie's total copies is more than one
                            if (thisMovieCollection.Search(thisMovieTitle).TotalCopies > 1)
                            {
                                thisMovieCollection.Search(thisMovieTitle).AvailableCopies--;
                                // Check if there are copies available
                                if (thisMovieCollection.Search(thisMovieTitle).AvailableCopies >= 0)
                                {
                                    thisMovieCollection.Search(thisMovieTitle).TotalCopies--;
                                    Console.WriteLine();
                                    Console.WriteLine(thisMovieCollection.Search(thisMovieTitle).ToString());
                                    Console.WriteLine("Total copies are: " + thisMovieCollection.Search(thisMovieTitle).TotalCopies);
                                }

                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("ERROR: There are no available copies to delete!");
                                    thisMovieCollection.Search(thisMovieTitle).AvailableCopies++;

                                }


                            }

                            // Check if there is exactly one copy and it's available
                            else if (thisMovieCollection.Search(thisMovieTitle).TotalCopies == 1 &&
                                thisMovieCollection.Search(thisMovieTitle).AvailableCopies == 1)
                            {
                                Console.WriteLine();
                                Console.WriteLine("The movie " + thisMovieCollection.Search(thisMovieTitle).Title + " is removed from the library!");
                                thisMovieCollection.Delete(thisMovieCollection.Search(thisMovieTitle));
 
                            }
                            // Check if there is one copy but not available (borrowed by a member)
                            else if (thisMovieCollection.Search(thisMovieTitle).TotalCopies == 1 &&
                                thisMovieCollection.Search(thisMovieTitle).AvailableCopies == 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("ERROR: cannot remove the movie, this movie is bottowed by a member");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Movie doesnt exist in the system.");
                        }
                        break;

                    case "3": //Register a new member with the system
                        Console.Write("First name: ");
                        string firstName = Console.ReadLine().ToLower();
                        Console.Write("Last name: ");
                        string lastName = Console.ReadLine().ToLower();
                        Console.Write("Phone number: ");
                        string contactNumber = (Console.ReadLine());
                        if (IMember.IsValidContactNumber(contactNumber))
                        {
                            Console.Write("Pin: ");
                            string pin = Console.ReadLine();
                            if (IMember.IsValidPin(pin))
                            {
                                Member thisMember = new Member(firstName, lastName, contactNumber, pin);
                                thisMembersCollection.Add(thisMember);
                                //Console.WriteLine("Member has been added successfully!");
                                Console.WriteLine();

                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("ERROR: Invalid pin.");
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("ERROR: Invalid contact number.");
                        }
                        
                        break;

                    case "4": //Remove a registered memeber from the system
                        Console.Write("First name: ");
                        string firstNameDelete = Console.ReadLine().ToLower();
                        Console.Write("Last name: ");
                        string lastNameDelete = Console.ReadLine().ToLower();

                        Member thisMemberDelete = new Member(firstNameDelete, lastNameDelete);
                        // Check if member exists
                        if (thisMembersCollection.Search(thisMemberDelete))
                        {
                            // Check if number of borrowed movies == 0.
                            if (thisMembersCollection.Find(thisMemberDelete).MoviesBorrowed.IsEmpty()) 
                            {
                                thisMembersCollection.Delete(thisMembersCollection.Find(thisMemberDelete));
                                Console.WriteLine(thisMemberDelete.ToString() + " is removed successfully!");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("MEMBER CANNOT BE REMOVED, This member has DVD on loan!");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Member doesn't exists!");
                        }
                        break;

                    case "5": //Display a member's contact number given the member's first name
                        Console.Write("First name: ");
                        string firstNameDisplay = Console.ReadLine().ToLower();
                        Console.Write("Last name: ");
                        string lastNameDisplay = Console.ReadLine().ToLower();

                        Member thisMemberDisplay = new Member(firstNameDisplay, lastNameDisplay);
                        if (thisMembersCollection.Search(thisMemberDisplay))
                        {
                            IMember MemberDisplay = thisMembersCollection.Find(thisMemberDisplay);
                            Console.WriteLine("The member's contact number is: " + MemberDisplay.ContactNumber);
                        }
                        else
                            Console.WriteLine("Error the member is not registered !");
                        
                        break;

                    //Display all memebers who are currently renting a particular movie
                    case "6":
                        // Prompt user to enter a movie title
                        Console.WriteLine("Please enter the title of movie: ");
                        string myTitle = Console.ReadLine();
                        // Print name of members who borrowed this movie
                        if (myTitle.Length != 0 && thisMovieCollection.Search(myTitle) != null)
                        {
                            //Added by emma to print to the console if no one is borrowed the movie
                            if (thisMovieCollection.Search(myTitle).Borrowers.IsEmpty())
                            {
                                Console.WriteLine("No member is currently borrowing this Movie");
                            }
                            else
                            {
                                Console.WriteLine("Members who borrowed " + myTitle + " are:");
                                Console.WriteLine(thisMovieCollection.Search(myTitle).Borrowers.ToString());
                            }

                        }
                        else
                            Console.WriteLine("Error movie does not exist !");
                        
                        
                        // A movie has a borrower

                        break; 

                    case "0":
                        status = false;
                        Mainmenu.Init(thisMembersCollection,thisMovieCollection);
                        break;

                    default:
                        Console.WriteLine("Error: make a valid choice between 0-6");
                        break;
                }
                

            }

        }
    }
}
