using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis.AR;
using Lucene.Net.Analysis;
using System.IO;

namespace Indexer
{
    public class ArabicAnalyzerPlus : Analyzer
    {
        private readonly Lucene.Net.Util.Version _version;
        public ArabicAnalyzerPlus(Lucene.Net.Util.Version version)
        {
            _version = version;
        }
        public override TokenStream TokenStream(string fieldName, System.IO.TextReader reader)
        {
            TokenStream result = new ArabicLetterTokenizer(reader);
            result = new ArabicPlusNormalizationFilter(result);
            result = new ArabicNormalizationFilter(result);
            result = new ArabicStemFilter(result);
            return result; 
        }
    }
}
