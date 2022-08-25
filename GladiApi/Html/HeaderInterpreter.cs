using GladiApi.Exceptions;
using System.Globalization;
using System.Linq;


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
        public string debugValue;

        private DateTime _serverTime;

        private string _gold;
        private string _rubies;
        private string _leaderboardPlacement;
        private PlayerLevel _playerLevel;
        private ActionPoints _expeditionPoints;
        private ActionPoints _dungeonPoints;

        //helpers
        private int _level;
        private int _xpToLevelup;
        private int _currentXp;

        public HeaderInterpreter(string html) : base(html)
        {
            //Server time attribute value format: [2022,8,25,23,59,34,455]
            var dateTimeString = GetAttributeValueById(HeaderSelectors.ServerTime, HeaderSelectors.ServerTimeAttribute)[1..^1];

            try
            {
                _serverTime = DateTime.ParseExact(dateTimeString, "yyyy,M,d,HH,m,ss,fff", CultureInfo.InvariantCulture);
            }
            catch(FormatException)
            {
                throw new ParseDateTimeException($"Could not parse server time {dateTimeString} - did the format change?");
            }

            _gold = GetInnerTextById(HeaderSelectors.Gold);
            _rubies = GetInnerTextById(HeaderSelectors.Rubies);
            _leaderboardPlacement = GetInnerTextById(HeaderSelectors.LeaderboardRank);

            var lvl = GetInnerTextById(HeaderSelectors.Level).Trim();

            if (!Int32.TryParse(lvl, out _level))
                throw new ParseIntException($"Could not parse integer from strings '{lvl}'");

            GetExperience();
            _playerLevel = new(_level, _currentXp, _xpToLevelup);
        }

        /// <summary>
        /// Tries reading the experience values from the game page header
        /// </summary>
        /// <exception cref="HtmlFormatChangedException"></exception>
        private void GetExperience()
        {
            //[[[["Experience:","1234 \/ 2345"],["#BA9700","#BA9700"]],[["&nbsp;&nbsp;Required until level XX:",456],["#DDD","#DDD"]]]]
            var xpData = GetAttributeValueById(HeaderSelectors.Experience, HeaderSelectors.XpAttribute);
            PrepareExperience(xpData);            
        }

        /// <summary>
        /// Reads action point data based on document id selectors
        /// </summary>
        /// <returns>Returns </returns>
        /// <exception cref="HtmlElementNotFoundException"></exception>
        /// <exception cref="HtmlAttributeNotFoundEception"></exception>
        private ActionPoints? ReadActionPoints(string valueSelector, string maxValueSelector, string detailSelector, string detailAttribute, string actionBar)
        {
            var current = GetInnerTextById(valueSelector);
            var max = GetInnerTextById(maxValueSelector);
            var details = GetAttributeValueById(detailSelector, detailAttribute);

            //calculate next point availability
            //parse integers

            var bar = GetInnerTextById(actionBar);
            bool cooldown = bar.Any(char.IsDigit);

            return null;
            //return new ActionPoints(current, max, "" , cooldown);
        }

        /// <summary>
        /// Prepares the received Expedition string
        /// </summary>
        /// <exception cref="HtmlFormatChangedException"></exception>
        /// <exception cref="ParseIntException"></exception>
        private void PrepareExperience(string xpData)
        {
            int idx1 = xpData.IndexOf("&quot;,&quot;") + "&quot;,&quot;".Length;
            int idx2 = xpData.IndexOf("&quot;],[");

            if (idx1 == -1 || idx2 == -1)
                throw new HtmlFormatChangedException("Could not read experience data - did the layout change?");

            string[] splitResult = xpData.Substring(idx1, idx2).Split("\\/");
            splitResult[1] = splitResult[1].Split("&")[0];

            if (!Int32.TryParse(splitResult[0].Trim(), out _currentXp) ||
               !Int32.TryParse(splitResult[1].Trim(), out _xpToLevelup))
                throw new ParseIntException($"Could not parse integer from strings '{splitResult[0].Trim()}' and '{splitResult[1].Trim()}'");
        }

        public string Gold { get => _gold; }
        public string Rubies { get => _rubies; }
        public string LeaderboardPlacement { get => _leaderboardPlacement; }
        public PlayerLevel Experience { get => _playerLevel; }
        public ActionPoints ExpeditionPoints { get => _expeditionPoints; }
        public ActionPoints DungeonPoints { get => _dungeonPoints; }
        public DateTime ServerTime { get => _serverTime; }
    }
}