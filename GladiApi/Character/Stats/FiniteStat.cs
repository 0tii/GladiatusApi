using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    internal class FiniteStat
    {
        private int _level;
        private int _currenValue;
        private int _maxValue;

        public FiniteStat(int level, int currenValue, int maxValue)
        {
            _level = level;
            _currenValue = currenValue;
            _maxValue = maxValue;
        }

        public int Level { get => _level; set => _level = value; }
        public int CurrenValue { get => _currenValue; set => _currenValue = value; }
        public int MaxValue { get => _maxValue; set => _maxValue = value; }
    }
}
