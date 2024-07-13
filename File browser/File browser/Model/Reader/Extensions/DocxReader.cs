using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Diagnostics;
using System.Text;

namespace File_browser.Model.Reader.Extensions
{
    public class DocxReader : FileReader
    {
        public override void Open()
        {
            Process.Start(new ProcessStartInfo(Path) { UseShellExecute = true });
        }

        public override string ReadData()
        {
            StringBuilder sb = new StringBuilder();

            using (WordprocessingDocument document = WordprocessingDocument.Open(Path, false))
            {
                MainDocumentPart mainPart = document.MainDocumentPart;
                Body body = mainPart.Document.Body;

                foreach (var paragraph in body)
                {
                    if (paragraph != null)
                    {
                        sb.Append(paragraph.InnerText);
                    }
                }
            }

            return sb.ToString();
        }
    }
}
