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
        private List<Capital> _listCapitals;

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

        }
    }
}
