namespace GladiApi
{
    public class CharacterAuthentication
    {
        private string _serverId;
        private string _cookie;
        private string _sessionHash;
        private string _userAgent;

        public CharacterAuthentication(string serverId, string cookie, string sessionHash)
        {
            _serverId = serverId;
            _cookie = cookie;
            _sessionHash = sessionHash;
            _userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";
        }

        public CharacterAuthentication(string serverId, string cookie, string sessionHash, string userAgent)
        {
            _serverId = serverId;
            _cookie = cookie;
            _sessionHash = sessionHash;
            _userAgent = userAgent;
        }

        public string ServerId { get => _serverId; set => _serverId = value; }
        public string Cookie { get => _cookie; set => _cookie = value; }
        public string SessionHash { get => _sessionHash; set => _sessionHash = value; }
        public string UserAgent { get => _userAgent; set => _userAgent = value; }
    }
}
