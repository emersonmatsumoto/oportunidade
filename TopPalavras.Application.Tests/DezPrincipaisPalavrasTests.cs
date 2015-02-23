using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopPalavras.Application.DTO;
using TopPalavras.Application.Infrastructure;
using TopPalavras.Domain;

namespace TopPalavras.Application.Tests
{
    [TestClass]
    public class DezPrincipaisPalavrasTests
    {
        [TestMethod]
        public void ProcurarDezPrincipaisPalavras()
        {
            List<Topico> topicos = new List<Topico>(){
                new Topico{
                    Titulo = "O Valor do Seguro Residencial",
                    Conteudo = "<p>Seguro Residencial é importante e custa pouco para o bolso do morador. O importante jornal <strong>Valor Econômico</strong> trouxe, tanto em seu site como na edição impressa, uma <a href=\"http://www.valor.com.br/financas/3915152/lar-doce-e-protegido-lar\" target=\"_blank\">matéria</a> completa sobre o produto, que teve participação direta da Minuto Seguros nas informações.</p>"
                }
            };

            string textoLimpo = "Seguro Residencial é importante e custa pouco para o bolso do morador. O importante jornal Valor Econômico trouxe, tanto em seu site como na edição impressa, uma matéria completa sobre o produto, que teve participação direta da Minuto Seguros nas informações.";

            string[] palavrasSeparadas = { "seguro", "residencial", "importante", "custa", "pouco", "bolso", "morador", "importante", "jornal", "valor", "econômico", "trouxe", "tanto", "seu", "site", "edição", "impressa", "matéria", "completa", "sobre", "produto", "participação", "direta", "minuto", "Seguros", "informações" };

            List<PalavraDTO> palavras = new List<PalavraDTO>() { 
                new PalavraDTO(){
                    Palavra = "importante",
                    Quantidade = 2
                },
            };

            var frequenciaPalavras = new Mock<IFrequenciaPalavras>();
            frequenciaPalavras
                .Setup(s => s.Procurar(It.IsAny<string[]>()))
                .Returns(palavras);

            var somenteTexto = new Mock<ISomenteTexto>();
            somenteTexto
                .Setup(s => s.Limpar(It.IsAny<string>()))
                .Returns(textoLimpo);

            var separarPalavras = new Mock<ISepararPalavras>();
            separarPalavras
                .Setup(s => s.Separar(It.IsAny<string>()))
                .Returns(palavrasSeparadas);

            DezPrincipaisPalavras testClass = new DezPrincipaisPalavras(frequenciaPalavras.Object, somenteTexto.Object, separarPalavras.Object);
            List<PalavraDTO> palavrasResultado = testClass.Procurar(topicos);
        }
    }
}
