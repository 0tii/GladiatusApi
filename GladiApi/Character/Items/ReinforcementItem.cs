namespace GladiApi
{
    public sealed class ReinforcementItem : UsableItem
    {
        private int _duration; //in minutes

        public ReinforcementItem(int id, Rarity rarity, string name, int goldValue, int level, ItemDimension dimension, StatBonus bonus, int duration) : base(id, rarity, name, goldValue, level, dimension, bonus)
        {
            _duration = duration;
        }

        /// <summary>
        /// The duration of this reinforcement in minutes
        /// </summary>
        public int Duration { get => _duration; }
    }
}
