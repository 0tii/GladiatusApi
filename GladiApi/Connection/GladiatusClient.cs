using GladiApi.Exceptions;

namespace GladiApi
{
    /// <summary>
    /// Http Client wrapper for GladiApi purposes.
    /// </summary>
    public static class GladiatusClient
    {
        private static readonly HttpClient _client = new(
            new HttpClientHandler()
            {
                UseCookies = false
                //x ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                //x relic from when document and ajax calls got mixed up
            }
        );

        /// <summary>
        /// Make a get request as an authenticated character without having to specify the session hash in the url
        /// </summary>
        public async static Task<string> GetWithSession(string url, Character character, bool ajax = false)
        {
            return await Get(url+"&sh="+character.SessionHash, character.Cookie, character.Region, "", ajax);
        }

        /// <summary>
        /// Make a get request as an authenticated character without having to specify the session hash in the url
        /// </summary>
        public async static Task<string> GetWithSession(string url, Character character, string referer, bool ajax = false)
        {
            return await Get(url + "&sh=" + character.SessionHash, character.Cookie, character.Region, referer, ajax);
        }

        /// <summary>
        /// Make a get request as an authenticated character
        /// </summary>
        public async static Task<string> Get(string url, Character character, bool ajax = false)
        {
            return await Get(url, character.Cookie, character.Region, "", ajax);
        }

        /// <summary>
        /// Make a get request as an authenticated character
        /// </summary>
        public async static Task<string> Get(string url, Character character, string referer, bool ajax = false)
        {
            return await Get(url, character.Cookie, character.Region, referer, ajax);
        }

        /// <summary>
        /// Make a get request as an authenticated character
        /// </summary>
        public async static Task<string> Get(string url, string cookie, string serverId, string referer, bool ajax = false)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };

            if (ajax)
                RequestUtility.AddAjaxHeaders(ref request, cookie, serverId, referer);
            else
                RequestUtility.AddDocumentHeaders(ref request, cookie, serverId, referer);

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

        public static async Task<string> PostWithSession(string url, Dictionary<string, string> body, Character character, bool ajax = false)
        {
            return await Post(url + $"&sh={character.SessionHash}", body, character.Cookie, character.Region, "", ajax);
        }

        public static async Task<string> PostWithSession(string url, Dictionary<string, string> body, Character character, string referer, bool ajax = false)
        {
            return await Post(url+$"&sh={character.SessionHash}", body, character.Cookie, character.Region, referer, ajax);
        }

        public static async Task<string> Post(string url, Dictionary<string, string> body, Character character, bool ajax = false)
        {
            return await Post(url, body, character.Cookie, character.Region, "", ajax);
        }

        public static async Task<string> Post(string url, Dictionary<string, string> body, Character character, string referer, bool ajax = false)
        {
            return await Post(url, body, character.Cookie, character.Region, referer, ajax);
        }

        //TODO test this
        public async static Task<string> Post(string url, Dictionary<string, string> body, string cookie, string serverId, string referer, bool ajax = false)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = new FormUrlEncodedContent(body)
            };

            if (ajax)
                RequestUtility.AddAjaxHeaders(ref request, cookie, serverId, referer);
            else
                RequestUtility.AddDocumentHeaders(ref request, cookie, serverId, referer);

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
