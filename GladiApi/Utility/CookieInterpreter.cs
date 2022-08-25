using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace GladiApi
{
    /// <summary>
    /// Class attempting to interpret a cookie to get all necesary request information.<br/>
    /// <b>canceled</b> - cookie structure is too unreliable between browsers
    /// </summary>
    public class CookieInterpreter
    {
        private string _cookie;
        private string? _characterName;

        private string _serverId;
        private string _serverNumber;
        private string _country;
        private string _sessionHash;

        /// <summary>
        /// <b>Canceled!</b> - Cookies vary greatly between browsers.
        /// </summary>
        /// <param name="cookie">Cookie represented as a semicolon-separated value list</param>
        public CookieInterpreter(string cookie)
        {
            _cookie = cookie;
        }

        public CookieInterpreter(string cookie, string characterName)
        {
            _cookie = cookie;
            _characterName = characterName;
        }

        private string FindServerId()
        {
            foreach(string s in _cookie.Split(';'))
            {
                if (s.Trim().StartsWith("Gladiatus_"))
                {
                    var split = s.Split('_');
                    _serverNumber = split[2];
                    _country = split[1];
                    return $"s{split[2]}-{split[1]}";
                }
            }
            throw new Exception("Server identifier could not be read from the cookie supplied.");
        }

        private string FindSessionHash()
        {
            return "";
        }

        public string Cookie { get => _cookie; set => _cookie = value; }
        public string ServerId { get => _serverId; set => _serverId = value; }
        public string SessionHash { get => _sessionHash; set => _sessionHash = value; }
        public string ServerNumber { get => _serverNumber; set => _serverNumber = value; }
        public string Country { get => _country; set => _country = value; }
    }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
