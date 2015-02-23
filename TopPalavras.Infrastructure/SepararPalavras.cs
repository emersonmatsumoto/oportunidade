using TopPalavras.Application.Infrastructure;
using System.Linq;

namespace TopPalavras.Infrastructure
{
    public class SepararPalavras : ISepararPalavras
    {
        readonly static string[] BRAZILIAN_STOP_WORDS = {
      "a","ainda","alem","ambas","ambos","antes",
      "ao","aonde","aos","apos","aquele","aqueles",
      "as","assim","com","como","contra","contudo",
      "cuja","cujas","cujo","cujos","da","das","de",
      "dela","dele","deles","demais","depois","desde",
      "desta","deste","dispoe","dispoem","diversa",
      "diversas","diversos","do","dos","durante","e",
      "ela","elas","ele","eles","em","entao","entre",
      "essa","essas","esse","esses","esta","estas",
      "este","estes","ha","isso","isto","logo","mais",
      "mas","mediante","menos","mesma","mesmas","mesmo",
      "mesmos","na","nas","nao","nas","nem","nesse","neste",
      "nos","o","os","ou","outra","outras","outro","outros",
      "pelas","pelas","pelo","pelos","perante","pois","por",
      "porque","portanto","proprio","propios","quais","qual",
      "qualquer","quando","quanto","que","quem","quer","se",
      "seja","sem","sendo","seu","seus","sob","sobre","sua",
      "suas","tal","tambem","teu","teus","toda","todas","todo",
      "todos","tua","tuas","tudo","um","uma","umas","uns", "para", "é", "não", "no", "-", "ser", "são", "–"};

        public string[] Separar(string Texto)
        {
            char[] whitespace = new char[] { ' ', '\t', '\n', '.', ',', '\r', ':', '!', '?', '*', '(', ')', '[', ']', '{', '}' };
            string[] palavras = Texto.ToLower().Split(whitespace, System.StringSplitOptions.RemoveEmptyEntries);

            var q = from palavra in palavras
                    join stopWord in BRAZILIAN_STOP_WORDS on palavra equals stopWord into gj
                    from sub in gj.DefaultIfEmpty()
                    where sub == null
                    select palavra;

            return q.ToArray();
        }
    }
}
