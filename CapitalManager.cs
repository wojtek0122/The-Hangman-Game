using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Hangman_Game
{
    public class CapitalManager
    {
        public List<Capital> _listCapitals;
        public string _textFilePath = @"..\..\DATA\countries_and_capitals.txt";
        public Capital _currentSelected = null;

        public CapitalManager(string TextFilePath)
        {
            CreateNewCapitalList();
            LoadDataFromTextFile(TextFilePath);
        }

        private void CreateNewCapitalList()
        {
            _listCapitals = new List<Capital>();
        }

        private void LoadDataFromTextFile(string TextFilePath)
        {
            var fileStream = new FileStream(@"..\DATA\countries_and_capitals.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var _splitCharIndex = line.IndexOf('|', 0);
                    _listCapitals.Add(new Capital { Country = line.Substring(0, _splitCharIndex - 1), City = line.Substring(_splitCharIndex + 1, line.Length) } );
                }
            }
        }
    }
}
