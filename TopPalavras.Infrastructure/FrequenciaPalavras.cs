using System.Collections.Generic;
using TopPalavras.Application.DTO;
using TopPalavras.Application.Infrastructure;
using System.Linq;

namespace TopPalavras.Infrastructure
{
    public class FrequenciaPalavras : IFrequenciaPalavras
    {
        
        public List<PalavraDTO> Procurar(string[] palavras)
        {
            List<PalavraDTO> frequenciaPalavras = palavras.GroupBy(g => g).Select(s => new PalavraDTO { Palavra = s.Key, Quantidade = s.Count() }).ToList();

            return frequenciaPalavras;
        }
    }
}
