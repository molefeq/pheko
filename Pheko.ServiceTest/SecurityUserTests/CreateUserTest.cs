using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;
using Pheko.Common.UtilityComponent;

using Pheko.ServicePresentation.ServiceResponses;

using Pheko.ServiceTest.PhekoService;

namespace Pheko.ServiceTest.SecurityUserTests
{
    [TestClass]
    public class CreateUserTest
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        [TestMethod]
        public void NullCreateUserTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.SaveUser(null);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void EmptyCreateUserTest()
        {
            Response<SecurityUserDto> response = _PhekoServiceClient.SaveUser(new SecurityUserDto() { CrudOperation = CrudOperations.Create });

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void InvalidCreateUserTest()
        {
            SecurityUserDto securityUser = new SecurityUserDto()
            {
                Title = "Mr",
                IDNumber = "8707255584080",
                CrudOperation = CrudOperations.Create
            };

            Response<SecurityUserDto> response = _PhekoServiceClient.SaveUser(securityUser);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }


        [TestMethod]
        public void ValidCreateUserTest()
        {
            SecurityUserDto securityUser = new SecurityUserDto()
            {
                Title = "Mr",
                FirstName = "Qinisela",
                LastName = "Molefe",
                Initials = "Q E",
                UserName = GeneratePassword.CreateRandomPassword(),
                PasswordSalt = GeneratePassword.PasswordSalt(),
                IDNumber = "8707255584080",
                CrudOperation = CrudOperations.Create
            };

            securityUser.Password = GeneratePassword.HashedPassword("password1", securityUser.PasswordSalt);

            Response<SecurityUserDto> response = _PhekoServiceClient.SaveUser(securityUser);

            Assert.IsFalse(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count == 0);
            Assert.IsNotNull(response.Model);
        }
    }
}
