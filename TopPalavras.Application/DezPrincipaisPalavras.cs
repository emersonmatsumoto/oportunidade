using System;
using System.Collections.Generic;
using System.Text;
using TopPalavras.Application.Infrastructure;
using System.Linq;
using TopPalavras.Application.DTO;

namespace TopPalavras.Application
{
    public class DezPrincipaisPalavras : IDezPrincipaisPalavras
    {
        private IFrequenciaPalavras _frequenciaPalavras;
        private ISomenteTexto _somenteTexto;
        private ISepararPalavras _separarPalavras;

        public DezPrincipaisPalavras(IFrequenciaPalavras frequenciaPalavras, ISomenteTexto somenteTexto, ISepararPalavras separarPalavras)
        {
            _frequenciaPalavras = frequenciaPalavras;
            _somenteTexto = somenteTexto;
            _separarPalavras = separarPalavras;
        }

        public List<PalavraDTO> Procurar(List<Domain.Topico> topicos)
        {
            StringBuilder conteudo = new StringBuilder();

            foreach(var topico in topicos)
            {
                //conteudo.AppendLine(topico.Titulo); // Adiciono o título ou não? eis a questão.
                conteudo.AppendLine(topico.Conteudo);
            }

            string textoLimpo = _somenteTexto.Limpar(conteudo.ToString());

            string[] palavras = _separarPalavras.Separar(textoLimpo);

            List<PalavraDTO> frequencia = _frequenciaPalavras.Procurar(palavras); 

            return frequencia.OrderByDescending(o => o.Quantidade).Take(10).ToList();
        }
    }
}
