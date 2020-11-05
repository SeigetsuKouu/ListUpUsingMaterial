using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListUpUsingMaterial.Classes;

namespace ListUpUsingMaterialTest
{
    [TestClass]
    public class AviUtlObjectReaderTest
    {
        [TestMethod]
        public void ReadTest() 
        {
            var readData = AviUtlObjectReader.ReadObjectFile("obj.exo");

            Assert.AreEqual(readData.Length, 19);
            Assert.AreEqual(readData[2].Name, "音声ファイル");
            Assert.AreEqual(readData[2].File.Path, "D:\\動画編集\\劇場\\009猫に構うONEちゃん\\音楽\\nc161187.mp3");
            Assert.AreEqual(readData[2].File.Name, "nc161187.mp3");
            Assert.AreEqual(readData[2].File.Extention, "mp3");
        }
    }
}
