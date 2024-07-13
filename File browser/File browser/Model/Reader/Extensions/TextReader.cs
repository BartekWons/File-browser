using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace File_browser.Model.Reader.Extensions
{
    public class TextReader : FileReader
    {
        public override void Open()
        {
            Process.Start(new ProcessStartInfo(Path) { UseShellExecute = true });
        }

        public override string ReadData()
        {
            string textFromFile = File.ReadAllText(Path);

            textFromFile = Regex.Replace(textFromFile, @"\r|\n|\t", " ");

            return textFromFile;
        }
    }
}
