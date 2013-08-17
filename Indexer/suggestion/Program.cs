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

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;

using System.Xml.XPath;
using System.Xml;

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

        static Dictionary<String, int> wordFreqList(string filePath, Dictionary<String, int> wfDic, String[] Stopwords)
        {
            int counter = 0;
            StreamReader reader = new StreamReader(filePath);
            var document = WordprocessingDocument.Open(filePath, false);
            MainDocumentPart mainPart = document.MainDocumentPart;
            List<Paragraph> pars = mainPart.Document.Body.Elements<Paragraph>().ToList();
           // StreamWriter MyStreamWriter = new StreamWriter(@"C:\Users\mohammad\Desktop\"+Path.GetFileName(filePath)+".txt", true, Encoding.UTF8);
            string title = "";
            for (int i = 0; i < pars.Count; i++)
            {
             
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
                
                if(pars[i].InnerText.Length>3)
                if (!pars[i].InnerXml.Contains("center") && pars[i].InnerXml.Contains("w:color") && !pars[i].InnerXml.Contains("w:sz w:val=\"21\""))
                {
                    String text = pars[i].InnerText;
                    text = text.Replace('ك', 'ک').Replace('ي', 'ی');
                    text = text.Replace("ُ", "").Replace("ِ","").Replace("َ","").Replace("ّ","");
                    text = text.Replace("ْ","").Replace("ٌ","").Replace("ٍ","").Replace("ً","");
                    String[] words = text.Split(' ','.',':','؛',')','(','،','؟','!',']','[','}','{');
                    for(int g=0; g<words.Length - 2; g++)
                    {
                        if (!(words[g].Length < 2 || Stopwords.Contains(words[g])))
                        {
                            if(counter++ % 1000 == 0)
                                Console.Write(".");
                            try
                            {
                                wfDic[words[g] + " " + words[g+1] + " " + words[g+2]]++;
                            }
                            catch (KeyNotFoundException exc)
                            {
                                wfDic.Add(words[g] + " " + words[g + 1] + " " + words[g + 2], 1);
                            }
                        }
                    }
                }

            }
           return wfDic;
        }
        static void Main(string[] args)
        {
            String data_dir = @"..\..\..\..\Data\";
            string[] Stopwords = File.ReadAllLines(data_dir + "stopwords.txt", Encoding.UTF8);
            Dictionary<String, int> wfDic = new Dictionary<string, int>();
            //reading files
            DirectoryInfo dir = new DirectoryInfo(data_dir);
            Console.Write("reading");
            foreach (FileInfo file in dir.GetFiles())
            {
                
                if (file.Extension == ".docx")
                {
                    wfDic = wordFreqList(file.FullName, wfDic, Stopwords);
                }
            }

            Console.Write("\nwriting");
            var writer = new StreamWriter(data_dir + "wordList.txt", true);
            int counter = 0;
            
            foreach (KeyValuePair<string, int> w in wfDic.OrderByDescending(key=> key.Value))
            {
                if (w.Value > 10)
                {
                    writer.WriteLine(w.Key);
                    if (counter++ % 1000 == 0)
                        Console.Write(". ");
                }
            }
           

        }
    }
}
