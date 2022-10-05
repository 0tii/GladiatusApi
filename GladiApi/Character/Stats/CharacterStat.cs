namespace GladiApi
{
    public class CharacterStat
    {
        private int _baseValue;
        private int _value;
        private int _maxValue;

        public CharacterStat(int value, int baseValue, int maxValue)
        {
            _baseValue = baseValue;
            _value = value;
            _maxValue = maxValue;
        }

        public int BaseValue { get => _baseValue; }
        public int Value { get => _value; }
        public int MaxValue { get => _maxValue; }
    }
}
