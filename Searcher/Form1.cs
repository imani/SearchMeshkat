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
            var result = searcher.Search(q,10);
            txt_result.Clear();
            foreach (var res in result.ScoreDocs)
            {
                var resdoc = searcher.Doc(res.Doc);
                txt_result.Text += "عنوان: " + resdoc.GetField("title").StringValue + "\r\n";
                if (resdoc.GetField("type").StringValue != "title")
                {
                    txt_result.Text += "  " + resdoc.GetField("text").StringValue;
                    
                }
                txt_result.Text += Environment.NewLine + "--------------------------------" + Environment.NewLine;
                txt_result.Refresh();
                
            }
            
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_search.Text.Length < 1)
                return;
            btn_search_Click(sender, e);
        }
    }
}
