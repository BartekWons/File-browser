using System.Text.RegularExpressions;

namespace File_browser.Model
{
    public class KeyWordsValidation
    {
        public string Validate(string input)
        {
            if (input == null || input.Equals(String.Empty)) throw new FormatException("Text block is Empty!!!\nTo continue add some key words");

            input = input.ToLower();
            input = Regex.Replace(input, @"\t|\n|\r", " ");

            Regex pattern = new Regex(@"(\b\w+\b)");
            string result = String.Empty;
            foreach (Match match in pattern.Matches(input))
            {
                result += DeleteSingleCharacters(match.Value) + " ";
            }

            return result;
        }

        public string DeleteSingleCharacters(string word)
        {
            if (word == null) return "";
            else if (word.Length == 0 || word.Length == 1) return "";
            return word;
        }
    }
}
