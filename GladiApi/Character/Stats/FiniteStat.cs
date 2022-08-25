using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    public class FiniteStat
    {
        protected int _currenValue;
        protected int _maxValue;

        public FiniteStat(int currenValue, int maxValue)
        {
            _currenValue = currenValue;
            _maxValue = maxValue;
        }

        public int CurrenValue { get => _currenValue; set => _currenValue = value; }
        public int MaxValue { get => _maxValue; set => _maxValue = value; }
    }
}
