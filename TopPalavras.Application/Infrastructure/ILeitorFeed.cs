using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace TopPalavras.Application.Infrastructure
{
    public interface ILeitorFeed
    {
        SyndicationFeed Ler(string Url);
    }
}
