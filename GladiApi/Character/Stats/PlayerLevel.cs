using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    public class PlayerLevel : FiniteStat
    {
        private int _level;

        public PlayerLevel(int level, int currenValue, int maxValue) : base(currenValue, maxValue)
        {
            _level = level;
        }

        public int Level { get => _level; set => _level = value; }

    }
}
