using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TopPalavras.Application.Infrastructure;
using System.ServiceModel.Syndication;
using System.Collections.Generic;
using TopPalavras.Domain;

namespace TopPalavras.Application.Tests
{
    [TestClass]
    public class LerTopicoTests
    {
        [TestMethod]
        public void LerTopicos()
        {
            SyndicationFeed feed = new SyndicationFeed()
            {
                Items = new List<SyndicationItem>() { 
                    new SyndicationItem(){
                        Title = new TextSyndicationContent("Titulo 1"),
                        Content = new TextSyndicationContent("Conteudo 1")
                    },
                    new SyndicationItem(){
                        Title = new TextSyndicationContent("Titulo 2"),
                        Content = new TextSyndicationContent("Conteudo 2")
                    }
                }
            };
            var LeitorFeedMoq = new Mock<ILeitorFeed>();
            LeitorFeedMoq                
                .Setup(s => s.Ler(It.IsAny<string>()))
                .Returns(feed)
                ;

            LerTopicos classTest = new LerTopicos(LeitorFeedMoq.Object);
            List<Topico> topicos = classTest.Ler("http://link", 10);

            Assert.AreEqual(2, topicos.Count);
            Assert.AreEqual("Titulo 1", topicos[0].Titulo);
            Assert.AreEqual("Conteudo 1", topicos[0].Conteudo);
            Assert.AreEqual("Titulo 2", topicos[1].Titulo);
            Assert.AreEqual("Conteudo 2", topicos[1].Conteudo);
        }

        [TestMethod]
        public void LerTopicosRestringindo()
        {
            SyndicationFeed feed = new SyndicationFeed()
            {
                Items = new List<SyndicationItem>() { 
                    new SyndicationItem(){
                        Title = new TextSyndicationContent("Titulo 1"),
                        Content = new TextSyndicationContent("Conteudo 1")
                    },
                    new SyndicationItem(){
                        Title = new TextSyndicationContent("Titulo 2"),
                        Content = new TextSyndicationContent("Conteudo 2")
                    }
                }
            };
            var LeitorFeedMoq = new Mock<ILeitorFeed>();
            LeitorFeedMoq
                .Setup(s => s.Ler(It.IsAny<string>()))
                .Returns(feed)
                ;

            LerTopicos classTest = new LerTopicos(LeitorFeedMoq.Object);
            List<Topico> topicos = classTest.Ler("http://link", 1);

            Assert.AreEqual(1, topicos.Count);
            Assert.AreEqual("Titulo 1", topicos[0].Titulo);
            Assert.AreEqual("Conteudo 1", topicos[0].Conteudo);
        }
    }
}
