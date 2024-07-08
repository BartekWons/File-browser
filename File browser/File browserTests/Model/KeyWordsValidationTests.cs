using File_browser.Model;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace File_browser.Model.Tests
{
    [TestFixture()]
    public class KeyWordsValidationTests
    {
        KeyWordsValidation keyWordsValidation;

        [SetUp()]
        public void SetUp()
        {
            keyWordsValidation = new KeyWordsValidation();
        }

        [Test()]
        public void deleteSingleCharactersTest_NullInput_returnsEmptyString()
        {
            string input = null;
            string result = keyWordsValidation.DeleteSingleCharacters(input);
            Assert.AreEqual(result, "");
        }

        [Test()]
        public void deleteSingleCharactersTest_OneLetterInput_returnsEmptyString()
        {
            string input = "a";
            string result = keyWordsValidation.DeleteSingleCharacters(input);
            Assert.AreEqual(result, "");
        }

        [Test()]
        public void deleteSingleCharactersTest_EmptyStringInput_returnsEmptyString()
        {
            string input = "";
            string result = keyWordsValidation.DeleteSingleCharacters(input);
            Assert.AreEqual(result, "");
        }

        [Test()]
        public void deleteSingleCharactersTest_MoreThanOneLetterInput_returnsInput()
        {
            string input = "input";
            string result = keyWordsValidation.DeleteSingleCharacters(input);
            Assert.AreEqual(result, input);
        }

        [Test()]
        public void validateTest_ValidText_ResturnsInput()
        {
            string input = "hello darkness my old friend";
            string result = keyWordsValidation.Validate(input);

            string inputWithoutSpaces = input.Replace(" ", string.Empty);
            string resultWithoutSpaces = result.Replace(" ", string.Empty);

            Assert.AreEqual(resultWithoutSpaces, inputWithoutSpaces);
        }

        [Test()]
        public void validateTest_DeleteOneCharFromInput_ResturnsInputWithoutSingleCharacters()
        {
            string input = "hello darkness l l l l l  my l l l old friend";
            string result = keyWordsValidation.Validate(input);

            string expectedResult = "hello darkness my old friend";

            string inputWithoutSpaces = expectedResult.Replace(" ", string.Empty);
            string resultWithoutSpaces = result.Replace(" ", string.Empty);

            Assert.AreEqual(resultWithoutSpaces, inputWithoutSpaces);
        }

        [Test()]
        public void validateTest_DeleteOneCharFromInputWithCapitalLetter_ResturnsInputWithoutSingleCharactersAsLowerLetters()
        {
            string input = "Hello DarkNESs l H l l l  my l l l Old Friend";
            string result = keyWordsValidation.Validate(input);

            string expectedResult = "hello darkness my old friend";

            string inputWithoutSpaces = expectedResult.Replace(" ", string.Empty);
            string resultWithoutSpaces = result.Replace(" ", string.Empty);

            Assert.AreEqual(resultWithoutSpaces, inputWithoutSpaces);
        }

        [Test()]
        public void validateTest_nullText_ResturnsEmptyString()
        {
            string input = null;
            Assert.Throws<FormatException>(() => keyWordsValidation.Validate(input));
        }
    }
}