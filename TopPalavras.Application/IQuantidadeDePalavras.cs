using System.Collections.Generic;
using TopPalavras.Application.DTO;
using TopPalavras.Domain;
namespace TopPalavras.Application
{
    public interface IQuantidadeDePalavras
    {
        List<TopicoDTO> Procurar(List<Topico> topicos);
    }
}
