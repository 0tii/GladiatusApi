using GladiApi.Exceptions;

namespace GladiApi
{
    /// <summary>
    /// Class representing a GAO (Gladiatus Authentication Object)
    /// </summary>
    public class Gao
    {
        private const string GaoVersion = "0.1";
        private const int ValueCount = 5;

        private string[] _gao;

        private string _serverId;
        private string _cookie;
        private string _userAgent;
        private string _sessionHash;

        public Gao(string gaoContent)
        {
            try
            {
                CheckIntegrity(gaoContent);
                ReadValues();
            }
            catch
            {
                throw;
            }
        }

        private void CheckIntegrity(string gaoContent)
        {
            if (!gaoContent.IsValidBase64())
                throw new FormatException("The gao supplied is not valid.");

            string decoded = gaoContent.FromBase64();
            _gao = decoded.Split("||");

            if (_gao.Length != ValueCount)
                throw new GaoVersionMismatchException($"The authentication object contains less values than expected. Expected ${ValueCount} but got ${_gao.Length}");

            if (_gao[0] != GaoVersion)
                throw new GaoVersionMismatchException($"The version of the authentication object supplied does not match Gladiatus Api's gao version. Supplied: v${_gao[0]}, required: v${GaoVersion}");
        }

        private void ReadValues()
        {
            _serverId = _gao[1];
            _cookie = _gao[2];
            _sessionHash = _gao[3];
            _userAgent = _gao[4];
        }

        public string ServerId { get => _serverId; set => _serverId = value; }
        public string Cookie { get => _cookie; set => _cookie = value; }
        public string UserAgent { get => _userAgent; set => _userAgent = value; }
        public string SessionHash { get => _sessionHash; set => _sessionHash = value; }
    }
}
