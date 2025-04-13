using EduOne.Security.Encryption;
using System;
using Xunit;

namespace EduOne.Security.Tests
{
    //[TestClass] [TestMethod]
    public class HexEncryptionTests
    {
       // readonly HexEncryptionHelper _helper= new HexEncryptionHelper();
        [Fact]
        public void MustReturnEncryptedValidValue()
        {
            // Arrange
            string actual= "aef8d34459e700141619ca9f31cc4214f014ec711";
            string password= "Abibou#123";
            string expected = HexEncryptionHelper.EncryptString(password);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void MustReturnEncryptedInvalidValue()
        {
            // Arrange
            string actual = "c19a93d56e96e7a32cb80c5a18fbbc2d80b529f67f";
            string password = "Abibou#123";
            string expected = HexEncryptionHelper.EncryptString(password);
            Assert.Equal(expected, actual);
        }
    }
}
