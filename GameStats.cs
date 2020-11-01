using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Hangman_Game
{
    class GameStats
    {
        private DateTime _startGameTime;
        private DateTime _endGameTime;

        public GameStats() : this(StartLifePoint: 5)
        {

        }

        public GameStats(int StartLifePoint)
        {
            LifePoint = StartLifePoint;
            _startGameTime = DateTime.Now;
        }

        public int LifePoint
        {
            get; set;
        }

        public int GetGameTime()
        {
            _endGameTime = DateTime.Now;
            var time = _endGameTime - _startGameTime;
            return (int)time.TotalSeconds;
        }
    }
}
