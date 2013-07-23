using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net;
using Lucene.Net.Analysis.AR;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using System.IO;


namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            Lucene.Net.Store.Directory index_dir = FSDirectory.Open(@"..\..\..\..\Index");
            ArabicAnalyzerPlus analyzer = new ArabicAnalyzerPlus(Lucene.Net.Util.Version.LUCENE_CURRENT);
            IndexWriter writer = new IndexWriter(index_dir, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);

            //reading files
            String path = @"..\..\..\..\Data\";
            DirectoryInfo dir = new DirectoryInfo(path);
            int counter = 0;
            //StreamWriter testWriter = new StreamWriter(path + "testWriter.dat");
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Extension != ".txt")
                    continue;
                StreamReader reader = new StreamReader(file.FullName);
               
                Document doc;
                int c = 0;
                int parId = -1; //paragraph id
                String title = " ";
                while (!reader.EndOfStream)
                {
                    String type = "content";
                    doc = new Document();
                    String line = reader.ReadLine();
                    if (line.StartsWith("ParId"))
                    {
                        parId = Int32.Parse(line.Split(' ')[2]);
                        continue;
                    }
                    else if (line.StartsWith("titr"))
                    {
                        type = "title";
                        title = line.Substring(4);
                        line = title;
                    }
                    else
                        line = line.Substring(6);

                    Field fileName = new Field("filename", file.Name,Field.Store.YES, Field.Index.NO);
                    Field typefield = new Field("type", type, Field.Store.YES, Field.Index.NO);
                    Field text = new Field("text", line, Field.Store.YES, Field.Index.ANALYZED);
                    doc.Add(new Field("title", title, Field.Store.YES, Field.Index.NO));
                    doc.Add(fileName);
                    doc.Add(typefield);
                    doc.Add(text);
                    writer.AddDocument(doc);
                    if (++c % 1000 == 0)
                        Console.Write(". ");
                }

            }
            writer.Optimize();
            writer.Commit();
            writer.Dispose();

        }
    }
}
