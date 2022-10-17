namespace GladiApi
{
    public sealed class ArmorItem : EquipableItem
    {
        private MainItemStat _armor;

        public ArmorItem(int id, MainItemStat armorValue, Rarity rarity, string name, int value, int level, ItemDimension dimensions) : base(id, rarity, name, value, level, dimensions)
        {
            _armor = armorValue;
        }

        public MainItemStat Armor { get => _armor; }
    }
}
