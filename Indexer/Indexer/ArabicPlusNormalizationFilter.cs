using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Tokenattributes;

namespace Indexer
{
    class ArabicPlusNormalizationFilter: TokenFilter
    {
        private readonly ArabicPlusNormalizer _normalizer;
        private readonly TermAttribute _termAtt;

        public ArabicPlusNormalizationFilter(TokenStream input)
            : base(input)
        {
            _normalizer = new ArabicPlusNormalizer();
            _termAtt = (TermAttribute)input.AddAttribute<ITermAttribute>();
        }

        public override bool IncrementToken()
        {
            //if (_termAtt.Term.Length <= 2)
            //    return false;
            if (input.IncrementToken())
            {
                string normalized =  _normalizer.Normalize(_termAtt.Term, _termAtt.TermLength());
                _termAtt.SetTermBuffer(normalized);
                return true;
            }
            return false;
        }
    }
    
}
