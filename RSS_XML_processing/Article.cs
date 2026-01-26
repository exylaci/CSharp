using System;
using System.Xml.Linq;

namespace RSS_XML_processing
{
    internal class Article
    {
        string subject;
        string content;
        string link;

        public string Subject { get => subject; }
        public string Content { get => content; }
        public string Link { get => link; }


        public Article(XElement articleItem)
        {
            if (articleItem.Name != "item")
            {
                throw new ArgumentException("Hibas xml adat");
            }

            subject = articleItem.Element("title")?.Value ?? string.Empty;

            XNamespace contentNs = "http://purl.org/rss/1.0/modules/content/";
            content =
                articleItem.Element(contentNs + "encoded")?.Value
                ?? articleItem.Element("description")?.Value
                ?? string.Empty;

            link = articleItem.Element("link")?.Value ?? string.Empty;
        }

        public override string ToString()
        {
            return Subject;
        }
    }
}
