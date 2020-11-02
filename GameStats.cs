using System;
using System.Collections.Generic;

namespace The_Hangman_Game
{
    class GameStats
    {
        private DateTime _startGameTime;
        private DateTime _endGameTime;

        public List<char> _guessedLetter;
        public List<char> _notInWordLetter;

        public GameStats() : this(StartLifePoint: 5)
        {

        }

        public GameStats(int StartLifePoint)
        {
            LifePoint = StartLifePoint;
            _startGameTime = DateTime.Now;
            _guessedLetter = new List<char>();
            _notInWordLetter = new List<char>();
            TryCount = 0;
        }

        public int LifePoint
        {
            get; set;
        }

        public int TryCount
        {
            get; set;
        }

        /// <summary>
        /// Return duration game time
        /// </summary>
        /// <returns></returns>
        public int GetGameTime()
        {
            _endGameTime = DateTime.Now;
            var time = _endGameTime - _startGameTime;
            return (int)time.TotalSeconds;
        }
    }
}
