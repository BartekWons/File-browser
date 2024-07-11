using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace File_browser.Model.Reader.Extensions
{
    public class TextReader : FileReader
    {
        public TextReader()
        {
            MatchingWords = 0;
        }

        public override void Open()
        {
            Process.Start(new ProcessStartInfo("notepad.exe", Path));
        }

        public override string ReadData()
        {
            string textFromFile = File.ReadAllText(Path);
            textFromFile = Regex.Replace(textFromFile, @"\r|\n|\t", " ");
            return textFromFile;
        }
    }
}
