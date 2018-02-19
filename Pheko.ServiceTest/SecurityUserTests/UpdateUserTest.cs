using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pheko.ServiceTest.PhekoService;

using Pheko.ServicePresentation.ServiceResponses;

using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;

namespace Pheko.ServiceTest.SecurityUserTests
{
    [TestClass]
    public class UpdateUserTest
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        [TestMethod]
        public void UpdateNullPatient()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.SaveUser(null);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void UpdateEmptyUser()
        {
            SecurityUserDto securityUserDto = new SecurityUserDto() { CrudOperation = CrudOperations.Update };
            Response<SecurityUserDto> response = _PhekoServiceClient.SaveUser(securityUserDto);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void UpdateIdMinUser()
        {
            SecurityUserDto securityUserDto = new SecurityUserDto()
            {
                SecurityUserId = int.MinValue,
                Title = "Mr",
                IDNumber = "8707255584080",
                CrudOperation = CrudOperations.Update
            };

            Response<SecurityUserDto> response = _PhekoServiceClient.SaveUser(securityUserDto);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void UpdateNonExistingUser()
        {
            SecurityUserDto securityUserDto = new SecurityUserDto()
            {
                SecurityUserId = -4,
                Title = "Mr",
                IDNumber = "8707255584080",
                CrudOperation = CrudOperations.Update
            };

            Response<SecurityUserDto> response = _PhekoServiceClient.SaveUser(securityUserDto);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void UpdateInvalidUserTest()
        {
            SecurityUserDto securityUser = new SecurityUserDto()
            {
                SecurityUserId = 1,
                Title = "Mr",
                IDNumber = "8707255584080",
                CrudOperation = CrudOperations.Update
            };

            Response<SecurityUserDto> response = _PhekoServiceClient.SaveUser(securityUser);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void UpdateExistingUser()
        {
            SecurityUserDto securityUser = new SecurityUserDto()
            {
                SecurityUserId = 6,
                Title = "Mr",
                FirstName = "Qinisela Elvis",
                LastName = "Molefe",
                Initials = "Q E",
                IDNumber = "8707255584080",
                UserName = "molefeq",
                Gender = "Male",
                WorkTelephoneCode = "011",
                WorkTelephoneNumber = "4470987",
                CrudOperation = CrudOperations.Update
            };

            Response<SecurityUserDto> response = _PhekoServiceClient.SaveUser(securityUser);

            Assert.IsFalse(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count == 0);
            Assert.IsNotNull(response.Model);
        }

    }
}
