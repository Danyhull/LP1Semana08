using System;
using System.Collections.Generic;

namespace PlayerManager3
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The list of all players.
        /// </summary>
        private List<Player> _playerList;

        /// <summary>
        /// Program begins here.
        /// </summary>
        private static void Main()
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
            // Initialize the player list with two players using collection
            // initialization syntax
            _playerList = new List<Player>() {
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
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers(_playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                        break;
                }

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "4");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine("\n======= MENU =======\n");
            Console.WriteLine("1. Insert new Player;\n");
            Console.WriteLine("2. List all Players;\n");
            Console.WriteLine("3. List all Players with a specified score;\n");
            Console.WriteLine("4. Quit Program.\n");
            Console.WriteLine("=============================");
            Console.Write("\nInsert option:\n> ");
        }

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer()
        {
            Console.Write("\nInsert player name:\n>");
            string _name = Console.ReadLine();

            Console.Write("\nInsert Player Score:\n> ");
            int _score =int.Parse(Console.ReadLine());

            Player newPlayer = new Player(_name, _score);
            _playerList.Add(newPlayer);
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
        private static void ListPlayers(IEnumerable<Player> _playersToList)
        {
           Console.WriteLine("\nList of players:\n");

           foreach (Player p in _playersToList)
           {
                Console.WriteLine($"{p.Name} Score={p.Score}");
           }
           Console.WriteLine("");
        }

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            Console.Write("\nInsert the minium score:\n>");
            int _minScore =int.Parse(Console.ReadLine());

            IEnumerable<Player> _newList = GetPlayersWithScoreGreaterThan(_minScore);
            ListPlayers(_newList);
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int _minScore)
        {
            foreach (Player p in _playerList)
            {
                if (p.Score > _minScore)
                {
                    yield return p;
                }
            }
        }
    }
}