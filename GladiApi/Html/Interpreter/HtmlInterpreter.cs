using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    public abstract class HtmlInterpreter : HtmlInterpreterBase
    {
        //every game page has the game header
        private HeaderInterpreter _headerInterpreter;

        public HtmlInterpreter(string html) : base(html)
        {
            _headerInterpreter = new(html);
        }

        public HeaderInterpreter Header { get => _headerInterpreter; }
    }
}
