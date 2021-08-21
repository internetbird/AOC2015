using AOC2015.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AOC2015.Tests
{
    [TestClass]
    public class CodeGridGeneratorTests
    {
        [TestMethod]
        public void TestCodeAtRow1Column3()
        {
            var codeGridGenerator = new CodeGridGenerator();

            ulong code = codeGridGenerator.GetCodeAtPosition(1, 3);

            Assert.AreEqual((ulong)17289845, code);
        }

        [TestMethod]
        public void TestCodeAtRow6Column6()
        {
            var codeGridGenerator = new CodeGridGenerator();

            ulong code = codeGridGenerator.GetCodeAtPosition(6, 6);

            Assert.AreEqual((ulong)27995004, code);
        }
    }
}
