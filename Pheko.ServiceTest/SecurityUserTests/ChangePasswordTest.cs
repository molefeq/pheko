using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

using Pheko.ServiceTest.PhekoService;

namespace Pheko.ServiceTest.SecurityUserTests
{
    [TestClass]
    public class ChangePasswordTest
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        [TestMethod]
        public void NullChangePasswordTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.ChangePassword(null, null, null);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void EmptyChangePasswordTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.ChangePassword(string.Empty, string.Empty, string.Empty);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void InValidChangePasswordTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.ChangePassword("d@HbMRxN", "bhawu26", "password1");

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void ValidChangePasswordTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.ChangePassword("d@HbMRxN", "password1", "password1");

            Assert.IsFalse(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count == 0);
            Assert.IsNotNull(response.Model);
        }
    }
}
