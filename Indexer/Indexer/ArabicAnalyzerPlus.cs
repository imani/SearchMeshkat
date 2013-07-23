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
    public class ArabicAnalyzerPlus : ArabicAnalyzer
    {
        public ArabicAnalyzerPlus(Lucene.Net.Util.Version version)
            : base(version)
        {
            ;// constructor
        }
        public override TokenStream TokenStream(string fieldName, System.IO.TextReader reader)
        {
            String text = reader.ReadToEnd().Replace('ک', 'ك').Replace('ی', 'ي');
            reader = new StringReader(text);
            return base.TokenStream(fieldName, reader);
        }
    }
}
