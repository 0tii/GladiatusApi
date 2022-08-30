using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    /// <summary>
    /// Represents a Gladiatus player character.<br/><b>This is the central unit controlling all functionality</b>.
    /// </summary>
    public sealed class Character
    {
        private readonly string _region; //s56-en; s3-de; ...
        private readonly string _cookie;
        private readonly string _sessionHash;

        //system
        private readonly CancellationTokenSource _ctSource = new();

        //character stats (level, gold, rubies, skills)
        private CharacterStatManager? _stats;

        private ExpeditionManager? _expedition;

        //missions
        //dungeon
        //auction house

        //inventory

        //dungeon character
        //mercenaries

        //training

        //arena
        //circus turma

        //merchants

        //guild

        //work

        private Character(int server, string countryShorthand, string sessionHash, string cookie)
        {
            _region = $"s{server}-{countryShorthand}";
            _cookie = cookie;
            _sessionHash = sessionHash;
        }

        private async Task<Character> InitializeAsync()
        {
            //initialize members
            _expedition = await ExpeditionManager.CreateInstanceAsync(this);

            return this;
        }

        /// <summary>
        /// Factory pattern to create an asynchronously populated class instance
        /// </summary>
        /// <returns>Instance of <see cref="Character"/></returns>
        public static async Task<Character> CreateInstanceAsync(int server, string countryShorthand, string sessionHash, string cookie)
        {
            Character character = new(server, countryShorthand, sessionHash, cookie);
            return await character.InitializeAsync();
        }

        /// <summary>
        /// Must be invoked before exiting execution. Shuts down safely.
        /// </summary>
        public void ShutDown()
        {
            _ctSource.Cancel();
        }

        public CancellationToken ServiceCancellationToken => _ctSource.Token;

        public string Region { get => _region; }
        public string Cookie { get => _cookie; }
        public string SessionHash { get => _sessionHash; }
        public ExpeditionManager? Expedition { get => _expedition;  }
        public CharacterStatManager? Stats { get => _stats; }
    }
}
