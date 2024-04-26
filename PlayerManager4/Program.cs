﻿using System;
using System.Collections.Generic;

namespace PlayerManager4
{
    class Program
    {
        private List<Player> _playerList;
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Start();
        }
        private Program()
        {
            _playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
        }
        private void Start()
        {
            string _userOption;

            do
            {
                _playerList.Sort();
                ShowMenu();
                _userOption = Console.ReadLine();

                switch(_userOption)
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
            } while (_userOption != "4");
        }
        private void ShowMenu()
        {
            Console.WriteLine("\n======= PROGRAM MENU =======\n");
            Console.WriteLine("1. Insert new Player;\n");
            Console.WriteLine("2. List all Players;\n");
            Console.WriteLine("3. List all Players with a specified score;\n");
            Console.WriteLine("4. Quit Program.\n");
            Console.WriteLine("=============================");
            Console.Write("\nInsert option:\n> ");
        }
        private void InsertPlayer()
        {
            Console.Write("\nInsert player name:\n> ");
            string _name = Console.ReadLine();

            Console.Write("\nInsert player score:\n> ");
            int _score = int.Parse(Console.ReadLine());

            Player newPlayer = new Player(_name,_score);
            _playerList.Add(newPlayer);
        }
        private static void ListPlayers(List<Player> _playerToList)
        {
            ShowListOrderMenu();
            string _userOption = Console.ReadLine();

            switch(_userOption)
            {
                case "1":
                    _playerToList.Sort();
                    break;
                case "2":
                    _playerToList.Sort(new CompareByName(true));
                    break;
                case "3":
                    _playerToList.Sort(new CompareByName(false));
                    break;
                default:
                    Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                    ListPlayers(_playerToList);
                    break;
            }

            Console.WriteLine("\nList of players:\n");

            foreach (Player p in _playerToList)
            {
                Console.WriteLine($"{p.Name} Score={p.Score}");
            }

            Console.WriteLine("");
        }
        private void ListPlayersWithScoreGreaterThan()
        {
            Console.Write("\nInsert the minimum score:\n> ");
            int _minScore = int.Parse(Console.ReadLine());

            List<Player> _newList = new List<Player>(GetPlayersWithScoreGreaterThan(_minScore));

            ListPlayers(_newList);
        }
        private static void ShowListOrderMenu()
        {
            Console.WriteLine("\n======= LIST ORDER MENU =======\n");
            Console.WriteLine("1. Score, descending order;\n");
            Console.WriteLine("2. Names, ascending order;\n");
            Console.WriteLine("3. Names, ascending order\n");
            Console.WriteLine("=================================");
            Console.Write("\nInsert option:\n> ");
        }
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