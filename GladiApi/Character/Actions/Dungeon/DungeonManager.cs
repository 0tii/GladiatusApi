namespace GladiApi
{
    //TODO Custom Dungeon Templates that can easily be loaded to outline the dungeon progression in standardized JSON format

    public class DungeonManager
    {
        private ActionPoints _dungeonPoints;
        private Encounter? _lastEncounter; //stays null until first manual encounter
        private Character _character;

        private DungeonManager(Character chr)
        {
            _character = chr;
        }

        private async Task<DungeonManager> InitializeAsync(HeaderInterpreter header)
        {
            //init values here
            _dungeonPoints = header.DungeonPoints;
            return this;
        }

        /// <summary>
        /// Creates a populated instance of DungeonManager
        /// </summary>
        /// <param name="chr">the character instance</param>
        /// <param name="header">an up-to-date headerinterpreter instance</param>
        /// <returns></returns>
        public static async Task<DungeonManager> CreateInstanceAsync(Character chr, HeaderInterpreter header)
        {
            var instance = new DungeonManager(chr);
            await instance.InitializeAsync(header);
            return instance;
        }

        public async Task<bool> Attack(int dungeonId, int enemyIndex)
        {
            if(_dungeonPoints.CurrentPoints <= 0)
                return false;

            await GladiatusClient.GetWithSession(
                ActionUriProvider.DungeonAttack(_character, dungeonId, enemyIndex),
                _character,
                true
            );

            //todo GET expedition reports and interpret
            var reports = await GladiatusClient.GetWithSession(
                UriProvider.DungeonReportsUri(_character),
                _character
            );

            // interpret report
            var interpreter = new ReportsInterpreter(reports, EncounterType.Expedition);
            _lastEncounter = interpreter.Encounters[0];
            _lastEncounter.AddLocation((dungeonId, enemyIndex));
            _dungeonPoints = interpreter.Header.DungeonPoints;

            return _lastEncounter.Successful;
        }
 
        public ActionPoints DungeonPoints { get => _dungeonPoints; set => _dungeonPoints = value; }
        public Encounter? LastEncounter { get => _lastEncounter; set => _lastEncounter = value; }
        public Character Character { get => _character; set => _character = value; }
    }
}
