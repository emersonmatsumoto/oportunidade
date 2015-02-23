using System;
using System.Collections.Generic;
using TopPalavras.Application.DTO;
using TopPalavras.Application.Infrastructure;
using TopPalavras.Domain;
using System.Linq;

namespace TopPalavras.Application
{
    public class QuantidadeDePalavras : IQuantidadeDePalavras
    {
        private ISomenteTexto _somenteTexto;
        private ISepararPalavras _separarPalavras;
        private IFrequenciaPalavras _frequenciaPalavras;

        public QuantidadeDePalavras(ISomenteTexto somenteTexto, ISepararPalavras separarPalavras, IFrequenciaPalavras frequenciaPalavras)
        {
            _somenteTexto = somenteTexto;
            _separarPalavras = separarPalavras;
            _frequenciaPalavras = frequenciaPalavras;
        }
        public List<TopicoDTO> Procurar(List<Topico> topicos)
        {
            List<TopicoDTO> topicoDTOs = new List<TopicoDTO>();

            foreach (var topico in topicos)
            {
                string textoLimpo = _somenteTexto.Limpar(topico.Conteudo);
                string[] palavras = _separarPalavras.Separar(textoLimpo);
                List<PalavraDTO> palavrasUnicas = _frequenciaPalavras.Procurar(palavras);
               
                var TopicoDTO = new TopicoDTO {
                    Palavras = palavrasUnicas.Count,
                    Titulo = topico.Titulo
                };
                topicoDTOs.Add(TopicoDTO);
            }

            return topicoDTOs;
        }
    }
}
