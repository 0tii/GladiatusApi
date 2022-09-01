using HtmlAgilityPack;

namespace GladiApi
{
    /// <summary>
    /// Tries to interpret a reports page (arena, dungeon, expedition, turma)<br/>
    /// Keeps a list of the last <b>20</b> encounters
    /// </summary>
    public sealed class ReportsInterpreter : HtmlInterpreter
    {
        private List<Encounter> _encounters = new();
        private bool _arena;
        
        public ReportsInterpreter(string html, bool arena) : base(html)
        {
            _arena = arena;
        }

        private void ReadReports()
        {
            foreach (HtmlNode row in _document.DocumentNode.SelectNodes("//table[@class='section-like']//tr"))
            {
                //name
                string name;
                bool success;
                int gold, rubies;
                BaseItem main, secondary;

                foreach (HtmlNode col in row.SelectNodes("td"))
                {

                }

                //create Encounter instance and add info
            }
        }
    }
}
