namespace GladiApi
{
    public class HorreumManager
    {
        private readonly Character _character;

        public HorreumManager(Character character)
        {
            _character = character;
        }

        public async Task StoreResources(bool packages, bool inventory, bool sell)
        {
            var body = new Dictionary<string, string>()
            {
                { "inventory", inventory.ToIntString() },
                { "packages", packages.ToIntString() },
                { "sell", sell.ToIntString() },
                { "sh", _character.SessionHash }
            };

            await GladiatusClient.Post(
                ActionUriProvider.HorreumStore(_character),
                body,
                _character,
                true
            );

            return;
        }
    }
}
