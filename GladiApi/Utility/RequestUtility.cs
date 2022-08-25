using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    public class RequestUtility
    {
        public static void AddDocumentHeaders(ref HttpRequestMessage message, string cookie, string serverId, string referer="optional")
        {
            message.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8");
            //message.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            message.Headers.Add("Accept-Language", "en-US, en;q=0.5");
            message.Headers.Add("Connection", "keep-alive");
            message.Headers.Add("Cookie", cookie);
            message.Headers.Add("Host", $"{serverId}.gladiatus.gameforge.com");
            //referer is optional
            message.Headers.Add("Referer", referer);
            message.Headers.Add("Sec-Fetch-Dest", "document");
            message.Headers.Add("Sec-Fetch-Mode", "navigate");
            message.Headers.Add("Sec-Fetch-Site", "same-origin");
            message.Headers.Add("Sec-Fetch-User", "?1");
            message.Headers.Add("Upgrade-Insecure-Requests", "1");
            //user agent is optional - using win64 chrome agent
            message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36");
        }

        public static void AddAjaxHeaders(ref HttpRequestMessage message, string cookie, string serverId, string referer="optional")
        {
            message.Headers.Add("Accept", "text/javascript, text/html, application/xml, text/xml, */*");
            //message.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            message.Headers.Add("Accept-Language", "en-GB, en-US;q=0.9,en;q=0.8");
            message.Headers.Add("Connection", "keep-alive");
            message.Headers.Add("Cookie", cookie);
            message.Headers.Add("Host", $"{serverId}.gladiatus.gameforge.com");
            //referer is optional
            message.Headers.Add("Referer", referer);
            message.Headers.Add("Sec-Fetch-Dest", "empty");
            message.Headers.Add("Sec-Fetch-Mode", "cors");
            message.Headers.Add("Sec-Fetch-Site", "same-origin");
            //user agent is optional - using win64 chrome agent
            message.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36");
            message.Headers.Add("X-Requested-With", "XMLHttpRequest");
        }
    }
}