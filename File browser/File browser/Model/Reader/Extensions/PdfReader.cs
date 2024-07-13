using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace File_browser.Model.Reader.Extensions
{
    public class PdfReader : FileReader
    {
        public override void Open()
        {
            Process.Start(new ProcessStartInfo(Path) { UseShellExecute = true });
        }

        public override string ReadData()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (PdfDocument document = new PdfDocument(new iText.Kernel.Pdf.PdfReader(Path)))
                {
                    for (var page = 1; page <= document.GetNumberOfPages(); page++)
                    {
                        sb.Append(PdfTextExtractor.GetTextFromPage(document.GetPage(page)));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "";
            }

            if (sb.Length == 0 || sb == null) return "";

            return Regex.Replace(sb.ToString(), @"\n|\r|\t", " ");
        }
    }
}
