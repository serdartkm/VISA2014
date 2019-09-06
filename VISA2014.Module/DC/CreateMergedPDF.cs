using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Spire.Pdf;


namespace VISA2014.Module.DC
{
    class CreateMergedPDF
    {

        public static void MergePDF(string targetPDF,string sourceDir) {


            var files = Directory.GetFiles(sourceDir);

            PdfDocument[] docs = new PdfDocument[files.Length];

                    
             
                Console.WriteLine("Merging files count: " + files.Length);
         
                for (int i = 0; i < files.Length; i++)

                {
                    docs[i] = new PdfDocument(files[i]);
                    docs[0].AppendPage(docs[i]);
                    
                }
               
                 docs[0].SaveToFile(@"d:\MergeDocuments.pdf");

             

                Console.WriteLine("SpeedPASS PDF merge complete.");
            
        }
        
    }
}
