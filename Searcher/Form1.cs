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
using System.Text.RegularExpressions;
using System.Diagnostics;

using DevComponents.DotNetBar.Controls;

using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Store;
using Lucene.Net.Analysis.AR;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Search.Vectorhighlight;
using Lucene.Net.Search.Highlight;
using Lucene.Net.Index;
using Lucene.Net.Documents;

namespace Searcher
{
    public partial class Form1 : Form
    {
        private String path = @"..\..\..\Index\";
        public IndexSearcher searcher;
        public QueryParser text_parser;
        public QueryParser exactText_parser;
        public Indexer.ArabicAnalyzerPlus analyzer;
        public QueryWrapperFilter filename_filter;
        public List<KeyValuePair<string, int>> RasoolList = new List<KeyValuePair<string, int>>();

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
            string StBuilder = "";
            RasoolList.Clear();

            Query text_query = text_parser.Parse(txt_search.Text);
            Query exactText_query = exactText_parser.Parse(txt_search.Text);
            BooleanQuery booleanquery = new BooleanQuery();
            booleanquery.Add(text_query, Occur.MUST);
            booleanquery.Add(exactText_query, Occur.SHOULD);
            txt_analyzed.Text = text_query.ToString();
            SortField[] SortFields = new SortField[] { new SortField("filename", SortField.STRING), new SortField("paragraphid", SortField.STRING) };
            Sort FNameSort = new Sort(SortFields);
            Sort scoreSort = new Sort();
            TopFieldDocs result=null;
            if (cmb_Sort.SelectedIndex==1)//search sort filename
            {
                 result = searcher.Search(booleanquery, filename_filter, 10, FNameSort);

            }
            else if (cmb_Sort.SelectedIndex==0)
            {
               
                result = searcher.Search(booleanquery, filename_filter, 10, scoreSort);
               
            }
            panelEx1.ResetText();
            FastVectorHighlighter highlighter = new FastVectorHighlighter();
            
            FieldQuery fieldQuery = highlighter.GetFieldQuery(booleanquery);


            string filePath=@"..\..\..\Data\";

            foreach (var res in result.ScoreDocs)
            {
                var resdoc = searcher.Doc(res.Doc);
                  
                

                string snippet = highlighter.GetBestFragment(fieldQuery, searcher.IndexReader, res.Doc, "text", 1000);
                snippet = snippet.Replace("<b>", "<b> <font   color=\"blue\">");
                snippet = snippet.Replace("</b>","</font></b>");

                StBuilder+="<b>عنوان:</b> " + resdoc.GetField("title").StringValue;
                //panelEx1.Text += "<b>عنوان:</b> " + resdoc.GetField("title").StringValue;

                KeyValuePair<string, int> ResultPair = new KeyValuePair<string, int>(resdoc.GetField("filename").StringValue, Convert.ToInt16(resdoc.GetField("paragraphid").StringValue));
                RasoolList.Add(ResultPair);


                if (resdoc.GetField("type").StringValue != "title")
                {
                    StBuilder+="<br/>" + " <b>متن پاراگراف :</b>  " + snippet;
                   
                    // panelEx1.Text += "<br/>"+" <b>متن پاراگراف :</b>  " + snippet;
             
                }
                StBuilder+="<br/><b>شماره پاراگراف:</b> " + resdoc.GetField("paragraphid").StringValue + "\n";
                StBuilder+="<br/><b>نام فایل:</b> <a onclick=\"alert('hello');\" href=\"" + filePath + resdoc.GetField("filename").StringValue + ".docx\" >" + resdoc.GetField("filename").StringValue+"</a>";
                StBuilder+="<br/><b>نوع :</b> " + resdoc.GetField("type").StringValue + "<br/>";


                //panelEx1.Text += "<br/><b>شماره پاراگراف:</b> " + resdoc.GetField("paragraphid").StringValue + "\n";
                //panelEx1.Text += "<br/><b>نام فایل:</b> <a onclick=\"alert('hello');\" href=\"" + filePath + resdoc.GetField("filename").StringValue + ".docx\" >" + resdoc.GetField("filename").StringValue+"</a>";
                //panelEx1.Text += "<br/><b>نوع :</b> " + resdoc.GetField("type").StringValue + "<br/>";

                StBuilder+="--------------------------<br/>";
                //panelEx1.Text += "--------------------------<br/>" ;
                panelEx1.Text = StBuilder.ToString();
            
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

        private void txt_result_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmb_Sort.SelectedIndex = 0;
            pageNavigator1.NavigateNextPage += pageNavigator1_NavigateNextPage;
            pageNavigator1.NavigatePreviousPage += pageNavigator1_NavigatePreviousPage;
            panelEx1.MarkupLinkClick += panelEx1_MarkupLinkClick;
            string FilesPath = @"..\..\..\Data\filenames.txt";
            StreamReader MyReader = new StreamReader(FilesPath, Encoding.UTF8);
            int SpaceBeetweenCheckboxes = 27;
            int ylocation = 0;
            string allfilenames = MyReader.ReadToEnd();
            string[] filenames = allfilenames.Split(',');
            for (int i = 0; i < filenames.Length; i++)
            {

                if (filenames[i].Length > 0)
                {
                    CheckBoxX MycheckBox = new CheckBoxX();
                    MycheckBox.Font = new System.Drawing.Font("B Nazanin", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    MycheckBox.Text = filenames[i];
                    MycheckBox.RightToLeft = RightToLeft.Yes;
                    Size MySize = new Size(250, 23);
                    MycheckBox.Size = MySize;
                    MycheckBox.Parent = pnlCheckbox;
                    MycheckBox.Location =
                 
                    MycheckBox.Location = new System.Drawing.Point(5, ylocation);
                    MycheckBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                    MycheckBox.Checked = true;
                    MycheckBox.CheckedChanged += MycheckBox_CheckedChanged;
                   
                    ylocation += SpaceBeetweenCheckboxes;
                  
                }
            }


      
        }
       
        void pageNavigator1_NavigatePreviousPage(object sender, EventArgs e)
        {
            
        }

        void pageNavigator1_NavigateNextPage(object sender, EventArgs e)
        {
           //TermRangeQuery RangeQuery=new TermRangeQuery(
        }

        void panelEx1_MarkupLinkClick(object sender, DevComponents.DotNetBar.MarkupLinkClickEventArgs e)
        {
            Process p = new Process();
            if (File.Exists(e.HRef))
            {
                ProcessStartInfo MyInfo = new ProcessStartInfo(e.HRef);
                p.StartInfo = MyInfo;
                p.Start();
            }
        }

        void MycheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_search.Text.Length < 1)
                return;

            List<string> FileNameList = new List<string>();
            BooleanQuery filename_query = new BooleanQuery();
            Query filterQuery;
            foreach (Control ctl in pnlCheckbox.Controls)
            {
                CheckBoxX Mycheck = ctl as CheckBoxX;
                if (Mycheck.Checked)
                {
                    filterQuery = new TermQuery(new Term("filename", Mycheck.Text));
                    filename_query.Add(filterQuery, Occur.SHOULD);
                }
            }

            filename_filter = new QueryWrapperFilter(filename_query);

            btn_search_Click(sender, e);
        }

      

        private void cmb_Sort_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(txt_search.Text.Length>1)
                btn_search_Click(sender, e);
            
        }

      
    }
}
