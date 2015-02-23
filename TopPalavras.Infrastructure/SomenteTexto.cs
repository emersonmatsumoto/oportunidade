using System.Web;
using TopPalavras.Application.Infrastructure;

namespace TopPalavras.Infrastructure
{
    public class SomenteTexto : ISomenteTexto
    {
        public string Limpar(string Texto)
        {
            Texto = HtmlRemoval.StripTagsRegexCompiled(Texto);
            Texto = HttpUtility.HtmlDecode(Texto);

            return Texto;
        }
    }
}
