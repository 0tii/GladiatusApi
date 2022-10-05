using GladiApi.Exceptions;

namespace GladiApi
{
    /// <summary>
    /// Represents a Gladiatus player character.<br/><b>This is the central unit controlling all functionality</b>.
    /// </summary>
    public sealed class Character
    {

        //auth object
        private readonly CharacterAuthentication _authentication;

        //gladiatus http client
        private readonly GladiatusClient _client;

        //system
        private readonly CancellationTokenSource _ctSource = new();

        //character stats (level, gold, rubies, skills)
        private CharacterStatManager _stats;

        //actions
        private ExpeditionManager _expedition;
        private DungeonManager _dungeon;
        private HorreumManager _horreum;
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

        //! Events
        //! - StatsChangedEvent
        

        private Character(string serverId, string sessionHash, string cookie)
        {
            _authentication = new CharacterAuthentication(serverId, cookie, sessionHash);
            _client = new GladiatusClient(_authentication);
        }

        private Character(string serverId, string sessionHash, string cookie, string userAgent)
        {
            _authentication = new CharacterAuthentication(serverId, cookie, sessionHash, userAgent);
            _client = new GladiatusClient(_authentication);
        }

        private async Task<Character> InitializeAsync()
        {
            var html = await _client.GetWithSession(UriProvider.OverviewUri(this), this);
            var header = new HeaderInterpreter(html);

            //initialize members
            _expedition = await ExpeditionManager.CreateInstanceAsync(this, header);
            _dungeon = await DungeonManager.CreateInstanceAsync(this, header);
            _horreum = new HorreumManager(this);
            return this;
        }

        /// <summary>
        /// Factory pattern to create an asynchronously populated class instance
        /// </summary>
        /// <returns>Instance of <see cref="Character"/></returns>
        public static async Task<Character> CreateInstanceAsync(string serverId, string sessionHash, string cookie)
        {
            Character character = new(serverId, sessionHash, cookie);
            return await character.InitializeAsync();
        }

        /// <summary>
        /// Factory pattern to create an asynchronously populated class instance
        /// </summary>
        /// <returns>Instance of <see cref="Character"/></returns>
        public static async Task<Character> CreateInstanceAsync(string gaoContent)
        {
            Gao gao = new(gaoContent);

            Character character = new(gao.ServerId, gao.SessionHash, gao.Cookie, gao.UserAgent);
            return await character.InitializeAsync();
        }

        /// <summary>
        /// Factory pattern to create an asynchronously populated class instance
        /// </summary>
        /// <returns>Instance of <see cref="Character"/></returns>
        public static async Task<Character> CreateInstanceAsync(string gaoContent, string decryptionKey) 
        {
            string decrypted = Crypto.AES.Decrypt(gaoContent, decryptionKey);
            if (decrypted == string.Empty)
                throw new DecryptionException("Could not decrypt authentication object with the password supplied.");

            return await Character.CreateInstanceAsync(decrypted);
        }

        /// <summary>
        /// Must be invoked before exiting execution. Shuts down safely.
        /// </summary>
        public void ShutDown()
        {
            _ctSource.Cancel();
        }

        public CancellationToken ServiceCancellationToken => _ctSource.Token;

        public ExpeditionManager Expedition { get => _expedition;  }
        public CharacterStatManager Stats { get => _stats; }
        public HorreumManager Horreum { get => _horreum; }
        public DungeonManager Dungeon { get => _dungeon; }
        public CharacterAuthentication Authentication { get => _authentication; }
        public GladiatusClient HttpClient { get => _client; }
    }
}
