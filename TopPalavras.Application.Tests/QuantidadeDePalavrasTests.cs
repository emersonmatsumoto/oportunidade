using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopPalavras.Domain;
using System.Collections.Generic;
using TopPalavras.Application.Infrastructure;
using Moq;
using TopPalavras.Application.DTO;

namespace TopPalavras.Application.Tests
{
    [TestClass]
    public class QuantidadeDePalavrasTests
    {
        [TestMethod]
        public void ProcurarQuantidadeDePalavras()
        {
            var somenteTexto = new Mock<ISomenteTexto>();

            string[] palavras = {"minuto","minuto","minuto","seguro","seguro","seguro"};

            var separarPalavras = new Mock<ISepararPalavras>();
            separarPalavras.Setup(s => s.Separar(It.IsAny<string>()))
                .Returns(palavras);

            List<PalavraDTO> palavrasUnicas = new List<PalavraDTO> { 
                new PalavraDTO{ 
                    Palavra =  "minuto",
                    Quantidade = 3
                },
                new PalavraDTO{
                    Palavra = "seguro", 
                    Quantidade = 3
                }
            };

            var frequenciaPalavras = new Mock<IFrequenciaPalavras>();
            frequenciaPalavras.Setup(s => s.Procurar(It.IsAny<string[]>()))
                .Returns(palavrasUnicas);

            List<Topico> topicos = new List<Topico>(){
                new Topico{
                    Titulo = "Seguro Minuto",
                    Conteudo = "minuto minuto minuto seguro seguro seguro"
                }
            };
            QuantidadeDePalavras classTest = new QuantidadeDePalavras(somenteTexto.Object, separarPalavras.Object, frequenciaPalavras.Object);
            var result = classTest.Procurar(topicos);

            Assert.AreEqual("Seguro Minuto", result[0].Titulo);
            Assert.AreEqual(2, result[0].Palavras);
        }
    }
}
