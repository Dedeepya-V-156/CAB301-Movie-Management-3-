using System;
namespace LibManager
{
    public class Program
    {
            static void Main(string[] args)
            {
            MemberCollection NewMemberCollection = new MemberCollection(10);
            MovieCollection newMovieCollections = new MovieCollection();
            Mainmenu.Init(NewMemberCollection, newMovieCollections);
            }
    }
}


//create movie objects with only title name (for now)
/*
Movie movie1 = new Movie("Revenge of the Sith");
Movie movie2 = new Movie("Die Hard");
Movie movie3 = new Movie("Willy Wonker");
Movie movie4 = new Movie("Lord of the rings");
Movie movie5 = new Movie("The Clone Wars");
Movie movie6 = new Movie("Plup Fiction");
Movie movie7 = new Movie("Casino Royal");
Movie movie8 = new Movie("The Wizard of Oz");
*/