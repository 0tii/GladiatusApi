using GladiApi.Exceptions;
using HtmlAgilityPack;
using System.Globalization;

namespace GladiApi
{
    /// <summary>
    /// Tries to interpret a reports page (arena, dungeon, expedition, turma)<br/>
    /// Keeps a list of the last <b>20</b> encounters
    /// </summary>
    public sealed class ReportsInterpreter : HtmlInterpreter
    {
        private List<Encounter> _encounters = new();
        private EncounterType _encounterType;

        public ReportsInterpreter(string html, EncounterType encounterType) : base(html)
        {
            _encounterType = encounterType;
        }

        private void ReadReports()
        {
            string dayString, timeString;

            foreach (HtmlNode row in _document.DocumentNode.SelectNodes("//table[@class='section-like']//tr"))
            {
                //check whether row is day-header
                if (row.GetAttributes().Any(attr => attr.Name == "colspan"))
                {
                    dayString = row.SelectSingleNode("td").InnerText.Trim();
                }

                string name;
                bool success;
                int gold, rubies;
                BaseItem main, secondary;

                var cells = row.SelectNodes("td");
                timeString = cells[0].InnerText.Trim();
                

                //create Encounter instance and add info
            }

            //reverse list so newest is on top
        }
    }
}
