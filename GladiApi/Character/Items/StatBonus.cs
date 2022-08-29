namespace GladiApi
{
    /// <summary>
    /// Represents a stat bonus on an item such as Charisma
    /// </summary>
    public class StatBonus
    {
        private ItemStats _targetStat;
        private int _absoluteBonus;
        private int _percentageBonus;

        public StatBonus(ItemStats name, int absoluteBonus, int percentageBonus)
        {
            _targetStat = name;
            _absoluteBonus = absoluteBonus;
            _percentageBonus = percentageBonus;
        }   

        public ItemStats TargetStat { get => _targetStat; }
        public int AbsoluteBonus { get => _absoluteBonus; }
        public int PercentageBonus { get => _percentageBonus; }
    }
}
