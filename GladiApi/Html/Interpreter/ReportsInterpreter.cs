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
        public string debugContent = "";

        private List<Encounter> _encounters = new();
        private EncounterType _encounterType;
        private bool _arena = false;

        public ReportsInterpreter(string html, EncounterType encounterType) : base(html)
        {
            _encounterType = encounterType;
            if (encounterType == EncounterType.Arena || encounterType == EncounterType.CircusTurma)
                _arena = true;
            ReadReports();
        }

        private void ReadReports()
        {
            string dayString, //dd.MM.yyyy
                   timeString; //hh:mm
            var rows = _document.DocumentNode.SelectNodes("//table[@class='section-like']//tr");

            foreach (HtmlNode row in rows)
            {
                //check whether row is day-header
                if (row.GetAttributes().Any(attr => attr.Name == "colspan"))
                {
                    dayString = row.SelectSingleNode("td").InnerText.Trim();
                    continue;
                }

                int gold = 0, rubies = 0;
                var cells = row.SelectNodes("td");
                if (cells == null) //probably th
                    continue;

                timeString = cells[0].InnerText.Trim(); //hh:mm
                bool success = cells[1].GetAttributeValue("style", string.Empty).Contains("#247F2A");
                string name = cells[1].InnerText;

                if (success) //read loot
                {
                    var goldString = cells[2].InnerText.Trim();
                    if(goldString.Contains("&nbsp;"))
                    {
                        rubies = 1;
                        goldString = goldString.Split("&nbsp;")[0].Trim();
                    }
                    if (!int.TryParse(goldString, out gold))
                        throw new ParseIntException($"Could not parse gold value from gold string '{goldString}' while interpreting Report");
                }
                // TODO ITEM DROPS!

                //create Encounter instance and add info
                _encounters.Add(new Encounter(_encounterType, success, gold, rubies));
            }

            //reverse list so newest is on top
            _encounters.Reverse();
        }

        public string[] Debug()
        {
            return new string[] { 
                "", 
                "" 
            };
        }

        public List<Encounter> Encounters { get => _encounters; }
    }
}
