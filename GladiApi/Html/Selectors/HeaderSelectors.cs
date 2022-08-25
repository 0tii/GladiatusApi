using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    /// <summary>
    /// Enum-like static class wrapping html selectors for the page header
    /// </summary>
    public static class HeaderSelectors
    {
        //--------{ Ids }--------//

        /// <summary>Target Value: Inner Text</summary>
        public const string Gold = "sstat_gold_val";
        /// <summary>Target Value: Inner Text</summary>
        public const string Rubies = "sstat_ruby_val";
        /// <summary>Target Value: Inner Text</summary>
        public const string LeaderboardRank = "highscorePlace";
        /// <summary>Target Value: Inner Text</summary>
        public const string Level = "header_values_level";

        /// <summary>Target Values: Property <i>data-tooltip</i></summary>
        public const string Experience = "header_values_xp_bar";
        /// <summary>Target Values: Property <i>data-max-value / data-value / data-regen-per-hour</i></summary>
        public const string Health = "header_values_hp_bar";

        //--------{ Attributes }--------//


        public const string XpAttribute = "data-tooltip";
        public const string CurrentHealthAttribute = "data-value";
        public const string MaxHealthAttribute = "data-max-value";
        public const string HealthRegenAttribute = "data-regen-per-hour";
    }
}
