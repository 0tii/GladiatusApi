using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    public interface IEquipable
    {
        public StatBonus? Damage { get; }
        public StatBonus? Armor { get; }
        public StatBonus? Strength { get; }
        public StatBonus? Dexterity { get; }
        public StatBonus? Agility { get; }
        public StatBonus? Constitution { get; }
        public StatBonus? Charisma { get; }
        public StatBonus? Intelligence { get; }
        public StatBonus? Upgrade { get; }
        public (int, int) Durability { get; }
        public (int, int) Conditioning { get; }

        public void Initialize(Dictionary<ItemStats, StatBonus> stats, (int, int) durability, (int, int) conditioning);
    }
}
