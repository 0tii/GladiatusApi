namespace GladiApi
{
    public sealed class WeaponItem : EquipableItem
    {
        private MainItemStat _damage;

        public WeaponItem(int id, MainItemStat damage, Rarity rarity, string name, int value, int level, ItemDimension dimensions) : base(id, rarity, name, value, level, dimensions)
        {
            _damage = damage;
        }

        public MainItemStat Damage { get => _damage; }
    }
}
