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

        /// <summary>
        /// Gets the inner text of an element selected via its id
        /// </summary>
        /// <param name="id">the value of the id attribute</param>
        /// <returns>string representation of the inner text of the desired element</returns>
        /// <exception cref="HtmlElementNotFoundException"></exception>
        protected string GetInnerTextById(string id)
        {
            var element = _document.GetElementbyId(id);
            if (element == null)
                throw new HtmlElementNotFoundException($"Could not find element corresponding to selector \'{id}\'");
            return element.InnerText;
        }

        /// <summary>
        /// Tries reading an attribute value from an element selected via its id.
        /// </summary>
        /// <param name="id">the id of the target element</param>
        /// <param name="attributeName">the name of the attribute</param>
        /// <returns>string representation of the attribute value</returns>
        /// <exception cref="HtmlElementNotFoundException"></exception>
        /// <exception cref="HtmlAttributeNotFoundException"></exception>
        protected string GetAttributeValueById(string id, string attributeName)
        {
            var element = _document.GetElementbyId(id);
            if (element == null)
                throw new HtmlElementNotFoundException($"Could not find element corresponding to selector \'{id}\'");
            var attribute = element.Attributes.FirstOrDefault(attribute => attribute.Name == attributeName);
            if (attribute == null)
                throw new HtmlAttributeNotFoundException($"Could not find attribute \'{attributeName}\' on element with id \'{id}\'");
            return attribute.Value;
        }

        /// <summary>
        /// Tries getting a script tag content from the html document
        /// </summary>
        /// <param name="index">chronological index of script tag in the DOM</param>
        protected string GetScriptTagContent(int index)
        {
            return GetScriptTags()[index].InnerText;
        }

        /// <summary>
        /// Gets a collection of <see cref="HtmlNode"/> where each node is a script tag in order of appearance in the document.
        /// </summary>
        protected List<HtmlNode> GetScriptTags()
        {
            return _document.DocumentNode.Descendants()
                             .Where(n => n.Name == "script").ToList();
        }

        /// <summary>
        /// Tries getting a script tag content identified by knowledge of the content.
        /// </summary>
        /// <param name="begin">The string the script tag content begins with</param>
        /// <returns>The script tag content or <see cref="string.Empty"/></returns>
        protected string GetScriptTagContentStartingWith(string begin)
        {
            foreach (HtmlNode script in GetScriptTags())
                if (script.InnerText.Trim().StartsWith(begin))
                    return script.InnerText.Trim();

            return string.Empty;
        }
    }
}
