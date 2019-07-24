using System;
using System.Text;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Tesseract;

namespace ReadPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadImageText();

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

        static void ReadImageText()
        {
            //https://github.com/A9T9/Free-Ocr-Windows-Desktop
            //https://github.com/A9T9/Free-OCR-Software

            var path = "med.jpg";
            using (var engine = new TesseractEngine(".\\tessdata", "eng", EngineMode.TesseractAndCube))
            {
                using (var img = Pix.LoadFromFile(path))
                {
                    using (var page = engine.Process(img))
                    {
                        var text = page.GetText();
                        // text variable contains a string with all words found
                    }
                }
            }
        }
    }
}
