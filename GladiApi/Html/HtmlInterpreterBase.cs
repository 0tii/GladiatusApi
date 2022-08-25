using GladiApi.Exceptions;
using HtmlAgilityPack;

namespace GladiApi
{
    /// <summary>
    ///  Inteprets a html representation of a gladiatus page document
    /// </summary>
    public abstract class HtmlInterpreterBase
    {
        protected string _html;
        protected HtmlDocument _document;

        /// <summary>
        /// Initialize an interpreter instance with a html string.
        /// </summary>
        /// <param name="html">the html string to be parsed</param>
        public HtmlInterpreterBase(string html)
        {
            _html = html;
            _document = new HtmlDocument();
            _document.LoadHtml(_html);
        }

        protected string GetInnerTextWithId(string selector)
        {
            var element = _document.GetElementbyId(HeaderSelectors.Gold);
            if (element == null)
                throw new HtmlElementNotFoundException($"Could not find element corresponding to selector \'{selector}\'");
            return element.InnerText;
        }
    }
}
