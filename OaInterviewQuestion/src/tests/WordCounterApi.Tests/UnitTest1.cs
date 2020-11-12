using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounterApi;

namespace WordCounterApi.Tests
{
    [TestClass]
    public class FileWordTests
    {
        [TestMethod]
        [DeploymentItem(@"TestFiles\Foo.txt", @".\TestFiles\")]
        public void TestCountWordsInFile()
        {
            var api = new Counter();
            var result = api.CountWords(@".\TestFiles\Foo.txt");
            Assert.IsTrue(result == 15, "Word count in file matches");
        }
    }
}
