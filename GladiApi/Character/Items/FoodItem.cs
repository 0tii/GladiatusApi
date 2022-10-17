namespace GladiApi
{
    public class FoodItem : UsableItem
    {
        public FoodItem(int id, Rarity rarity, string name, int goldValue, int level, ItemDimension dimension, StatBonus bonus) : base(id, rarity, name, goldValue, level, dimension, bonus)
        {
        }
    }
}
