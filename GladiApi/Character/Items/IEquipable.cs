namespace GladiApi
{
    public interface IEquipable
    {
        public StatBonus? DamageBonus { get; }
        public StatBonus? ArmorBonus { get; }
        public StatBonus? HealthBonus { get; }
        public StatBonus? Strength { get; }
        public StatBonus? Dexterity { get; }
        public StatBonus? Agility { get; }
        public StatBonus? Constitution { get; }
        public StatBonus? Charisma { get; }
        public StatBonus? Intelligence { get; }
        public StatBonus? Upgrade { get; }
        public Durability Durability { get; }
        public Durability Conditioning { get; }
        public ItemSlot Slot { get; }

        public void Initialize(List<StatBonus> stats, Durability durability, Durability conditioning);
        public void AddUpgrade(StatBonus upgrade);
    }
}
