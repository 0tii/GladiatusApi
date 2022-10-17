namespace GladiApi
{
    public sealed class UpgradeItem : UsableItem
    {
        public UpgradeItem(int id, Rarity rarity, string name, int goldValue, int level, ItemDimension dimension, StatBonus bonus) : base(id, rarity, name, goldValue, level, dimension, bonus)
        {
        }
    }
}
