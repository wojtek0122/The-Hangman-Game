using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Hangman_Game
{
    class Game
    {
        public Game()
        {
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
                            //HighScore();
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

        private void MainMenu()
        {
            Console.Clear();
            Header();
            DrawHangman(0);
            MenuList();
            Console.Write("Your choice: ");
        }

        private void Header()
        {
            string _header = "The Hangman Game - Motorola Academy";
            Console.SetCursorPosition((Console.WindowWidth - _header.Length) / 2, Console.CursorTop);
            Console.WriteLine(_header + "\n");
        }

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

        private void MenuList()
        {
            Console.WriteLine("Main menu: ");
            Console.WriteLine("1. Play Game");
            Console.WriteLine("2. View Highscore");
            Console.WriteLine("3. Quit");
        }

        private void RestartGame()
        {
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
                    RestartGame();
                }

                Console.WriteLine("\nGuess [1]letter or [2]word?");

                do
                {
                    Console.Write("Choice: ");
                    _choice = Console.ReadLine();
                } while (_choice != "1" && _choice != "2");

                Console.Write("Type: ");

                switch (_choice)
                {
                    case "1":
                        {
                            var _letter = Console.ReadKey().KeyChar;
                            if (_cap.City.Contains(_letter))
                            {
                                _gameStats._guessedLetter.Add(_letter);
                                if(_gameStats._guessedLetter.Count == _cap.City.Length)
                                {
                                    //WIN GAME
                                    RestartGame();
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
                            _choice = Console.ReadLine();
                            if (_choice == _cap.City)
                            {
                                //WIN GAME
                                RestartGame();
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
    }
}
