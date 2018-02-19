using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

using Pheko.ServiceTest.PhekoService;

namespace Pheko.ServiceTest.SecurityUserTests
{
    [TestClass]
    public class ResetPasswordTest
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        [TestMethod]
        public void NullResetPasswordTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.ResetPassword(null);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void EmptyResetPasswordTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.ResetPassword(string.Empty);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void InValidResetPasswordTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.ResetPassword("qiniselatest");

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void ValidResetPasswordTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.ResetPassword("U9g47ygk");

            Assert.IsFalse(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count == 0);
            Assert.IsNotNull(response.Model);
        }
    }
}
