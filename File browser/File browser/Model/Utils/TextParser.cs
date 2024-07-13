using System.Text.RegularExpressions;

namespace File_browser.Model.Utils
{
    public class TextParser
    {
        public static string DeletePunctionMarks(string word)
        {
            string pattern = @"[.,\/#!$%\^&\*;:{}=\`~()\[\]""\\]";

            string result = Regex.Replace(word, pattern, "");

            return result;
        }

        public static List<string> ParseTextToWords(string text)
        {
            List<string> result = new List<string>();

            Regex pattern = new Regex(@"(\b[-_'\w]+\b)");
            string withoutPunctionMarks;

            foreach (Match match in pattern.Matches(text))
            {
                withoutPunctionMarks = DeletePunctionMarks(match.Value.ToLower());
                result.Add(withoutPunctionMarks);
            }
            
            return result;
        }
    }
}
