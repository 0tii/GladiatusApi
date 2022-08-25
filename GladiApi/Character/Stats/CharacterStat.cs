using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    public class CharacterStat
    {
        private int _baseValue;
        private int _value;

        public CharacterStat(int baseValue, int value)
        {
            _baseValue = baseValue;
            _value = value;
        }

        public int BaseValue { get => _baseValue; set => _baseValue = value; }
        public int Value { get => _value; set => _value = value; }
    }
}
