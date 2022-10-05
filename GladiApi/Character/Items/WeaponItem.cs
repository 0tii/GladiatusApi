namespace GladiApi
{
    public class WeaponItem : EquipableItem
    {
        protected MainItemStat damage;

        public WeaponItem(int id, MainItemStat damage, Rarity rarity, string name, int value, int level) : base(id, rarity, name, value, level)
        {
            this.damage = damage;
        }

        public MainItemStat Damage { get => damage; set => damage = value; }
    }
}
