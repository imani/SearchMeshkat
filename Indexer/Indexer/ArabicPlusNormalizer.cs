using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    class ArabicPlusNormalizer
    {
        public String Normalize(String input, int len)
        {
            return input.Replace('ک', 'ك').Replace('ی', 'ي');
        }
    }
}
