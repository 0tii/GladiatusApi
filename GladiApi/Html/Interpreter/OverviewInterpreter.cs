using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    /// <summary>
    /// Interprets information from the overview page, such as:<br/>
    /// - Skills <br/>
    /// - Stats (Armor / Damage) <br/>
    /// - Loadout <br/>
    /// - (Inventory) 
    /// </summary>
    public class OverviewInterpreter : HtmlInterpreter
    {
        private CharacterStat _damage;
        private CharacterStat _armor;

        private CharacterStat _strength;
        private CharacterStat _dexterity;
        private CharacterStat _agility;
        private CharacterStat _constitution;
        private CharacterStat _charisma;
        private CharacterStat _intelligence;

        public OverviewInterpreter(string html) : base(html)
        {
            _damage = GetStatFromIdAttribute(OverviewSelectors.DamageId, OverviewSelectors.TooltipAttribute, 0, 4, 1);
            _armor = GetStatFromIdAttribute(OverviewSelectors.ArmorId, OverviewSelectors.TooltipAttribute, 0, 0, 0);
            _strength = GetStatFromIdAttribute(OverviewSelectors.StrengthId, OverviewSelectors.TooltipAttribute, 0, 3, 4);
            _dexterity = GetStatFromIdAttribute(OverviewSelectors.DexterityId, OverviewSelectors.TooltipAttribute, 0, 3, 4);
            _agility = GetStatFromIdAttribute(OverviewSelectors.AgilityId, OverviewSelectors.TooltipAttribute, 0, 3, 4);
            _constitution = GetStatFromIdAttribute(OverviewSelectors.ConstitutionId, OverviewSelectors.TooltipAttribute, 0, 3, 4);
            _charisma = GetStatFromIdAttribute(OverviewSelectors.CharismaId, OverviewSelectors.TooltipAttribute, 0, 3, 4);
            _intelligence = GetStatFromIdAttribute(OverviewSelectors.IntelligenceId, OverviewSelectors.TooltipAttribute, 0, 3, 4);
        }

        private CharacterStat GetStatFromIdAttribute(string id, string attributeName, int valueIndex, int baseIndex, int maxIndex)
        {
            var tooltipValues = GetAttributeValueById(id, attributeName).ExtractIntegers();
            return new CharacterStat(tooltipValues[valueIndex], tooltipValues[baseIndex], tooltipValues[maxIndex]);
        }

        public CharacterStat Strength { get => _strength; }
        public CharacterStat Dexterity { get => _dexterity; }
        public CharacterStat Agility { get => _agility; }
        public CharacterStat Constitution { get => _constitution; }
        public CharacterStat Charisma { get => _charisma; }
        public CharacterStat Intelligence { get => _intelligence; }
        public CharacterStat Damage { get => _damage; }
        public CharacterStat Armor { get => _armor; }
    }
}
