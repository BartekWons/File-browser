using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text;

namespace File_browser.Model.Reader
{
    public class DocxReader : FileReader
    {
        public override string ReadData()
        {
            StringBuilder sb = new StringBuilder(); 
            using (WordprocessingDocument document = WordprocessingDocument.Open(Path, false))
            {
                MainDocumentPart mainPart = document.MainDocumentPart;
                Body body = mainPart.Document.Body;

                string text;
                foreach (var paragraph in body)
                {
                    if (paragraph != null)
                    {
                        text = paragraph.InnerText;
                        sb.Append(text);
                    }
                }
            }
            return sb.ToString();
        }
    }
}
