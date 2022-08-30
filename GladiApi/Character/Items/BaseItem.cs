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
        protected int value;
        protected int level;
        protected (int, int) dimensions;

        public BaseItem(int id, Rarity rarity, string name, int value, int level)
        {
            this.id = id;
            this.rarity = rarity;
            this.name = name;
            this.value = value;
            this.level = level;
        }

        public Rarity Rarity { get => rarity; }
        public string Name { get => name; }
        public int Value { get => value; }
        public int Level { get => level; }
        public int TypeId { get => typeId; }
        public (int, int) Dimensions { get => dimensions; }
    }
}
