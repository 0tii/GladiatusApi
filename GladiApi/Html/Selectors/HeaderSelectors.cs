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
        //--------{ Id's }--------//

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
        /// <summary>Target Values: Inner Text</summary>
        public const string ExpeditionPoints = "expeditionpoints_value_point";
        /// <summary>Target Values: Inner Text</summary>
        public const string MaxExpeditionPoints = "expeditionpoints_value_pointmax";
        /// <summary>Target Values: Inner Text</summary>
        public const string DungeonPoints = "dungeonpoints_value_point";
        /// <summary>Target Values: Inner Text</summary>
        public const string MaxDungeonPoints = "dungeonpoints_value_pointmax";
        /// <summary>Target Values: Inner Text</summary>
        public const string ExpeditionBar = "cooldown_bar_text_expedition";
        /// <summary>Target Values: Inner Text</summary>
        public const string DungeonBar = "cooldown_bar_text_dungeon";
        /// <summary>Target Values: Inner Text</summary>
        public const string ExpeditionDetails = "icon_expeditionpoints";
        /// <summary>Target Values: Inner Text</summary>
        public const string DungeonDetails = "icon_dungeonpoints";
        /// <summary>Target Values: Inner Text</summary>
        public const string ServerTime = "server-time";

        //--------{ Attributes }--------//

        public const string XpAttribute = "data-tooltip";
        public const string CurrentHealthAttribute = "data-value";
        public const string MaxHealthAttribute = "data-max-value";
        public const string HealthRegenAttribute = "data-regen-per-hour";
        public const string ExpeditionDetailsAttribute = "data-tooltip";
        public const string DungeonDetailsAttribute = "data-tooltip";
        public const string ServerTimeAttribute = "data-start-time";
    }
}
