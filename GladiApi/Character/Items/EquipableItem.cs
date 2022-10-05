namespace GladiApi
{
    public class EquipableItem : BaseItem, IEquipable
    {
        protected StatBonus? damageBonus;
        protected StatBonus? armorBonus;
        protected StatBonus? healthBonus;

        protected StatBonus? strength;
        protected StatBonus? dexterity;
        protected StatBonus? agility;
        protected StatBonus? constitution;
        protected StatBonus? charisma;
        protected StatBonus? intelligence;

        protected StatBonus? upgrade;

        protected Durability durability;
        protected Durability conditioning;

        public EquipableItem(int id, Rarity rarity, string name, int value, int level) : base(id, rarity, name, value, level)
        {
        }

        /// <summary>
        /// Add stat bonuses and other information to the item. A single <see cref="StatBonus"/> includes both absolute and percentage boni.
        /// </summary>
        public virtual void Initialize(List<StatBonus> stats, Durability durability, Durability conditioning)
        {
            foreach (var item in stats)
            {
                switch (item.TargetStat)
                {
                    case CharacterStats.Strength:
                        Strength = item;
                        break;
                    case CharacterStats.Damage:
                        DamageBonus = item;
                        break;
                    case CharacterStats.Armor:
                        ArmorBonus = item;
                        break;
                    case CharacterStats.Dexterity:
                        Dexterity = item;
                        break;
                    case CharacterStats.Agility:
                        Agility = item;
                        break;
                    case CharacterStats.Constitution:
                        Constitution = item;
                        break;
                    case CharacterStats.Charisma:
                        Charisma = item;
                        break;
                    case CharacterStats.Intelligence:
                        Intelligence = item;
                        break;
                    case CharacterStats.Upgrade:
                        Upgrade = item;
                        break;
                    default:
                        break;
                }
            }
            this.durability = durability;
            this.conditioning = conditioning;
        }

        public StatBonus? DamageBonus { get => damageBonus; private set => damageBonus = value; }
        public StatBonus? ArmorBonus { get => armorBonus; private set => armorBonus = value; }
        public StatBonus? HealthBonus { get => healthBonus; private set => healthBonus = value; }
        public StatBonus? Strength { get => strength; private set => strength = value; }
        public StatBonus? Dexterity { get => dexterity; private set => dexterity = value; }
        public StatBonus? Agility { get => agility; private set => agility = value; }
        public StatBonus? Constitution { get => constitution; private set => constitution = value; }
        public StatBonus? Charisma { get => charisma; private set => charisma = value; }
        public StatBonus? Intelligence { get => intelligence; private set => intelligence = value; }
        public Durability Durability { get => durability; private set => durability = value; }
        public Durability Conditioning { get => conditioning; private set => conditioning = value; }
        public StatBonus? Upgrade { get => upgrade; private set => upgrade = value; }
    }
}
