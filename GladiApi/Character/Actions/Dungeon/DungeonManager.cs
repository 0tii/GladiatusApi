namespace GladiApi
{
    public class DungeonManager
    {
        private ActionPoints _dungeonPoints;
        private Encounter _lastEcnounter;
        private Character _character;

        private DungeonManager(Character chr)
        {
            _character = chr;
        }

        private async Task<DungeonManager> InitializeAsync()
        {

        }
    }
}
