using GladiApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    /// <summary>
    /// Tries to interpret the game header. Can extract the following information:<br/>
    /// - Server time (timestamp at the interpretation time) <br/>
    /// - Gold<br/>
    /// - Rubies <br/>
    /// - Ranking <br/>
    /// - Level <br/>
    /// - Expedition points <br/>
    /// - Dungeon points <br/>
    /// - Arena placement <br/>
    /// - Circus Turma placement <br/>
    /// - Notifications
    /// <br/>
    /// <b>Requires html of any page with page header. One of the least selective interpreters.</b>
    /// </summary>
    /// <exception cref="HtmlElementNotFoundException"/>
    public sealed class HeaderInterpreter : HtmlInterpreterBase
    {
        private string _gold;
        private string _rubies;
        private string _leaderboardPlacement;
        private FiniteStat _playerLevel;

        //helpers
        private int _level;
        private int _xpToLevelup;
        private int _currentXp;

        public HeaderInterpreter(string html) : base(html)
        {
            _gold = GetInnerTextById(HeaderSelectors.Gold);
            _rubies = GetInnerTextById(HeaderSelectors.Rubies);
            _leaderboardPlacement = GetInnerTextById(HeaderSelectors.LeaderboardRank);

            var lvl = GetInnerTextById(HeaderSelectors.Level).Trim();
            if (!Int32.TryParse(lvl, out _level))
                throw new ParseIntException($"Could not parse integer from strings '{lvl}'");

            _playerLevel = new(_level, _currentXp, _xpToLevelup);
        }

        /// <summary>
        /// Tries reading the experience values from the game page header
        /// </summary>
        /// <returns>string[] with [0] = current xp and [1] = xp to level up</returns>
        /// <exception cref="HtmlFormatChangedException"></exception>
        private void GetExperience()
        {
            //[[[["Experience:","1234 \/ 2345"],["#BA9700","#BA9700"]],[["&nbsp;&nbsp;Required until level XX:",456],["#DDD","#DDD"]]]]
            var xpData = GetAttributeValueById(HeaderSelectors.Experience, HeaderSelectors.XpAttribute);
            int idx1 = xpData.IndexOf("\",\"");
            int idx2 = xpData.IndexOf("\"],[");

            if (idx1 == -1 || idx2 == -1)
                throw new HtmlFormatChangedException("");

            string[] splitResult = xpData.Substring(idx1, idx2).Split("\\/");
            if (!Int32.TryParse(splitResult[0].Trim(), out _currentXp) ||
               !Int32.TryParse(splitResult[1].Trim(), out _xpToLevelup))
                throw new ParseIntException($"Could not parse integer from strings '{splitResult[0].Trim()}' and '{splitResult[1].Trim()}'");
        }

        public string Gold { get => _gold; }
        public string Rubies { get => _rubies; }
        public string LeaderboardPlacement { get => _leaderboardPlacement; }
        internal FiniteStat Level { get => _playerLevel; }
    }
}
