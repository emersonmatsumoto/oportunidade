using System.Collections.Generic;
using System.ServiceModel.Syndication;
using TopPalavras.Application.Infrastructure;
using TopPalavras.Domain;
using System.Linq;
using System.Xml.Linq;

namespace TopPalavras.Application
{
    public class LerTopicos : ILerTopicos
    {
        private ILeitorFeed _leitor;
        public LerTopicos(ILeitorFeed leitor)
        {
            _leitor = leitor;
        }
        public List<Topico> Ler(string Url, int Quantidade)
        {
            SyndicationFeed feed = _leitor.Ler(Url);
            var topicos = feed.Items
                .Select(s => new Topico {
                    Titulo = s.Title == null ? "" : s.Title.Text,
                    Conteudo = s.ElementExtensions.Where(we => we.GetObject<XElement>().Name.LocalName == "encoded").Select(se => se.GetObject<XElement>().Value).FirstOrDefault()
                })
                .Take(Quantidade)
                .ToList();

            return topicos;
        }
    }
}
