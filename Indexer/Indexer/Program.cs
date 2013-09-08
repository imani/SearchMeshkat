using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Lucene.Net.Analysis.AR;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using System.IO;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;

using System.Xml.XPath;
using System.Xml;


namespace Indexer
{
  class Program
    {
      public struct JeldInformation
      {
          int index, start, end;
          public JeldInformation(String[] p)
          {
              index = Int32.Parse(p[0]);
              start = Int32.Parse(p[1]);
              end = Int32.Parse(p[2]);
          }
      }

      
        static void Main(string[] args)
        {
          
            Lucene.Net.Store.Directory index_dir = FSDirectory.Open(@"..\..\..\..\Index");
            String data_dir = @"..\..\..\..\Data\AllBooks\";
            string[] Stopwords = File.ReadAllLines(data_dir + "stopwords.txt",Encoding.UTF8);

            //create stop words set
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

            //name of books file
            StreamWriter filenameWriter = new StreamWriter(data_dir + "filenames.txt");
            String fileNames = "";

            ArabicAnalyzerPlus analyzer = new ArabicAnalyzerPlus(Lucene.Net.Util.Version.LUCENE_CURRENT, StopHashst);
            ArabicAnalyzerPlus simpleAnalyzer = new ArabicAnalyzerPlus(Lucene.Net.Util.Version.LUCENE_CURRENT, StopHashst, false);
            PerFieldAnalyzerWrapper perfieldAnalyzer = new PerFieldAnalyzerWrapper(analyzer);
            perfieldAnalyzer.AddAnalyzer("exactText", simpleAnalyzer);
            IndexWriter writer = new IndexWriter(index_dir, perfieldAnalyzer, IndexWriter.MaxFieldLength.UNLIMITED);
            
       

            //reading files
            DirectoryInfo dir = new DirectoryInfo(data_dir);

            //iterate over directories
            foreach (DirectoryInfo book in dir.GetDirectories())
            {
                string bookId = book.Name;
                DirectoryInfo text_dir = new DirectoryInfo(book.FullName + "/Text");
                StreamReader jeldReader = new StreamReader(book.FullName + "/Jelds.txt");
                var metadata_dir = new DirectoryInfo( book.FullName + "/MetaData/");
                List<JeldInformation> jeldList = new List<JeldInformation>();

                while (jeldReader.EndOfStream)
                {
                    var part = jeldReader.ReadLine().Split(',');
                    jeldList.Add(new JeldInformation(part));
                }

                foreach (FileInfo file in metadata_dir.GetFiles())
                {
                    var paragraphReader = new StreamReader(file.FullName);
                    var pageReader = new StreamReader(text_dir.FullName + file.Name);
                    int pageId = Int32.Parse(file.Name.Substring(0, file.Name.Length - file.Extension.Length));
                    int jeldId = 0;
                    while (true)
                    {
                        if (pageId > jeldIndex[jeldId])
                            jeldId++;
                    }
                    while (paragraphReader.EndOfStream)
                    {
                        string paraline = paragraphReader.ReadLine();
                        if (paraline.Contains("☺"))
                            paraline = paragraphReader.ReadLine();
                        string[] paragraph_indices = paragraphReader.ReadLine().Split(',');
                        int paragraph_num = Int32.Parse(paragraph_indices[0]);
                        int start = Int32.Parse(paragraph_indices[1]);
                        int count = Int32.Parse(paragraph_indices[2]) - start;

                        char[] buffer = new char[count];
                        pageReader.Read(buffer, start, count);
                        string text = new string(buffer);
                        Lucene.Net.Documents.Document doc  = createDoc(text, bookId, jeldId, pageId, paragraph_num);
                        writer.AddDocument(doc);
                    }
                    
                }             
                
            }

            //write name of files in a text file
            filenameWriter.Write(fileNames);
            filenameWriter.Close();

            writer.Optimize();
            writer.Commit();
            writer.Dispose();

        }

