﻿using System;
using System.Linq;

namespace The_Hangman_Game
{
    class Game
    {
        public HighScore _highScore;
        public string _name;

        /// <summary>
        /// Main game function with main loop
        /// </summary>
        public Game()
        {
            _highScore = new HighScore();
            Run();
        }

        public void Run()
        {
            char _choice = '0';
            while (_choice != '3')
            {
                switch(_choice)
                {
                    case '1':
                        {
                            Play();
                            break;
                        }
                    case '2':
                        {
                            if(_highScore._highScore.Count == 0)
                            {
                                _highScore.LoadFromFile();
                            }
                            _highScore.ShowHighScore();
                            break;
                        }
                    default:
                        {
                            MainMenu();
                            break;
                        }
                }
                _choice = Console.ReadKey().KeyChar;
            }
        }

        /// <summary>
        /// Function draws main menu
        /// </summary>
        private void MainMenu()
        {
            Console.Clear();
            Header();
            DrawHangman(0);
            MenuList();
            Console.Write("Your choice: ");
        }

        /// <summary>
        /// Function draws header of game
        /// </summary>
        private void Header()
        {
            string _header = "The Hangman Game - Motorola Academy";
            Console.SetCursorPosition((Console.WindowWidth - _header.Length) / 2, Console.CursorTop);
            Console.WriteLine(_header + "\n");
        }

        /// <summary>
        /// Function draws Hangman depended of actual life point
        /// </summary>
        /// <param name="HangmanStep">Depended on of current life points draw hangman. Start from 5 to 0.</param>
        private void DrawHangman(int HangmanStep)
        {
            switch(HangmanStep)
            {
                case 0:
                    {
                        Console.WriteLine(@"" +
                              @"    ______   " + "\n" +
                              @"   |      |  " + "\n" +
                              @"   |      O  " + "\n" +
                              @"   |     /|\ " + "\n" +
                              @"   |      |  " + "\n" +
                              @"   |     / \ " + "\n" +
                              @"  / \        " + "\n" +
                              @" /   \       " + "\n");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine(@"" +
                              @"    ______   " + "\n" +
                              @"   |      |  " + "\n" +
                              @"   |      O  " + "\n" +
                              @"   |     /|\ " + "\n" +
                              @"   |      |  " + "\n" +
                              @"   |         " + "\n" +
                              @"  / \        " + "\n" +
                              @" /   \       " + "\n");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(@"" +
                              @"    ______   " + "\n" +
                              @"   |      |  " + "\n" +
                              @"   |      O  " + "\n" +
                              @"   |      |  " + "\n" +
                              @"   |      |  " + "\n" +
                              @"   |         " + "\n" +
                              @"  / \        " + "\n" +
                              @" /   \       " + "\n");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine(@"" +
                              @"    ______   " + "\n" +
                              @"   |      |  " + "\n" +
                              @"   |      O  " + "\n" +
                              @"   |         " + "\n" +
                              @"   |         " + "\n" +
                              @"   |         " + "\n" +
                              @"  / \        " + "\n" +
                              @" /   \       " + "\n");
                        break;
                    }

                case 4:
                    {
                        Console.WriteLine(@"" +
                              @"    ______   " + "\n" +
                              @"   |      |  " + "\n" +
                              @"   |         " + "\n" +
                              @"   |         " + "\n" +
                              @"   |         " + "\n" +
                              @"   |         " + "\n" +
                              @"  / \        " + "\n" +
                              @" /   \       " + "\n");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine(@"" +
                              @"    ______   " + "\n" +
                              @"   |         " + "\n" +
                              @"   |         " + "\n" +
                              @"   |         " + "\n" +
                              @"   |         " + "\n" +
                              @"   |         " + "\n" +
                              @"  / \        " + "\n" +
                              @" /   \       " + "\n");
                        break;
                    }
            }
            
        }

        /// <summary>
        /// Draw menu choice texts
        /// </summary>
        private void MenuList()
        {
            Console.WriteLine("Main menu: ");
            Console.WriteLine("1. Play Game");
            Console.WriteLine("2. View Highscore");
            Console.WriteLine("3. Quit");
        }

