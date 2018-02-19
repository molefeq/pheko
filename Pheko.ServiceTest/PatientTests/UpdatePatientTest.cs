using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;
using Pheko.ServicePresentation.ServiceResponses;
using Pheko.ServiceTest.PhekoService;
using System;

namespace Pheko.ServiceTest.PatientTests
{
    [TestClass]
    public class UpdatePatientTest
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        [TestMethod]
        public void SaveNullPatient()
        {
            PatientDto updatedPatient = null;
            PatientDetailResponse response = _PhekoServiceClient.SavePatient(updatedPatient);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Patient);
        }

        [TestMethod]
        public void SaveEmptyPatient()
        {
            PatientDto updatedPatient = new PatientDto() { CrudOperation = CrudOperations.Update };
            PatientDetailResponse response = _PhekoServiceClient.SavePatient(updatedPatient);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Patient);
        }

        [TestMethod]
        public void SaveNoneExistingPatient()
        {
            PatientDto updatedPatient = new PatientDto()
                {
                    PatientId = int.MinValue,
                    FirstName = "Qinisela Elvis",
                    LastName = "Molefe",
                    EmailAddress = "qin@gmail.com",
                    CrudOperation = CrudOperations.Update
                };

            PatientDetailResponse response = _PhekoServiceClient.SavePatient(updatedPatient);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Patient);
        }

        [TestMethod]
        public void SaveExistingPatientWithNoneExistingAddress()
        {
            PatientDto updatedPatient = new PatientDto()
            {
                PatientId = 24,
                FirstName = "Qinisela Elvis",
                LastName = "Molefe",
                EmailAddress = "qin@gmail.com",
                PostalAddress = new PatientAddressDto()
                {
                    PatientAddressId = int.MinValue,
                    CountryId = 1,
                    Line1 = "Postal Address Line 1",
                    Line2 = "Postal Address Line 2"
                },
                PhysicalAddress = new PatientAddressDto()
                {
                    PatientAddressId = int.MinValue,
                    CountryId = 1,
                    Line1 = "Physical Address Line 1",
                    Line2 = "Physical Address Line 2"
                },
                CrudOperation = CrudOperations.Update
            };

            PatientDetailResponse response = _PhekoServiceClient.SavePatient(updatedPatient);

            Assert.IsFalse(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count == 0);
            Assert.IsNotNull(response.Patient);
        }

        [TestMethod]
        public void SavePatient()
        {
            PatientDto updatedPatient = new PatientDto()
            {
                PatientId = 1,
                Title = "Mr",
                FirstName = "Qinisela Elvis",
                MiddleName = "Mr Que",
                LastName = "Molefe",
                BirthDate = new DateTime(1987, 7, 25),
                EthnicGroup = "Black",
                IDType = "RSA ID",
                IDNumber = "8707255584080",
                Gender = "Male",
                HomeTelephoneCode = "011",
                HomeTelephoneNumber = "4475206",
                MaritalStatus = "Single",
                WorkTelephoneCode = "011",
                WorkTelephoneNumber = "5368791",
                SourceOfDiscovery = "Internet",
                PrefferedContactMethod = "Mobile",
                PrefferedContactType = "Post",
                MobileNumber = "0846750093",
                PrincipalMemberInd = true,
                MedicalAidInd = true,
                MedicalAidNumber = "45635252352",
                MedicalAidName = "Discovery Medical Aid",
                MedicalAidScheme = "Classic Priority",
                MarriageType = "Married In Community Of Property",
                EmailAddress = "qin@gmail.com",
                PostalAddress = new PatientAddressDto()
                {
                    PatientAddressId = int.MinValue,
                    CountryId = 1,
                    ProvinceId = 1,
                    City = "Johannesburg",
                    PostalCode = "2001",
                    Suburb = "Braamfontein",
                    Line1 = "Postal Address Line 1",
                    Line2 = "Postal Address Line 2"
                },
                PhysicalAddress = new PatientAddressDto()
                {
                    PatientAddressId = int.MinValue,
                    CountryId = 1,
                    ProvinceId = 1,
                    City = "Sandton",
                    PostalCode = "2091",
                    Suburb = "Mandel Square",
                    Line1 = "Physical Address Line 1",
                    Line2 = "Physical Address Line 2"
                },
                CrudOperation = CrudOperations.Update
            };

            PatientDetailResponse response = _PhekoServiceClient.SavePatient(updatedPatient);

            Assert.IsFalse(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count == 0);
            Assert.IsNotNull(response.Patient);
        }
    }
}
