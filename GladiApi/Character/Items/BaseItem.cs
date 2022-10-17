using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    /// <summary>
    /// Represents a gladiatus item.
    /// </summary>
    public abstract class BaseItem
    {
        protected int id;
        protected int typeId;
        protected Rarity rarity;
        protected string name;
        protected int goldValue;
        protected int level;
        protected ItemDimension dimensions;

        public BaseItem(int id, Rarity rarity, string name, int goldValue, int level, ItemDimension dimensions)
        {
            this.id = id;
            this.rarity = rarity;
            this.name = name;
            this.goldValue = goldValue;
            this.level = level;
            this.dimensions = dimensions;
        }

        public Rarity Rarity { get => rarity; }
        public string Name { get => name; }
        public int GoldValue { get => goldValue; }
        public int Level { get => level; }
        public int TypeId { get => typeId; }
        public ItemDimension Dimensions { get => dimensions; }
    }
}