        /// <summary>
        /// Restart game function - asking about playing again
        /// </summary>
        private void RestartGame()
        {
            Console.Clear();
            if (_highScore._highScore.Count == 0)
            {
                _highScore.LoadFromFile();
            }
            _highScore.ShowHighScore();
            Console.WriteLine("\nPlay again [y]es or [n]o ?");
            var _letter = 'y';
            do
            {
                Console.Write("Choice: ");
                _letter = Console.ReadKey().KeyChar;
                switch (_letter)
                {
                    case 'y':
                        {
                            Play();
                            break;
                        }
                    case 'n':
                        {
                            Environment.Exit(1);
                            break;
                        }
                }
            } while (_letter != 'y' && _letter != 'n');
        }

        /// <summary>
        /// Main loop of game
        /// </summary>
        private void Play()
        {
            CapitalManager _capitalManager = new CapitalManager();
            var _cap = _capitalManager.SelectRandomCapital();

            GameStats _gameStats = new GameStats();
            var _choice = "!";

            while (_gameStats.LifePoint >= 0)
            {

                Console.Clear();
                Console.WriteLine("Life point(s): " + _gameStats.LifePoint + "\t\tTry count:" + _gameStats.TryCount + "\n\n\n");

                DrawHangman(_gameStats.LifePoint);

                Console.Write("\t");
                foreach (var item in _cap.City)
                {
                    if(_gameStats._guessedLetter.Contains(item))
                    {
                        Console.Write(item + " ");
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                }
                Console.WriteLine("\n");

                Console.WriteLine("Not in word letters: ");
                foreach(var item in _gameStats._notInWordLetter)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();

                if (_gameStats.LifePoint < 2)
                {
                    Console.WriteLine("\nThe capital of " + _cap.Country);
                }

                if (_gameStats.LifePoint == 0)
                {
                    //loose game
                    Console.WriteLine("\nYOU ARE LOOSER!");
                    Console.ReadKey();
                    RestartGame();
                }

                Console.WriteLine("\nGuess [1]letter or [2]word?");

                do
                {
                    Console.Write("Choice: ");
                    _choice = Console.ReadLine().ToUpper();
                } while (_choice != "1" && _choice != "2");

                Console.Write("Type: ");

                switch (_choice)
                {
                    case "1":
                        {
                            var _letter = '1';
                            try
                            {
                                _letter = Console.ReadLine().ToUpper()[0];
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine("Something went wrong - " + ex.Message);
                            }
                            if (_cap.City.Contains(_letter))
                            {
                                _gameStats._guessedLetter.Add(_letter);
                                if(_gameStats._guessedLetter.Count == _cap.City.Length)
                                {
                                    //WIN GAME
                                    WinGame(_gameStats, _cap.City);
                                }
                            }
                            else
                            {
                                _gameStats._notInWordLetter.Add(_letter);
                                _gameStats.LifePoint--;
                            }
                            _gameStats.TryCount++;
                            break;
                        }
                    case "2":
                        {
                            _choice = Console.ReadLine().ToUpper();
                            if (_choice == _cap.City)
                            {
                                //WIN GAME
                                WinGame(_gameStats, _cap.City);
                            }
                            else 
                            {
                                _gameStats.LifePoint -= 2;
                            }
                            _gameStats.TryCount++;
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// RUn if win game, adding to highscore
        /// </summary>
        /// <param name="_gameStats">Current game statistics</param>
        /// <param name="City">City to guessing</param>
        private void WinGame(GameStats _gameStats, string City)
        {
            Console.WriteLine(String.Format("You guessed the capital after {0} letters. It took you {1} seconds.", _gameStats.TryCount, _gameStats.GetGameTime().ToString()));
            Console.Write("Please type your name: ");
            _name = Console.ReadLine();
            _highScore.AddToHighScore(_name, DateTime.Now, _gameStats.GetGameTime(), _gameStats.TryCount, City);
            RestartGame();
        }
    }
}
