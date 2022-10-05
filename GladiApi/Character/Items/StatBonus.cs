namespace GladiApi
{
    /// <summary>
    /// Represents a stat bonus on an item such as Charisma
    /// </summary>
    public class StatBonus
    {
        private CharacterStats _targetStat;
        private int _absoluteBonus;
        private int _percentageBonus;

        public StatBonus(CharacterStats name, int absoluteBonus, int percentageBonus)
        {
            _targetStat = name;
            _absoluteBonus = absoluteBonus;
            _percentageBonus = percentageBonus;
        }   

        public CharacterStats TargetStat { get => _targetStat; }
        public int AbsoluteBonus { get => _absoluteBonus; }
        public int PercentageBonus { get => _percentageBonus; }
    }
}
