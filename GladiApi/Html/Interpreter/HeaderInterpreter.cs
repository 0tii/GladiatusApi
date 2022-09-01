using GladiApi;
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
    /// - (not implemented) Notifications
    /// <br/>
    /// <b>Requires html of any page with page header. One of the least selective interpreters.</b>
    /// </summary>
    /// <exception cref="HtmlElementNotFoundException"/>
    public sealed class HeaderInterpreter : HtmlInterpreterBase
    {
        private DateTime _serverTime;

        private int _gold;
        private int _rubies;
        private int _leaderboardPlacement;

        private FiniteStat _health;

        private PlayerLevel _playerLevel;
        private ActionPoints _expeditionPoints;
        private ActionPoints _dungeonPoints;

        private ActionPoints _arena;
        private ActionPoints _circusTurma;

        public HeaderInterpreter(string html) : base(html)
        {
            //Server time attribute value format: [2022,8,7,9,9,34,455]
            var dateTimeString = GetAttributeValueById(HeaderSelectors.ServerTime, HeaderSelectors.ServerTimeAttribute)[1..^1];

            try
            {
                _serverTime = DateTime.ParseExact(TimeFormatUtility.PrepareDateString(dateTimeString), "yyyy,MM,dd,HH,mm,ss,fff", CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new ParseDateTimeException($"Could not parse server time {TimeFormatUtility.PrepareDateString(dateTimeString)} - did the format change?");
            }

            //----- Gold, Rubies, Rank
            var gold = GetInnerTextById(HeaderSelectors.Gold).Trim().Replace(".", "");
            if (!int.TryParse(gold, out _gold))
                throw new ParseIntException($"Could not parse integer from character gold '{gold}'");

            var rubies = GetInnerTextById(HeaderSelectors.Rubies).Trim().Replace(".", "");
            if (!int.TryParse(rubies, out _rubies))
                throw new ParseIntException($"Could not parse integer from character rubies '{rubies}'");

            var rank = GetInnerTextById(HeaderSelectors.LeaderboardRank).Trim().Replace(".", "");
            if (!int.TryParse(rank, out _leaderboardPlacement))
                throw new ParseIntException($"Could not parse integer from character rank '{rank}'");

            //----- Level and XP / Health
            _playerLevel = GetPlayerLevel();
            _health = GetHealth();

            //----- Action Points
            _expeditionPoints = ReadActionPoints(HeaderSelectors.ExpeditionPoints,
                HeaderSelectors.MaxExpeditionPoints,
                HeaderSelectors.ExpeditionDetails,
                HeaderSelectors.ExpeditionDetailsAttribute,
                HeaderSelectors.ActionScript,
                1);

            _dungeonPoints = ReadActionPoints(HeaderSelectors.DungeonPoints,
                HeaderSelectors.MaxDungeonPoints,
                HeaderSelectors.DungeonDetails,
                HeaderSelectors.DungeonDetailsAttribute,
                HeaderSelectors.ActionScript,
                4);

            _arena = new ActionPoints(1, 1, IsActionCooldown(HeaderSelectors.ActionScript, 7));

            _circusTurma = new ActionPoints(1, 1, IsActionCooldown(HeaderSelectors.ActionScript, 10));
        }

        private PlayerLevel GetPlayerLevel()
        {
            var lvl = GetInnerTextById(HeaderSelectors.Level).Trim();
            if (!int.TryParse(lvl, out int level))
                throw new ParseIntException($"Could not parse integer from strings '{lvl}'");

            var xpString = GetAttributeValueById(HeaderSelectors.Experience, HeaderSelectors.XpAttribute);
            var xpNums = xpString.ExtractIntegers();
            return new(level, xpNums[0], xpNums[1]);
        }

        private FiniteStat GetHealth()
        {
            var current = GetAttributeValueById(HeaderSelectors.Health, HeaderSelectors.CurrentHealthAttribute);
            var max = GetAttributeValueById(HeaderSelectors.Health, HeaderSelectors.MaxHealthAttribute);

            if (!int.TryParse(current, out int hpCurr))
                throw new ParseIntException($"Could not parse integer from strings '{current}'");

            if (!int.TryParse(max, out int hpMax))
                throw new ParseIntException($"Could not parse integer from strings '{max}'");

            return new FiniteStat(hpCurr, hpMax);
        }

        /// <summary>
        /// Reads action point data based on document id selectors
        /// </summary>
        /// <returns>Returns </returns>
        /// <param name="lowerIndex">The lower index of the target timestamp</param>
        /// <exception cref="HtmlElementNotFoundException"></exception>
        /// <exception cref="HtmlAttributeNotFoundException"></exception>
        /// <exception cref="ParseIntException"></exception>
        private ActionPoints ReadActionPoints(string valueSelector, string maxValueSelector, string detailSelector, string detailAttribute, string scriptStart, int lowerIndex)
        {
            var current = GetInnerTextById(valueSelector);
            var max = GetInnerTextById(maxValueSelector);
            //x var details = GetAttributeValueById(detailSelector, detailAttribute);

            //TODO get action point details such as next point

            int cur, mx;

            if (!int.TryParse(current, out cur) ||
                !int.TryParse(max, out mx))
                throw new ParseIntException($"Could not parse integer from strings {current}, {max}");

            bool cooldown = IsActionCooldown(scriptStart, lowerIndex);

            return new ActionPoints(cur, mx, cooldown);
        }

        /// <summary>
        /// Calculates whether a cooldown is active by evaluating the javascript code that initializes the progress bars for actions.
        /// Progress bars are initialized with UNIX timestamps that can be compared.
        /// </summary>
        /// <param name="identifier">the first n characters of the target script content</param>
        /// <param name="lowerIndex">the lower index of the two UNIX timestamps to compare in order of appearance within the script</param>
        /// <returns></returns>
        private bool IsActionCooldown(string identifier, int lowerIndex)
        {
            var indices = GetScriptTagContentStartingWith(identifier).ExtractIntegers();
            return indices[lowerIndex] < indices[lowerIndex + 1];
        }

        public int Gold { get => _gold; }
        public int Rubies { get => _rubies; }
        public int LeaderboardPlacement { get => _leaderboardPlacement; }
        public PlayerLevel Experience { get => _playerLevel; }
        public ActionPoints ExpeditionPoints { get => _expeditionPoints; }
        public ActionPoints DungeonPoints { get => _dungeonPoints; }
        public DateTime ServerTime { get => _serverTime; }
        public ActionPoints Arena { get => _arena; }
        public ActionPoints CircusTurma { get => _circusTurma; }
        public FiniteStat Health { get => _health; }
    }
}