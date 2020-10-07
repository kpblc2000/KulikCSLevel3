using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfMailSender.Services;

namespace MailSender.lib.Tests.Services
{
    /*
     [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
     */

    [TestClass]
    public class TextEncoderTests
    {

        [TestMethod]
        public void Encode_ABC_to_BCD_Key1()
        {
            const string baseString = "ABC";
            int key = 1;

            const string expectedString = "BCD";

            //

            string actualString = TextEncoder.Encoder(baseString, key);

            //

            Assert.AreEqual(expectedString, actualString);

        }
    }
}
