using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Hangman_Game
{
    class HighScoreType
    {
        // name   | date             | guessing_time | guessing_tries | guessed_word
        // Marcin | 26.10.2016 14:15 | 45            | 3              | Warsaw

        public string Name
        {
            get; set;
        }

        public DateTime Date
        {
            get; set;
        }

        public int Time
        {
            get; set;
        }

        public int Try
        {
            get; set;
        }

        public string Word
        {
            get; set;
        }
    }
}
