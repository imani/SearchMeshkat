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
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {

            Query q = text_parser.Parse(txt_search.Text);
            txt_analyzed.Text = q.ToString();
            var result = searcher.Search(q,10);
            txt_result.Clear();
            FastVectorHighlighter highlighter = getHighlighter();
            FieldQuery fieldQuery = highlighter.GetFieldQuery(q);
          
            foreach (var res in result.ScoreDocs)
            {
               
                var resdoc = searcher.Doc(res.Doc);
                
                txt_result.Text += "عنوان: " + resdoc.GetField("title").StringValue + "\r\n";
                if (resdoc.GetField("type").StringValue != "title")
                {
                    txt_result.Text += " متن پاراگراف :  " + resdoc.GetField("text").StringValue;

                    //highlighte words
                    //
                }
                txt_result.Text += Environment.NewLine + "شماره پاراگراف: " + resdoc.GetField("paragraphid").StringValue + "\n";
                txt_result.Text += Environment.NewLine + "نام فایل: " + resdoc.GetField("filename").StringValue + "\n";
                txt_result.Text += Environment.NewLine + "type : " + resdoc.GetField("type").StringValue + "\n";
                txt_result.Text += Environment.NewLine + "--------------------------------" + Environment.NewLine;
                txt_result.Refresh();
                
            }

            

            //this.txt_result.SelectAll();
            //this.txt_result.SelectionBackColor = Color.White;

            //int index, lastindex;
            //index = 0;
            //lastindex = txt_result.Text.LastIndexOf(txt_search.Text);
            //string querytxt=txt_analyzed.Text.Replace("text","");
            //querytxt=querytxt.Replace(":","");
            //while (index < lastindex)
            //{

            //    this.txt_result.Find(querytxt, index, txt_result.Text.Length, RichTextBoxFinds.None);
            //    this.txt_result.SelectionBackColor = Color.Yellow;
            //    index = this.txt_result.Text.IndexOf(querytxt, index) + 1;

            //}
            
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
