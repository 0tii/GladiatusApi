using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    public class EquipableItem : BaseItem, IEquipable
    {
        private StatBonus? _damage;
        private StatBonus? _armor;
                           
        private StatBonus? _strength;
        private StatBonus? _dexterity;
        private StatBonus? _agility;
        private StatBonus? _constitution;
        private StatBonus? _charisma;
        private StatBonus? _intelligence;

        private StatBonus? _upgrade;

        private (int, int) _durability;
        private (int, int) _conditioning;

        public EquipableItem(int id, Rarity rarity, string name, int value, int level) : base(id, rarity, name, value, level)
        {
        }

        public StatBonus? Damage { get => _damage; private set => _damage = value; }
        public StatBonus? Armor { get => _armor; private set => _armor = value; }
        public StatBonus? Strength { get => _strength; private set => _strength = value; }
        public StatBonus? Dexterity { get => _dexterity; private set => _dexterity = value; }
        public StatBonus? Agility { get => _agility; private set => _agility = value; }
        public StatBonus? Constitution { get => _constitution; private set => _constitution = value; }
        public StatBonus? Charisma { get => _charisma; private set => _charisma = value; }
        public StatBonus? Intelligence { get => _intelligence; private set => _intelligence = value; }
        public (int, int) Durability { get => _durability; private set => _durability = value; }
        public (int, int) Conditioning { get => _conditioning; private set => _conditioning = value; }
        public StatBonus? Upgrade { get => _upgrade; private set => _upgrade = value; }

        public void Initialize(Dictionary<ItemStats, StatBonus> stats, (int, int) durability, (int, int) conditioning)
        {
            foreach(var item in stats)
            {
                switch (item.Key)
                {
                    case ItemStats.Strength:
                        Strength = item.Value;
                        break;
                    case ItemStats.Damage:
                        Damage = item.Value;
                        break;
                    case ItemStats.Armor:
                        Armor = item.Value;
                        break;
                    case ItemStats.Dexterity:
                        Dexterity = item.Value;
                        break;
                    case ItemStats.Agility:
                        Agility = item.Value;
                        break;
                    case ItemStats.Constitution:
                        Constitution = item.Value;
                        break;
                    case ItemStats.Charisma:
                        Charisma = item.Value;
                        break;
                    case ItemStats.Intelligence:
                        Intelligence = item.Value;
                        break;
                    case ItemStats.Upgrade:
                        Upgrade = item.Value;
                        break;
                    default:
                        break;
                }
            }
            _durability = durability;
            _conditioning = conditioning;
        }
    }
}
