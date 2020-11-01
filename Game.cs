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

        private void Play()
        {
            CapitalManager _capitalManager = new CapitalManager();
            var _cap = _capitalManager.SelectRandomCapital();

            GameStats _gameStats = new GameStats();
            var _choice = "!";

            while(_gameStats.LifePoint>=0)
            {

                Console.Clear();
                Console.WriteLine("Life point(s): " + _gameStats.LifePoint + "\n\n\n");

                DrawHangman(_gameStats.LifePoint);

                Console.Write("\t");
                foreach(var item in _cap.City)
                {
                    Console.Write("_ ");
                }
                Console.WriteLine();

                if(_gameStats.LifePoint<2)
                {
                    Console.WriteLine("\nThe capital of " + _cap.Country);
                }

                if (_gameStats.LifePoint == 0)
                {
                    Console.WriteLine("\nYOU ARE LOOSER!");
                    //loose game
                    break;
                }

                Console.WriteLine("\nGuess letter [1] or word [2]?");
                while(_choice != "1" || _choice != "2")
                {
                    Console.Write("Choice: ");
                    _choice = Console.ReadLine();
                }

                Console.WriteLine("\nType letter or '!' to quit the game");

                //Exit - type '!'
                _choice = Console.ReadLine();
                if(_choice == "!")
                {
                    break;
                }
            }
        }
    }
}
