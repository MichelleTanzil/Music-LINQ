using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist artist = Artists.FirstOrDefault(a => a.Hometown == "Mount Vernon");
            Console.WriteLine($"The artist's name and age from Mount Vernon is {artist.RealName} and he is {artist.Age} years old . His/her stage name is {artist.ArtistName}. ");

            //Who is the youngest artist in our collection of artists?
            // Solution 1
            IEnumerable<Artist> allArtists = Artists.OrderBy(a => a.Age);
            Artist youngestArtist = allArtists.FirstOrDefault();
            Console.WriteLine($"The youngest artist is {youngestArtist.ArtistName} and he/she is {youngestArtist.Age} years old.");

            //Solution 2
            Artist youngestArtistInHere = Artists.OrderBy(a => a.Age).First();
            Console.WriteLine($"The youngest artist is {youngestArtistInHere.ArtistName} and he/she is {youngestArtistInHere.Age} years old.");

            //Display all artists with 'William' somewhere in their real name
            IEnumerable<Artist> artistsWithWilliam = Artists.Where(a => a.RealName.Contains("William"));
            int i = 1;
            Console.WriteLine("Artists with 'William' somewhere in their real name");
            foreach (var a in artistsWithWilliam)
            {
                Console.WriteLine($"{i}. {a.ArtistName} and their real name is {a.RealName}. ");
                i++;
            }
            // Display all groups with names less than 8 characters in length.
            IEnumerable<Group> groupsLessThanEight = Groups.Where(g => g.GroupName.Length < 8);
            int x = 1;
            Console.WriteLine("Groups with names less than 8 characters in length: ");
            foreach (var g in groupsLessThanEight)
            {   
                Console.WriteLine($"{x}. {g.GroupName}");
            }

            //Display the 3 oldest artist from Atlanta
            IEnumerable<Artist> oldestArtists = Artists
                .Where(a => a.Hometown == "Atlanta")
                .OrderByDescending(a => a.Age)
                .Take(3);
            Console.WriteLine("The 3 oldest artist from Atlanta:");
            int j = 1;
            foreach (var a in oldestArtists)
            {
                Console.WriteLine($"{j}. {a.ArtistName} and he/she is {a.Age} years old. ");
                j++;
            }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            IEnumerable<Group> groupsNotFromNY = 
                Groups.Where(g => g.Members
                .Any(m => m.Hometown != "New York City"));
            int y = 1;
            Console.WriteLine("Display the Group Name of all groups that have members that are not from New York City: ");
            foreach (var g in groupsNotFromNY)
            {
                Console.WriteLine($"{y}. {g.GroupName}");
                y++;
            }
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            IEnumerable<Artist> wtcMembers = Artists.Where(a => a.Group.GroupName == "Wu-Tang Clan");

            Console.WriteLine("Display the artist names of all members of the group 'Wu-Tang Clan'");
            foreach (var a in wtcMembers)
            {
                Console.WriteLine($"{a.ArtistName}");
            }

        }
    }
}
