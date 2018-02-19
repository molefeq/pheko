using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

using Pheko.ServiceTest.PhekoService;

namespace Pheko.ServiceTest.SecurityUserTests
{
    [TestClass]
    public class LoginTest
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        [TestMethod]
        public void NullLoginTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.Login(null, null);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void EmptyLoginTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.Login(string.Empty, string.Empty);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void InValidLoginTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.Login("qinisela", "molefe");

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void ValidLoginTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.Login("d@HbMRxN", "password1");

            Assert.IsFalse(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count == 0);
            Assert.IsNotNull(response.Model);
        }
    }
}
