using GladiApi.Connection;
using GladiApi.Exceptions;

namespace GladiApi
{
    /// <summary>
    /// Http Client wrapper for GladiApi purposes.
    /// </summary>
    public class GladiatusClient
    {
        private RequestHeader _header;

        private readonly HttpClient _client = new(
            new HttpClientHandler()
            {
                UseCookies = false
                //x ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                //x relic from when document and ajax calls got mixed up
            }
        );

        public GladiatusClient(CharacterAuthentication auth)
        {
            _header = new(auth);
        }

        /// <summary>
        /// Make a get request as an authenticated character without having to specify the session hash in the url
        /// </summary>
        public async Task<string> GetWithSession(string url, Character character, bool ajax = false)
        {
            return await Get(url+"&sh="+character.Authentication.SessionHash, character.Authentication.Cookie, character.Authentication.ServerId, "/", ajax);
        }

        /// <summary>
        /// Make a get request as an authenticated character without having to specify the session hash in the url
        /// </summary>
        public async Task<string> GetWithSession(string url, Character character, string referer, bool ajax = false)
        {
            return await Get(url + "&sh=" + character.Authentication.SessionHash, character.Authentication.Cookie, character.Authentication.ServerId, referer, ajax);
        }

        /// <summary>
        /// Make a get request as an authenticated character
        /// </summary>
        public async Task<string> Get(string url, Character character, bool ajax = false)
        {
            return await Get(url, character.Authentication.Cookie, character.Authentication.ServerId, "server", ajax);
        }

        /// <summary>
        /// Make a get request as an authenticated character
        /// </summary>
        public async Task<string> Get(string url, Character character, string referer, bool ajax = false)
        {
            return await Get(url, character.Authentication.Cookie, character.Authentication.ServerId, referer, ajax);
        }

        /// <summary>
        /// Make a get request as an authenticated character
        /// </summary>
        public async Task<string> Get(string url, string cookie, string serverId, string referer, bool ajax = false)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };

            if (ajax)
                _header.AddAjax(ref request);
            else
                _header.AddDocument(ref request);

            try
            {
                var response = await _client.SendAsync(request).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                throw new RequestFailedException($"Could not connect to host. Status code: {response.StatusCode}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> PostWithSession(string url, Dictionary<string, string> body, Character character, bool ajax = false)
        {
            return await Post(url + $"&sh={character.Authentication.SessionHash}", body, character.Authentication.Cookie, character.Authentication.ServerId, "", ajax);
        }

        public async Task<string> PostWithSession(string url, Dictionary<string, string> body, Character character, string referer, bool ajax = false)
        {
            return await Post(url+$"&sh={character.Authentication.SessionHash}", body, character.Authentication.Cookie, character.Authentication.SessionHash, referer, ajax);
        }

        public async Task<string> Post(string url, Dictionary<string, string> body, Character character, bool ajax = false)
        {
            return await Post(url, body, character.Authentication.Cookie, character.Authentication.ServerId, "server", ajax);
        }

        public async Task<string> Post(string url, Dictionary<string, string> body, Character character, string referer, bool ajax = false)
        {
            return await Post(url, body, character.Authentication.Cookie, character.Authentication.ServerId, referer, ajax);
        }

        //TODO test this
        public async Task<string> Post(string url, Dictionary<string, string> body, string cookie, string serverId, string referer, bool ajax = false)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = new FormUrlEncodedContent(body)
            };

            if (ajax)
                _header.AddAjax(ref request);
            else
                _header.AddDocument(ref request);

            try
            {
                var response = await _client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                throw new Exception($"Could not connect to host. Status code: {response.StatusCode}");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
