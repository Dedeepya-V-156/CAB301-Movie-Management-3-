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

