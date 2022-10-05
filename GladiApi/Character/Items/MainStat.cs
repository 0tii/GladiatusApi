namespace GladiApi
{
    /// <summary>
    /// Main Stat such as Damage or Armor
    /// </summary>
    public class MainItemStat
    {
        private int _minValue;
        private int _maxValue;

        public MainItemStat(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public int MinValue { get => _minValue; }
        public int MaxValue { get => _maxValue; }
    }
}
