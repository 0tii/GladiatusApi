using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    public sealed class CharacterStatManager
    {
        private CharacterStat? _damage;
        private CharacterStat? _armor;

        private CharacterStat? _strength;
        private CharacterStat? _dexterity;
        private CharacterStat? _agility;
        private CharacterStat? _constitution;
        private CharacterStat? _charisma;
        private CharacterStat? _intelligence;

        private FiniteStat? _health;
        private FiniteStat? _level;

        private int _gold;
        private int _rubies;

        private Character _character;

        private CharacterStatManager(Character character)
        {
            _character = character;
        }

        private async Task<CharacterStatManager> InitializeAsync()
        {
            //initialize here

            return this;
        }

        public static async Task<CharacterStatManager> CreateInstanceAsync(Character character)
        {
            CharacterStatManager instance = new(character);
            await instance.InitializeAsync();
            return instance;
        }

        public CharacterStat? Strength { get => _strength; }
        public CharacterStat? Dexterity { get => _dexterity; }
        public CharacterStat? Agility { get => _agility; }
        public CharacterStat? Constitution { get => _constitution; }
        public CharacterStat? Charisma { get => _charisma; }
        public CharacterStat? Intelligence { get => _intelligence; }

        internal FiniteStat? Health { get => _health; }
        internal FiniteStat? Level { get => _level; }

        public int Gold { get => _gold; }
        public int Rubies { get => _rubies; }
    }
}
