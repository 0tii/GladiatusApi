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
    public class Item
    {
        protected int _id;
        protected Rarity _rarity;
        protected string _name;
        protected int _value;
        protected int _level;
        protected (int, int) _durability;
        protected (int, int) _conditioning;

    }
}
