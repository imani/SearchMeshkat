using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Store;
using Lucene.Net.Analysis.AR;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Search.Vectorhighlight;
using Lucene.Net.Search.Highlight;
using Lucene.Net.Index;

namespace Searcher
{
    public partial class Form1 : Form
    {
        private String path = @"..\..\..\Index\";
        public IndexSearcher searcher;
        public QueryParser text_parser;
        public QueryParser exactText_parser;
        public Indexer.ArabicAnalyzerPlus analyzer;
       
        public Form1()
        {
          
            Lucene.Net.Store.Directory indices = FSDirectory.Open(path);
            searcher = new IndexSearcher(indices);
            string[] Stopwords = File.ReadAllLines(@"..\..\..\Data\stopwords.txt", Encoding.UTF8);

            HashSet<string> StopHashst = new HashSet<string>();
            for (int i = 0; i < Stopwords.Length; i++)
            {
                try
                {

                    StopHashst.Add(Stopwords[i]);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            analyzer = new Indexer.ArabicAnalyzerPlus(Lucene.Net.Util.Version.LUCENE_CURRENT,StopHashst);
            text_parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_CURRENT, "text", analyzer);
            exactText_parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_CURRENT, "exactText", new Indexer.ArabicAnalyzerPlus(Lucene.Net.Util.Version.LUCENE_CURRENT, StopHashst, false));
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
           
            Query text_query = text_parser.Parse(txt_search.Text);
            Query exactText_query = exactText_parser.Parse(txt_search.Text);
            BooleanQuery booleanquery = new BooleanQuery();
            booleanquery.Add(text_query, Occur.MUST);
            booleanquery.Add(exactText_query, Occur.SHOULD);
            txt_analyzed.Text = text_query.ToString();
            var result = searcher.Search(booleanquery,10);
            txt_result1.Clear();
            
            FastVectorHighlighter highlighter = new FastVectorHighlighter();
            
            FieldQuery fieldQuery = highlighter.GetFieldQuery(booleanquery);
            
           
           
            foreach (var res in result.ScoreDocs)
            {
                string snippet = highlighter.GetBestFragment(fieldQuery, searcher.IndexReader, res.Doc, "text", 100);
           
                var resdoc = searcher.Doc(res.Doc);
                
                txt_result1.Text += "عنوان: " + resdoc.GetField("title").StringValue + "\r\n";
                if (resdoc.GetField("type").StringValue != "title")
                {
                    txt_result1.Text += " متن پاراگراف :  " + snippet;
                    txt_result.DocumentText += " متن پاراگراف :  " + snippet+"\n";
               
                }
                txt_result1.Text += Environment.NewLine + "شماره پاراگراف: " + resdoc.GetField("paragraphid").StringValue + "\n";
                txt_result1.Text += Environment.NewLine + "نام فایل: " + resdoc.GetField("filename").StringValue + "\n";
                txt_result1.Text += Environment.NewLine + "type : " + resdoc.GetField("type").StringValue + "\n";
                txt_result1.Text += Environment.NewLine + "--------------------------------" + Environment.NewLine;
                txt_result1.Refresh();
                
            }

            

      
            
        }

        static FastVectorHighlighter getHighlighter()
        {
            FragListBuilder fragListBuilder = new SimpleFragListBuilder();
            FragmentsBuilder fragmentBuilder =
            new ScoreOrderFragmentsBuilder(
            BaseFragmentsBuilder.COLORED_PRE_TAGS,
            BaseFragmentsBuilder.COLORED_POST_TAGS);
            return new FastVectorHighlighter(true, true,
            fragListBuilder, fragmentBuilder);
        }
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_search.Text.Length < 1)
                return;
            btn_search_Click(sender, e);
        }
    }
}
