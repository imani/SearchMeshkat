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
        public int PageCounter;
        public int ResultPerPage;
        public List<string> ResultList;
        Int32 allchar = 0;
        public Form1()
        {

            ResultPerPage = 1000;
            ResultList = new List<string>();
            
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
            PageCounter = 0;
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
           pagelabel.Text ="شماره صفحه : "+ (PageCounter + 1).ToString();
           string ResultString = "";
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
                result = searcher.Search(booleanquery, filename_filter, (PageCounter + 1) * ResultPerPage, FNameSort);

            }
            else if (cmb_Sort.SelectedIndex==0)
            {

                result = searcher.Search(booleanquery, filename_filter, (PageCounter + 1) * ResultPerPage, scoreSort);
               
            }
            panelEx1.ResetText();
            FastVectorHighlighter highlighter = new FastVectorHighlighter();
            
            FieldQuery fieldQuery = highlighter.GetFieldQuery(booleanquery);


            string filePath=@"..\..\..\Data\";
            

            for (int i = PageCounter *ResultPerPage; i < result.ScoreDocs.Length; i++)
            {
                string StingVar = "";

                var res = result.ScoreDocs[i];
                var resdoc = searcher.Doc(res.Doc);


                    string snippet = highlighter.GetBestFragment(fieldQuery, searcher.IndexReader, res.Doc, "text", 1000);
                    snippet = snippet.Replace("<b>", "<b> <font   color=\"blue\">");
                    snippet = snippet.Replace("</b>", "</font></b>");
                //    ResultString += "شماره جستجو : "+i.ToString()+"<br/>";
                    StingVar += "شماره جستجو : " + i.ToString() + "<br/>";
              //  ResultString += "<b>عنوان:</b> " + resdoc.GetField("title").StringValue;
                    StingVar += "<b>عنوان:</b> " + resdoc.GetField("title").StringValue; ;
                //panelEx1.Text += "<b>عنوان:</b> " + resdoc.GetField("title").StringValue;

                    KeyValuePair<string, int> ResultPair = new KeyValuePair<string, int>(resdoc.GetField("filename").StringValue, Convert.ToInt16(resdoc.GetField("paragraphid").StringValue));
                    RasoolList.Add(ResultPair);


                    if (resdoc.GetField("type").StringValue != "title")
                    {
                     //   ResultString += "<br/>" + " <b>متن پاراگراف :</b>  " + snippet;
                        StingVar += "<br/>" + " <b>متن پاراگراف :</b>  " + snippet;
                        // panelEx1.Text += "<br/>"+" <b>متن پاراگراف :</b>  " + snippet;

                    }
                  //  ResultString += "<br/><b>شماره پاراگراف:</b> " + resdoc.GetField("paragraphid").StringValue + "\n";
                  //  ResultString += "<br/><b>نام فایل:</b> <a  href=\"" + filePath + resdoc.GetField("filename").StringValue + ".docx\" >" + resdoc.GetField("filename").StringValue + "</a>";
                  //  ResultString += "<br/><b>نوع :</b> " + resdoc.GetField("type").StringValue + "<br/>";


                    
                         StingVar += "<br/><b>شماره پاراگراف:</b> " + resdoc.GetField("paragraphid").StringValue + "\n";
                    StingVar += "<br/><b>نام فایل:</b> <a  href=\"" + filePath + resdoc.GetField("filename").StringValue + ".docx\" >" + resdoc.GetField("filename").StringValue + "</a>";
                    StingVar += "<br/><b>نوع :</b> " + resdoc.GetField("type").StringValue + "<br/>";


                    //panelEx1.Text += "<br/><b>شماره پاراگراف:</b> " + resdoc.GetField("paragraphid").StringValue + "\n";
                    //panelEx1.Text += "<br/><b>نام فایل:</b> <a onclick=\"alert('hello');\" href=\"" + filePath + resdoc.GetField("filename").StringValue + ".docx\" >" + resdoc.GetField("filename").StringValue+"</a>";
                    //panelEx1.Text += "<br/><b>نوع :</b> " + resdoc.GetField("type").StringValue + "<br/>";

                 //   ResultString += "--------------------------<br/>";
                StingVar += "--------------------------<br/>";
                    //panelEx1.Text += "--------------------------<br/>" ;
                    ResultList.Add(StingVar);
                   
                }

            for (int i = 0; i < 10; i++)
            {
                panelEx1.Text += ResultList[i];
            }

            
             
        }
        int cur = 10;
        void panelEx1_Scroll(object sender, ScrollEventArgs e)
        {
            //if(e.NewValue>10000)
           // MessageBox.Show("max" + panelEx1.VerticalScroll.Maximum + "new" + e.NewValue.ToString());

            // int currentPar = e.NewValue / panelEx1.VerticalScroll.Maximum
            if (e.NewValue > panelEx1.VerticalScroll.Maximum - 500)
            {
                for (int k = 0; k < 5; k++)
                {
                    panelEx1.Text += ResultList.ElementAt(cur);
                    cur ++;
                }
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

            //btn_search_Click(sender, e);
        }

        private void txt_result_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblRPP.Text = "تعداد نتایج در هر صفحه : "+ResultPerPage.ToString();
            cmb_Sort.SelectedIndex = 0;
            this.MouseWheel += Form1_MouseWheel;
            pageNavigator1.NavigateNextPage += pageNavigator1_NavigateNextPage;
            pageNavigator1.NavigatePreviousPage += pageNavigator1_NavigatePreviousPage;
            panelEx1.Scroll += panelEx1_Scroll;
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

        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            panelEx1.Focus();
        }

      
       
        void pageNavigator1_NavigatePreviousPage(object sender, EventArgs e)
        {
            PageCounter--;
            
            btn_search_Click(sender, e);

        }

        void pageNavigator1_NavigateNextPage(object sender, EventArgs e)
        {
            PageCounter++;
            btn_search_Click(sender, e);
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
            if (txt_search.Text.Length > 1)
               btn_search_Click(sender, e);
            
        }

      
    }
}
