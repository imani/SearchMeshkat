using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using Lucene.Net;
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


      
        static void Main(string[] args)
        {
          
            Lucene.Net.Store.Directory index_dir = FSDirectory.Open(@"..\..\..\..\Index");
            string[] Stopwords = File.ReadAllLines(@"..\..\..\..\Data\stopwords.txt",Encoding.UTF8);
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

            ArabicAnalyzerPlus analyzer = new ArabicAnalyzerPlus(Lucene.Net.Util.Version.LUCENE_CURRENT, StopHashst);
            ArabicAnalyzerPlus simpleAnalyzer = new ArabicAnalyzerPlus(Lucene.Net.Util.Version.LUCENE_CURRENT, StopHashst, false);
            PerFieldAnalyzerWrapper perfieldAnalyzer = new PerFieldAnalyzerWrapper(analyzer);
            perfieldAnalyzer.AddAnalyzer("exactText", simpleAnalyzer);
            IndexWriter writer = new IndexWriter(index_dir, perfieldAnalyzer, IndexWriter.MaxFieldLength.UNLIMITED);
            
       

            //reading files
            // String path = @"C:\Users\mohammad\Documents\Visual Studio 2012\Projects\SearchEngine\Data";
            String path = @"..\..\..\..\Data\";
            DirectoryInfo dir = new DirectoryInfo(path);
            //  writer.WriteLockTimeout = 3600000;

            foreach (FileInfo file in dir.GetFiles())
            {
                // writer.WriteLockTimeout = 3600000;
               //status.Text = "file = " + file.Name;
                //you can add your indexing code here
                // index .docx files in path with indexwriter
                if (file.Extension == ".docx")
                {


                    IndexFunc(file.FullName, writer);

                    Console.WriteLine("Indexing " + file.Name + " Finished.");
                }
            }
            writer.Optimize();
            writer.Commit();
            writer.Dispose();

        }

        static void IndexFunc(string filePath, IndexWriter writer)
        {
            StreamReader reader = new StreamReader(filePath);

            Lucene.Net.Documents.Document doc;
            var document = WordprocessingDocument.Open(filePath, false);
            MainDocumentPart mainPart = document.MainDocumentPart;
            List<Paragraph> pars = mainPart.Document.Body.Elements<Paragraph>().ToList();


            for (int i = 0; i < pars.Count; i++)
            {
                //  writer.Flush(true, true, true);
                doc = new Lucene.Net.Documents.Document();
                Paragraph mypar = new Paragraph();
                mypar = pars[i];
                string texte = pars[i].InnerText;
                string xpath = "main/w:r/w:rPr/w:color";

                XmlDocument MyDocument = new XmlDocument();
          
                string xml = "<main>" + mypar.InnerXml + "</main>";
                MyDocument.LoadXml(xml);


                XmlNamespaceManager nsMgr = new XmlNamespaceManager(MyDocument.NameTable);
                nsMgr.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");

              
                XmlNode MyNode = MyDocument.SelectSingleNode(xpath, nsMgr);
                string xpath2 = "main/w:r/w:rPr/w:sz";
                XmlNode FooterNode = MyDocument.SelectSingleNode(xpath2, nsMgr);

                Lucene.Net.Documents.Field type;
                string title = "";
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

                    Lucene.Net.Documents.Field fileName = new Lucene.Net.Documents.Field("filename", Path.GetFileName(filePath), Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NO);
                    Lucene.Net.Documents.Field ParagraphId = new Lucene.Net.Documents.Field("paragraphid", i.ToString(), Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NO);
                    Lucene.Net.Documents.Field text = new Lucene.Net.Documents.Field("text", pars[i].InnerText, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED);
                    Lucene.Net.Documents.Field Title = new Lucene.Net.Documents.Field("title", title, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.NO);
                    doc.Add(Title);
                    doc.Add(fileName);
                    doc.Add(text);
                    doc.Add(ParagraphId);
                    doc.Add(type);
                    // add index of exact words
                    doc.Add(new Lucene.Net.Documents.Field("exactText", pars[i].InnerText, Lucene.Net.Documents.Field.Store.NO, Lucene.Net.Documents.Field.Index.ANALYZED));

                    writer.AddDocument(doc);
                }

            }
        }
    }
}
