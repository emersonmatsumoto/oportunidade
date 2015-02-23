using System.Collections.Generic;
using TopPalavras.Domain;
namespace TopPalavras.Application
{
    public interface ILerTopicos
    {
        List<Topico> Ler(string Url, int Quantidade);
    }
}
