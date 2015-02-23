using System;
using System.Collections.Generic;
using TopPalavras.Application.DTO;

namespace TopPalavras.Application.Infrastructure
{
    public interface IFrequenciaPalavras
    {
        List<PalavraDTO> Procurar(string[] palavras);
    }
}
