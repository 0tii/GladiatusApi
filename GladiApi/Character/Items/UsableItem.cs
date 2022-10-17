namespace GladiApi
{
    public class UsableItem : BaseItem
    {
        protected StatBonus bonus;

        public UsableItem(int id, Rarity rarity, string name, int goldValue, int level, ItemDimension dimension, StatBonus bonus) : base(id, rarity, name, goldValue, level, dimension)
        {
            this.bonus = bonus;
        }

        public StatBonus Bonus { get => bonus; }
    }
}
