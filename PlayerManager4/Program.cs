﻿using System;
using System.Collections.Generic;

namespace PlayerManager4
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// The list of all players
        private List<Player> playerList;

        // Comparer for comparing player by name (alphabetical order)
        private IComparer<Player> compareByName;

        // Comparer for comparing player by name (reverse alphabetical order)
        private IComparer<Player> compareByNameReverse;

        /// <summary>
        /// Program begins here.
        /// </summary>
        /// <param name="args">Not used.</param>
        private static void Main(string[] args)
        {
            // Create a new instance of the player listing program
            Program prog = new Program();
            // Start the program instance
            prog.Start();
        }

        /// <summary>
        /// Creates a new instance of the player listing program.
        /// </summary>
        private Program()
        {
            // Initialize player comparers
            compareByName = new CompareByName(true);
            compareByNameReverse = new CompareByName(false);

            // Initialize the player list with two players using collection
            // initialization syntax
            playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
        }

        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        private void Start()
        {
            // We keep the user's option here
            string option;

            // Main program loop
            do
            {
                // Show menu and get user option
                ShowMenu();
                option = Console.ReadLine();

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        // Insert player
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers(playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        SortPlayerList();
                        break;
                    case "0":
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                        break;
                }

                // Wait for user to press a key...
                Console.Write("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine("\n");

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "0");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("----\n");
            Console.WriteLine("1. Insert player");
            Console.WriteLine("2. List all players");
            Console.WriteLine("3. List players with score greater than");
            Console.WriteLine("4. Sort players");
            Console.WriteLine("0. Quit\n");
            Console.Write("Your choice > ");
        }

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer()
        {
            // Variables
            string name;
            int score;
            Player newPlayer;

            // Ask for player info
            Console.WriteLine("\nInsert player");
            Console.WriteLine("-------------\n");
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Score: ");
            score = Convert.ToInt32(Console.ReadLine());

            // Create new player and add it to list
            newPlayer = new Player(name, score);
            playerList.Add(newPlayer);
        }

        /// <summary>
        /// Show all players in a list of players. This method can be static
        /// because it doesn't depend on anything associated with an instance
        /// of the program. Namely, the list of players is given as a parameter
        /// to this method.
        /// </summary>
        /// <param name="playersToList">
        /// An enumerable object of players to show.
        /// </param>
        private static void ListPlayers(IEnumerable<Player> playersToList)
        {
            Console.WriteLine("\nList of players");
            Console.WriteLine("-------------\n");

            // Show each player in the enumerable object
            foreach (Player p in playersToList)
            {
                Console.WriteLine($" -> {p.Name} with a score of {p.Score}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            // Minimum score user should have in order to be shown
            int minScore;
            // Enumerable of players with score higher than the minimum score
            IEnumerable<Player> playersWithScoreGreaterThan;

            // Ask the user what is the minimum score
            Console.Write("\nMinimum score player should have? ");
            minScore = Convert.ToInt32(Console.ReadLine());

            // Get players with score higher than the user-specified value
            playersWithScoreGreaterThan =
                GetPlayersWithScoreGreaterThan(minScore);

            // List all players with score higher than the user-specified value
            ListPlayers(playersWithScoreGreaterThan);
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            // Cycle all players in the original player list
            foreach (Player p in playerList)
            {
                // If the current player has a score higher than the
                // given value....
                if (p.Score > minScore)
                {
                    // ...return him as a member of the player enumerable
                    yield return p;
                }
            }
        }

        /// <summary>
        ///  Sort player list by the order specified by the user.
        /// </summary>
        private void SortPlayerList()
        {
            PlayerOrder playerOrder;

            Console.WriteLine("Player order");
            Console.WriteLine("------------");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByScore}. Order by score");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByName}. Order by name");
            Console.WriteLine(
                $"{(int)PlayerOrder.ByNameReverse}. Order by name (reverse)");
            Console.WriteLine("");
            Console.Write("> ");

            playerOrder = Enum.Parse<PlayerOrder>(Console.ReadLine());

            switch (playerOrder)
            {
                case PlayerOrder.ByScore:
                    playerList.Sort();
                    break;
                case PlayerOrder.ByName:
                    playerList.Sort(compareByName);
                    break;
                case PlayerOrder.ByNameReverse:
                    playerList.Sort(compareByNameReverse);
                    break;
                default:
                    Console.Error.WriteLine("\n>>> Unknown player order! <<<\n");
                    break;
            }
        }
    }
}
