using GladiApi.Exceptions;

namespace GladiApi
{
    /// <summary>
    /// Class allowing to control expeditions
    /// </summary>
    public sealed class ExpeditionManager
    {
        private ActionPoints _expeditionPoints;

        private Encounter? _lastEncounter; //null until first manual expedition

        private Character _character;

        private ExpeditionManager(Character character)
        {
            _character = character;
        }

        private async Task<ExpeditionManager> InitializeAsync(HeaderInterpreter header)
        {
            //get expedition points
            _expeditionPoints = header.ExpeditionPoints;
            //last encounter stays empty
            return this;
        }

        /// <summary>
        /// Factory pattern to create an asynchronously populated class instance
        /// </summary>
        /// <returns>Instance of <see cref="ExpeditionManager"/></returns>
        public static async Task<ExpeditionManager> CreateInstanceAsync(Character character, HeaderInterpreter header)
        {
            ExpeditionManager instance = new(character);

            return await instance.InitializeAsync(header);
        }

        /// <summary>
        /// Attack an expedition enemy in your current country.
        /// </summary>
        /// <param name="region">Index of the region (0-indexed)</param>
        /// <param name="enemy">Index of enemy (1-indexed) [1-4]</param>
        /// <returns><b><i>false</i></b> if expedition points are insufficient</returns>
        /// <exception cref="RequestFailedException"/>
        /// <exception cref="ParameterOutOfRangeException"/>
        async public Task<bool> Attack(int region, int enemy)
        {
            if (_expeditionPoints.CurrentPoints <= 0)
                return false;

            if (region > 6 || region < 0)
                throw new ParameterOutOfRangeException("Parameter 'region' exceeds allowed bounds.");

            if (enemy > 4 || enemy < 1)
                throw new ParameterOutOfRangeException("Parameter 'enemy' exceeds allowed bounds.");

            try
            {
                // Http Request (ajax) to initiate expedition fight
                await _character.HttpClient.GetWithSession(
                    ActionUriProvider.ExpeditionAttack(_character, region, enemy),
                    _character,
                    true
                );

                //todo GET expedition reports and interpret
                var reports = await _character.HttpClient.GetWithSession(
                    UriProvider.ExpeditionReportsUri(_character),
                    _character
                );

                // interpret report
                var interpreter = new ReportsInterpreter(reports, EncounterType.Expedition);
                _lastEncounter = interpreter.Encounters[0];
                _lastEncounter.AddLocation((region, enemy));
                _expeditionPoints = interpreter.Header.ExpeditionPoints;

                return _lastEncounter.Successful;
            }
            catch //rethrow but keep stack information
            {
                throw;
            }
        }

        //dispatch event when expedition becomes available
        // -> expedition metering service

        public ActionPoints ExpeditionPoints { get => _expeditionPoints; }
        public Encounter LastEncounter { get => _lastEncounter; }
        public Character Character { get => _character; }
    }
}
