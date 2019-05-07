using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace ReadPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //var pdfReader = new PdfReader(@"f:\sample.pdf"); 
            //byte[] pageContent = pdfReader.GetPageContent(1);
            //byte[] utf8 = Encoding.Convert(Encoding.Default, Encoding.UTF8, pageContent);
            //string textFromPage = Encoding.UTF8.GetString(utf8);

            using (PdfReader reader = new PdfReader(@"f:\MyBill.pdf"))
            {
                StringBuilder text = new StringBuilder();
                text.Append(PdfTextExtractor.GetTextFromPage(reader, 1));
                var textFromPage =  text.ToString();

                var dueDateMatch = Regex.Match(textFromPage, @"Due Date \d{4}/\d{2}/\d{2}");

                 Console.WriteLine("Your bill is due on the " + dueDateMatch.Value.Replace("Due Date ",""));
            }
            
            Console.ReadLine();
        }
       
    }
}
