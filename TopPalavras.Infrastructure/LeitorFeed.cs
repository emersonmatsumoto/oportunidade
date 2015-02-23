using System.ServiceModel.Syndication;
using System.Xml;
using TopPalavras.Application.Infrastructure;

namespace TopPalavras.Infrastructure
{
    public class LeitorFeed : ILeitorFeed
    {
        public SyndicationFeed Ler(string Url)
        {
            XmlReader reader = XmlReader.Create(Url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            return feed;
        }
    }
}
