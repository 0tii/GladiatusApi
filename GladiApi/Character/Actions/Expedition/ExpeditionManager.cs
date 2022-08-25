﻿using GladiApi.Exceptions;

namespace GladiApi
{
    /// <summary>
    /// Class allowing to control expeditions
    /// </summary>
    public sealed class ExpeditionManager
    {
        private ActionPoints _expeditionPoints;

        private (int, int) _lastEncounter = (0, 0);
        private bool _lastEncounterSuccessful;
        private bool _cooldownActive;

        private Character _character;

        private ExpeditionManager(Character character)
        {
            _character = character;
        }

        private async Task<ExpeditionManager> InitializeAsync()
        {
            await Refresh();

            return this;
        }

        /// <summary>
        /// Factory pattern to create an asynchronously populated class instance
        /// </summary>
        /// <returns>Instance of <see cref="ExpeditionManager"/></returns>
        public static async Task<ExpeditionManager> CreateInstanceAsync(Character character)
        {
            ExpeditionManager instance = new(character);

            return await instance.InitializeAsync();
        }

        async public Task Refresh()
        {
            //get expedition points

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
            if (_expeditionPoints.CurrentPoints == 0)
                return false;

            if (region > 6 || region < 0)
                throw new ParameterOutOfRangeException("Parameter region exceeds allowed bounds.");

            if (enemy > 4 || enemy < 1)
                throw new ParameterOutOfRangeException("Parameter enemy exceeds allowed bounds.");

            try
            {
                // Http Request (ajax) to initiate expedition fight
                await GladiatusClient.GetWithSession(
                    $"https://{_character.Region}.gladiatus.gameforge.com/game/ajax.php?mod=location&submod=attack&location={region}&stage={enemy}&premium=0",
                    _character,
                    true
                );

                //todo Evaluate attack result
                
                //todo Update fields


                return true;
            }
            catch //rethrow but keep stack information
            {
                throw;
            }
        }

        //dispatch event when expedition becomes available
        // -> expedition metering service

        public ActionPoints ExpeditionPoints { get => _expeditionPoints; }
        public bool LastEncounterSuccessful { get => _lastEncounterSuccessful; }
        public (int, int) LastEncounter { get => _lastEncounter; }
        public Character Character { get => _character; }
        public bool CooldownActive { get => _cooldownActive; }
    }
}