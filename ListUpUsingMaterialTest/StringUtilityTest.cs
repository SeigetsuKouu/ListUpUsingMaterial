using ListUpUsingMaterial.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListUpUsingMaterialTest
{
    [TestClass]
    public class StringUtility
    {
        [TestMethod]
        public void SplitNewLineTest()
        {
            var testString = "aaa\rbbb\nccc\r\nddd";
            var splitedData = testString.SplitNewLine();

            Assert.AreEqual(splitedData.Length, 4);
            Assert.AreEqual(splitedData[0], "aaa");
            Assert.AreEqual(splitedData[1], "bbb");
            Assert.AreEqual(splitedData[2], "ccc");
            Assert.AreEqual(splitedData[3], "ddd");
        }

        [TestMethod]
        public void ForceConvertToDoubleTest() 
        {
            Assert.AreEqual("1".ForceConvertToDouble(), 1);
            Assert.AreEqual("1.5".ForceConvertToDouble(), 1.5);
            Assert.AreEqual("-1".ForceConvertToDouble(), -1);
            Assert.AreEqual("-1.5".ForceConvertToDouble(), -1.5);
            Assert.AreEqual("[1]".ForceConvertToDouble(), 1);
            Assert.AreEqual("[1.5]".ForceConvertToDouble(), 1.5);
            Assert.AreEqual("[-1]".ForceConvertToDouble(), -1);
            Assert.AreEqual("[-1.5]".ForceConvertToDouble(), -1.5);
        }
    }
}