      /*
        static void IndexFunc(string filePath, IndexWriter writer)
        {
            StreamReader reader = new StreamReader(filePath);

            Lucene.Net.Documents.Document doc;
            var document = WordprocessingDocument.Open(filePath, false);
            MainDocumentPart mainPart = document.MainDocumentPart;
            List<Paragraph> pars = mainPart.Document.Body.Elements<Paragraph>().ToList();
           // StreamWriter MyStreamWriter = new StreamWriter(@"C:\Users\mohammad\Desktop\"+Path.GetFileName(filePath)+".txt", true, Encoding.UTF8);
            string title = "";
            for (int i = 0; i < pars.Count; i++)
            {
             
                doc = new Lucene.Net.Documents.Document();
                Paragraph mypar = new Paragraph();
                mypar = pars[i];
                string texte = pars[i].InnerText;
                string xpath = "main/w:r/w:rPr/w:color";

                XmlDocument MyDocument = new XmlDocument();
          
                string xml = "<main>" + mypar.InnerXml + "</main>";
                MyDocument.LoadXml(xml);
               // MyStreamWriter.WriteLine(xml);

                XmlNamespaceManager nsMgr = new XmlNamespaceManager(MyDocument.NameTable);
                nsMgr.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");

              
                XmlNode MyNode = MyDocument.SelectSingleNode(xpath, nsMgr);
                string xpath2 = "main/w:r/w:rPr/w:sz";
                XmlNode FooterNode = MyDocument.SelectSingleNode(xpath2, nsMgr);

                Lucene.Net.Documents.Field type;
                
                if(pars[i].InnerText.Length>3)
                if (!pars[i].InnerXml.Contains("center") && pars[i].InnerXml.Contains("w:color") && !pars[i].InnerXml.Contains("w:sz w:val=\"21\""))
                {
                    if (MyNode != null)
                    {
                        if (MyNode.Attributes[0].Value == "465BFF" || MyNode.Attributes[0].Value == "6C3A00")
                        {
                            type = new Lucene.Net.Documents.Field("type", "title", Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED);
                            title = pars[i].InnerText;
                        }
                        else
                        {
                            type = new Lucene.Net.Documents.Field("type", "text", Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED);
                        }
                    }
                    else
                    {
                        type = new Lucene.Net.Documents.Field("type", "text", Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED);
                    }
                   // MyStreamWriter.WriteLine("type = " + type.StringValue + "\ntitle  = " + title + "\ntext = " + pars[i].InnerText);
                    Lucene.Net.Documents.Field fileName = new Lucene.Net.Documents.Field("filename", Path.GetFileName(filePath).Replace(".docx",""), Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NOT_ANALYZED);
                    Lucene.Net.Documents.Field ParagraphId = new Lucene.Net.Documents.Field("paragraphid", i.ToString(), Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NO);
                    Lucene.Net.Documents.Field text = new Lucene.Net.Documents.Field("text", pars[i].InnerText, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
                    Lucene.Net.Documents.Field Title = new Lucene.Net.Documents.Field("title", title, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED);
                   

                   
                    doc.Add(Title);
                    doc.Add(fileName);
                    doc.Add(text);
                    doc.Add(ParagraphId);
                    doc.Add(type);
                    // add index of exact words
                    doc.Add(new Lucene.Net.Documents.Field("exactText", pars[i].InnerText, Lucene.Net.Documents.Field.Store.NO, Lucene.Net.Documents.Field.Index.ANALYZED,Field.TermVector.WITH_POSITIONS_OFFSETS));

                    writer.AddDocument(doc);
                   
                }

            }
     
        }*/

        static Lucene.Net.Documents.Document createDoc(String text, string bookId, int jeldId, int pageId, int paragraphId)
        {
            var doc = new Lucene.Net.Documents.Document();
            doc.Add( new Field("text", text, Field.Store.NO, Field.Index.ANALYZED));
            doc.Add( new Field("bookId", bookId, Field.Store.YES, Field.Index.NO));
            doc.Add( new Field("jeldId", jeldId.ToString(), Field.Store.YES, Field.Index.NO));
            doc.Add( new Field("pageId", pageId.ToString(), Field.Store.YES, Field.Index.NO));
            doc.Add( new Field("paragraphId", paragraphId.ToString(), Field.Store.YES, Field.Index.NO));

            return doc;
        }

    }
}
