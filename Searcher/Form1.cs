using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Store;
using Lucene.Net.Analysis.AR;
using Lucene.Net.Analysis.Standard;

namespace Searcher
{
    public partial class Form1 : Form
    {
        private String path = @"..\..\..\Index\";
        public IndexSearcher searcher;
        public QueryParser text_parser;
        public Indexer.ArabicAnalyzerPlus analyzer;
        public Form1()
        {
            Lucene.Net.Store.Directory indices = FSDirectory.Open(path);
            searcher = new IndexSearcher(indices);
            analyzer = new Indexer.ArabicAnalyzerPlus(Lucene.Net.Util.Version.LUCENE_CURRENT);
            text_parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_CURRENT, "text", analyzer);
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Query q = text_parser.Parse(txt_search.Text);
            txt_analyzed.Text = q.ToString();
            var result = searcher.Search(q,1);
            foreach (var res in result.ScoreDocs)
            {
                var resdoc = searcher.Doc(res.Doc);
                txt_result.Text = res.Score + "  " + resdoc.GetField("text").StringValue + "\n";
            }
            
        }
    }
}
