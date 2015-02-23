using System.Collections.Generic;
using TopPalavras.Application.DTO;
using TopPalavras.Domain;
namespace TopPalavras.Application
{
    public interface IDezPrincipaisPalavras
    {
        List<PalavraDTO> Procurar(List<Topico> topicos);
    }
}
