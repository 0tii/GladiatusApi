namespace GladiApi
{
    public interface IEquipable
    {
        public StatBonus? Damage { get; }
        public StatBonus? Armor { get; }
        public StatBonus? Strength { get; }
        public StatBonus? Dexterity { get; }
        public StatBonus? Agility { get; }
        public StatBonus? Constitution { get; }
        public StatBonus? Charisma { get; }
        public StatBonus? Intelligence { get; }
        public StatBonus? Upgrade { get; }
        public Durability Durability { get; }
        public Durability Conditioning { get; }

        public void Initialize(List<StatBonus> stats, Durability durability, Durability conditioning);
    }
}
