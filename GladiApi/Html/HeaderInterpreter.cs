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

        public HeaderInterpreter(string html) : base(html)
        {
            _gold = GetInnerTextWithId(HeaderSelectors.Gold);
            _rubies = GetInnerTextWithId(HeaderSelectors.Rubies);
            //rank
            //level

        }

        public string Gold { get => _gold; }
        public string Rubies { get => _rubies; }
    }
}
