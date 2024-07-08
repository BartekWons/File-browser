using System.IO;
using System.Text.RegularExpressions;

namespace File_browser.Model.Reader
{
    public class TextReader : FileReader
    {
        public TextReader()
        {
            MatchingWords = 0;
        }

        public override string ReadData()
        {
            string textFromFile = File.ReadAllText(Path);
            textFromFile = Regex.Replace(textFromFile, @"\r|\n|\t", " ");
            return textFromFile;
        }
    }
}
