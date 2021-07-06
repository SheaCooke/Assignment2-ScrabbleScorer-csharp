using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment2_ScrabbleScorer_csharp;

namespace TestScrabble
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimpleScorerReturnsValueBasedOnWordLength()
        {
            Assert.AreEqual(Program.SimpleScorer("test"),4);
        }

        [TestMethod]
        public void BonusVowlesReturnsExtraForVowles()
        {
            Assert.AreEqual(Program.BonusVowels("test"), 6);
        }

        [TestMethod]
        public void ScrabbleScorerIsBasedOnDictValues()
        {
            Assert.AreEqual(Program.ScrabbleScorer("testword"),12);
        }
    }
}
