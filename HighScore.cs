using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Hangman_Game
{
    class HighScore
    {

        public List<HighScoreType> _highScore;
        public string _textFilePath = @"..\..\DATA\highscore.txt";

        public HighScore()
        {
            _highScore = new List<HighScoreType>();
            ClearHighScore();
        }

        public void Add(string Name, DateTime Date, int Time, int Try, string Word)
        {
            _highScore.Add(new HighScoreType { Name = Name, Date = Date, Time = Time, Try = Try, Word = Word });
            SaveToFile();
        }

        private void ClearHighScore()
        {
            _highScore.Clear();
            LoadFromFile();
            SortHighScoreByTime();
        }

        public void ShowHighScore()
        {
            ClearHighScore();
            // name   | date             | guessing_time | guessing_tries | guessed_word
            Console.Clear();
            Console.WriteLine("Name\t\t | Date\t\t\t\t | Guessing Time\t | Guessing Tries\t | Guessed Word");
            try
            {
                foreach (var item in _highScore)
                {
                    Console.WriteLine(String.Format("{0}\t\t {1}\t\t\t {2}\t\t {3}\t\t\t {4}", item.Name, item.Date, item.Time, item.Try, item.Word));
                }
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine("Null reference - " + ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Index out of range - " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong - " + ex.Message);
            }
        }

        private void SortHighScoreByTime()
        {
            List<HighScoreType> _sortedList = _highScore.OrderBy(o => o.Time).ToList();
            _highScore = _sortedList;
        }

        public void SaveToFile()//string Name, DateTime Date, int Time, int Try, string Word)
        {
            SortHighScoreByTime();
            FileStream _stream = null;
            int _count = 0;
            try
            {
                _stream = new FileStream(_textFilePath, FileMode.Append);

                using (StreamWriter _writer = new StreamWriter(_stream, Encoding.UTF8))
                {
                    foreach (var _item in _highScore)
                    {
                        _writer.Write(_item.Name + "|");
                        _writer.Write(_item.Date.ToString() + "|");
                        _writer.Write(_item.Time.ToString() + "|");
                        _writer.Write(_item.Try.ToString() + "|");
                        _writer.Write(_item.Word);
                        _writer.Write("\n");
                        _count++;

                        if (_count == 10)
                        {
                            break;
                        }
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Argument null exception - " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something were wrong - " + ex.Message);
            }
            finally
            {
                _stream.Dispose();
            }
        }

        public void LoadFromFile()
        {
            try
            {
                var fileStream = new FileStream(_textFilePath, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var _split = line.Split('|');
                        DateTime _date;
                        DateTime.TryParse(_split[1], out _date);
                        int _time;
                        Int32.TryParse(_split[2], out _time);
                        int _try;
                        Int32.TryParse(_split[3], out _try);
                        _highScore.Add(new HighScoreType { Name = _split[0], Date = _date, Time = _time, Try = _try, Word = _split[4]});
                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Directory not found - " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found - " + ex.Message);
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine("File is corrupted - " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something were wrong - " + ex.Message);
            }
        }
    }
}
