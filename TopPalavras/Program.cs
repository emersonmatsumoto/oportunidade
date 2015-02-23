using StructureMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TopPalavras.Application;
using TopPalavras.Application.DTO;
using TopPalavras.Application.Infrastructure;
using TopPalavras.Domain;
using TopPalavras.Infrastructure;

namespace TopPalavras
{
    class Program
    {
        static void Main(string[] args)
        {           
            IContainer container = ConfigureDependencies();

            ILerTopicos lerTopicos = container.GetInstance<ILerTopicos>();
            IDezPrincipaisPalavras dezPrincipaisPalavras = container.GetInstance<IDezPrincipaisPalavras>();
            IQuantidadeDePalavras quantidadeDePalavras = container.GetInstance<IQuantidadeDePalavras>();

            List<Topico> topicos = lerTopicos.Ler("http://www.minutoseguros.com.br/blog/feed/", 10);
            List<PalavraDTO> palavras = dezPrincipaisPalavras.Procurar(topicos);
            List<TopicoDTO> topicoDTOs = quantidadeDePalavras.Procurar(topicos);

            PrintDezPrincipaisPalavras(palavras);
            Console.WriteLine();
            PrintQuantidadeDePalavras(topicoDTOs);

            Console.ReadKey();
        }

        private static void PrintDezPrincipaisPalavras(List<PalavraDTO> palavras)
        {
            Console.WriteLine(String.Format("Dez principais palavras"));
            foreach (var palavra in palavras)
            {
                Console.WriteLine(String.Format("{0} - {1}", palavra.Quantidade, palavra.Palavra));
            }
        }

        private static void PrintQuantidadeDePalavras(List<TopicoDTO> topicos)
        {
            Console.WriteLine(String.Format("Quantidade de palavras por tópico"));
            foreach (var topico in topicos)
            {
                Console.WriteLine(String.Format("{0} - {1} palavras.", topico.Titulo, topico.Palavras));
            }
        }

        private static IContainer ConfigureDependencies()
        {
            return new Container(x =>
            {
                x.For<ILeitorFeed>().Use<LeitorFeed>();
                x.For<ILerTopicos>().Use<LerTopicos>();
                x.For<ISomenteTexto>().Use<SomenteTexto>();
                x.For<ISepararPalavras>().Use<SepararPalavras>();
                x.For<IFrequenciaPalavras>().Use<FrequenciaPalavras>();
                x.For<IDezPrincipaisPalavras>().Use<DezPrincipaisPalavras>();
                x.For<IQuantidadeDePalavras>().Use<QuantidadeDePalavras>();
            });
        }

    }
}
