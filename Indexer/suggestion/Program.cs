using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Store;
using Lucene.Net.Analysis.AR;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Search.Vectorhighlight;
using Lucene.Net.Search.Highlight;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using SpellChecker.Net.Search.Spell;
namespace suggestion
{
    class Program
    {
        static void makeSuggestList()
           {
                String spellCheckDir = @"..\..\..\..\Data\spellCheckDir";
                String indexDir = @"..\..\..\..\Index";
                String indexField = "text";
                Console.Write("Now build SpellChecker index...");
                Lucene.Net.Store.Directory dir = FSDirectory.Open(spellCheckDir);
                SpellChecker.Net.Search.Spell.SpellChecker spell = new SpellChecker.Net.Search.Spell.SpellChecker(dir);
                Lucene.Net.Store.Directory dir2 = FSDirectory.Open(indexDir);
                IndexReader r = Lucene.Net.Index.IndexReader.Open(dir2, true);;
                try {
                spell.IndexDictionary(new LuceneDictionary(r, indexField));
                }
                finally
                {
                   r.Close();
                 }
                         dir.Close();
            }

        static void Main(string[] args)
        {
            makeSuggestList();
           

        }
    }
}
