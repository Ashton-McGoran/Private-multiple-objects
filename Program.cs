using System;

namespace PrivateMultipleObjects
{
    // Base class
    class Club
    {
        private string clubName;
        private int membersCount;
        private string location;

        // Default constructor
        public Club()
        {
            clubName = "Unknown Club";
            membersCount = 0;
            location = "Unknown Location";
        }

        // Parameterized constructor
        public Club(string name, int count, string loc)
        {
            clubName = name;
            membersCount = count;
            location = loc;
        }

        // Getters and setters
        public string GetClubName()
        {
            return clubName;
        }

        public void SetClubName(string name)
        {
            clubName = name;
        }

        public int GetMembersCount()
        {
            return membersCount;
        }

        public void SetMembersCount(int count)
        {
            membersCount = count;
        }

        public string GetLocation()
        {
            return location;
        }

        public void SetLocation(string loc)
        {
            location = loc;
        }

        // Virtual methods
        public virtual void AddMember()
        {
            membersCount++;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Club Name: {clubName}");
            Console.WriteLine($"Members Count: {membersCount}");
            Console.WriteLine($"Location: {location}");
        }
    }

    // Derived class
    class GamingClub : Club
    {
        private string gameTitle;
        private int tournamentsWon;

        // Default constructor
        public GamingClub()
        {
            gameTitle = "Unknown Game";
            tournamentsWon = 0;
        }

        // Parameterized constructor
        public GamingClub(string name, int count, string loc, string game)
            : base(name, count, loc)
        {
            gameTitle = game;
        }

        // Getters and setters
        public string GetGameTitle()
        {
            return gameTitle;
        }

        public void SetGameTitle(string game)
        {
            gameTitle = game;
        }

        public int GetTournamentsWon()
        {
            return tournamentsWon;
        }

        public void SetTournamentsWon(int won)
        {
            tournamentsWon = won;
        }

        // Override base class methods
        public override void AddMember()
        {
            base.AddMember();
            tournamentsWon++; // Increment tournaments won
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Game Title: {gameTitle}");
            Console.WriteLine($"Tournaments Won: {tournamentsWon}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to input the number of clubs
            Console.Write("Enter the number of clubs: ");
            int numClubs = int.Parse(Console.ReadLine());

            // Create an array of base class objects
            Club[] clubs = new Club[numClubs];

            // Input club details
            for (int i = 0; i < numClubs; i++)
            {
                Console.WriteLine($"\nEnter details for Club {i + 1}:");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Members Count: ");
                int membersCount = int.Parse(Console.ReadLine());

                Console.Write("Location: ");
                string location = Console.ReadLine();

                Console.Write("Is it a gaming club? (yes/no): ");
                string isGamingClub = Console.ReadLine().ToLower();

                if (isGamingClub == "yes")
                {
                    Console.Write("Game Title: ");
                    string gameTitle = Console.ReadLine();

                    clubs[i] = new GamingClub(name, membersCount, location, gameTitle);
                }
                else
                {
                    clubs[i] = new Club(name, membersCount, location);
                }
            }

            // Display club information
            Console.WriteLine("\nClub Information:");
            foreach (var club in clubs)
            {
                club.AddMember(); // Adding a member to each club
                club.DisplayInfo();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
