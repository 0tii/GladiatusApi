namespace GladiApi
{
    public class ArmorItem : EquipableItem
    {
        protected MainItemStat armor;

        public ArmorItem(int id, MainItemStat armorValue, Rarity rarity, string name, int value, int level) : base(id, rarity, name, value, level)
        {
            armor = armorValue;
        }

        public MainItemStat Armor { get => armor; set => armor = value; }
    }
}
