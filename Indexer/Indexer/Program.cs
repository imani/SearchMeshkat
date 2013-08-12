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
            String data_dir = @"..\..\..\..\Data\";
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

            foreach (FileInfo file in dir.GetFiles())
            {
                
                if (file.Extension == ".docx")
                {
                    fileNames += file.Name.Substring(0, file.Name.Length - 5) + ",";
                    IndexFunc(file.FullName, writer);
                    Console.WriteLine("Indexing " + file.Name + " Finished.");
                }
            }

            //write name of files in a text file
            filenameWriter.Write(fileNames);
            filenameWriter.Close();

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
          //  MyStreamWriter.Close();
        }
    }
}
