using File_browser.Model.Utils;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace File_browser.Model.Utils.Tests
{
    [TestFixture()]
    public class TextParserTests
    {
        [Test()]
        public void DeletePunctionMarksTest_DeleteComma_ReturnsStringWithoutComma()
        {
            string input = "And if you ask me to, Daddy's gonna buy, you a mockin,gbird";
            string result = TextParser.DeletePunctionMarks(input);
            string expectedResult = "And if you ask me to Daddy's gonna buy you a mockingbird";
            Assert.AreEqual(expectedResult, result);
        }

        [Test()]
        public void DeletePunctionMarksTest_DeleteSemicolon_ReturnsStringWithoutSemicolon()
        {
            string input = "I'ma give; you the world;";
            string result = TextParser.DeletePunctionMarks(input);
            string expectedResult = "I'ma give you the world";
            Assert.AreEqual(expectedResult, result);
        }

        [Test()]
        public void DeletePunctionMarksTest_DeleteDot_ReturnsStringWithoutDot()
        {
            string input = "I'ma give. you the w.orld.";
            string result = TextParser.DeletePunctionMarks(input);
            string expectedResult = "I'ma give you the world";
            Assert.AreEqual(expectedResult, result);
        }

        [Test()]
        public void DeletePunctionMarksTest_DeleteCurlyBrackets_ReturnsStringWithoutCurlyBrackets()
        {
            string input = "I'ma buy a diamond ring {for yo}u {I'ma} sing for you";
            string result = TextParser.DeletePunctionMarks(input);
            string expectedResult = "I'ma buy a diamond ring for you I'ma sing for you";
            Assert.AreEqual(expectedResult, result);
        }

        [Test()]
        public void DeletePunctionMarksTest_DeleteSquaredBrackets_ReturnsStringWithoutSquaredBrackets()
        {
            string input = "I'll do anything for you to see you smile";
            string result = TextParser.DeletePunctionMarks(input);
            string expectedResult = "I'll do anything for you to see you smile";
            Assert.AreEqual(expectedResult, result);
        }

        [Test()]
        public void DeletePunctionMarksTest_DeleteBrakcets_ReturnsStringWithoutBrackets()
        {
            string input = "And if that mockingbird don't sing and that ring don't shine";
            string result = TextParser.DeletePunctionMarks(input);
            string expectedResult = "And if that mockingbird don't sing and that ring don't shine";
            Assert.AreEqual(expectedResult, result);
        }

        [Test()]
        public void DeletePunctionMarksTest_DeleteSpecialMarks_ReturnsStringWithoutSpecialMarks()
        {
            string input = "I'ma bre*ak t*ha&t bi^rd$ie's ne%ck";
            string result = TextParser.DeletePunctionMarks(input);
            string expectedResult = "I'ma break that birdie's neck";
            Assert.AreEqual(expectedResult, result);
        }

        [Test()]
        public void DeletePunctionMarksTest_DeleteTilde_ReturnsStringWithoutTilde()
        {
            string input = "I'll go ba~~ck to the jeweler who sol~~d it to~~ ya~~~~~~";
            string result = TextParser.DeletePunctionMarks(input);
            string expectedResult = "I'll go back to the jeweler who sold it to ya";
            Assert.AreEqual(expectedResult, result);
        }

        [Test()]
        public void DeletePunctionMarksTest_DeleteMultiiplePunctionMarks_ReturnsRawString()
        {
            string input = "And make him eat every carat, don't with Dad! (Ha-ha!)";
            string result = TextParser.DeletePunctionMarks(input);
            string expectedResult = "And make him eat every carat don't with Dad Ha-ha";
            Assert.AreEqual(expectedResult, result);
        }

        [Test()]
        public void ParseTextToWordsTest_SplitSentenceToWords_ResturnsSplitedText1()
        {
            string input = "He's nervous, but on the surface he looks calm and ready";
            List<string> result = TextParser.ParseTextToWords(input);
            List<string> expectedResult = new List<string>()
            {
                "he's",
                "nervous",
                "but",
                "on",
                "the",
                "surface",
                "he",
                "looks",
                "calm",
                "and",
                "ready"
            };
            Assert.AreEqual(expectedResult, result);
        }

        [Test()]
        public void ParseTextToWordsTest_SplitSentenceToWords_ResturnsSplitedText2()
        {
            string input = "To drop bombs, but he keeps on forgetting";
            List<string> result = TextParser.ParseTextToWords(input);
            List<string> expectedResult = new List<string>()
            {
                "to",
                "drop",
                "bombs",
                "but",
                "he",
                "keeps",
                "on",
                "forgetting"
            };
            Assert.AreEqual(expectedResult, result);
        }

        [Test()]
        public void ParseTextToWordsTest_SplitSentenceToWords_ResturnsSplitedText3()
        {
            string input = "What he wrote down, the whole crowd goes so loud";
            List<string> result = TextParser.ParseTextToWords(input);
            List<string> expectedResult = new List<string>()
            {
                "what",
                "he",
                "wrote",
                "down",
                "the",
                "whole",
                "crowd",
                "goes",
                "so",
                "loud"
            };
            Assert.AreEqual(expectedResult, result);
        }

        [Test()]
        public void ParseTextToWordsTest_SplitSentenceToWords_ResturnsSplitedText4()
        {
            string input = "He opens his mouth, but the words won't come out";
            List<string> result = TextParser.ParseTextToWords(input);
            List<string> expectedResult = new List<string>()
            {
                "he",
                "opens",
                "his",
                "mouth",
                "but",
                "the",
                "words",
                "won't",
                "come",
                "out"
            };
            Assert.AreEqual(expectedResult, result);
        }


        [Test()]
        public void ParseTextToWordsTest_SplitSentenceToWords_ResturnsSplitedText5()
        {
            string input = "He's choking, how? Everybody's joking now";
            List<string> result = TextParser.ParseTextToWords(input);
            List<string> expectedResult = new List<string>()
            {
                "he's",
                "choking",
                "how",
                "everybody's",
                "joking",
                "now"
            };
            Assert.AreEqual(expectedResult, result);
        }
    }
}