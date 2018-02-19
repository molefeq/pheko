using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;

using Pheko.ServicePresentation.ServiceResponses;

using Pheko.ServiceTest.PhekoService;

using System;

namespace Pheko.ServiceTest.PatientMedicalAidDependancyTests
{
    [TestClass]
    public class UpdatePatientMedicalAidDependancyTest
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        [TestMethod]
        public void UpdateNullPatientMedicalAidDependancy()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = null;
            Response<PatientMedicalAidDependancyDto> response = _PhekoServiceClient.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void UpdateEmptyPatientMedicalAidDependancy()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto() { CrudOperation = CrudOperations.Update };
            Response<PatientMedicalAidDependancyDto> response = _PhekoServiceClient.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void UpdateInvalidPatientMedicalAidDependancy()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto()
            {
                PatientId = 1,
                PatientMedicalAidDependanciesId = 10,
                FirstFullName = "Makhosazana",
                CrudOperation = CrudOperations.Update
            };

            Response<PatientMedicalAidDependancyDto> response = _PhekoServiceClient.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void UpdateNonExistingPatientMedicalAidDependancy()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto()
            {
                PatientId = 1,
                PatientMedicalAidDependanciesId = -5,
                CrudOperation = CrudOperations.Update,
                FirstFullName = "Makhosazana",
                LastName = "Molefe",
                BirthDate = new DateTime(1988, 4, 21),
                MedicalAidCode = "123543968",
                Relationship = "Brother",
                Title = "Mr"
            };

            Response<PatientMedicalAidDependancyDto> response = _PhekoServiceClient.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void UpdateValidPatientPatientMedicalAidDependancy()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto()
            {
                PatientMedicalAidDependanciesId = 13,
                CrudOperation = CrudOperations.Update,
                PrincipalInd = false,
                PatientId = 1,
                FirstFullName = "TestUpdateFirstName",
                LastName = "UpdateLastName",
                BirthDate = new DateTime(1986, 6, 20),
                MedicalAidCode = "123543968",
                Relationship = "Sister",
                Title = "Miss"
            };

            Response<PatientMedicalAidDependancyDto> response = _PhekoServiceClient.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);

            Assert.IsFalse(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count == 0);
            Assert.IsNotNull(response.Model);
        }

        [TestMethod]
        public void UpdateWithExistingPatientMedicalDependancyMemberPrincipal()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto()
            {
                PatientMedicalAidDependanciesId = 19,
                CrudOperation = CrudOperations.Update,
                PrincipalInd = true,
                PatientId = 2,
                FirstFullName = "Existing FirstName",
                LastName = "Molefe",
                BirthDate = new DateTime(1981, 6, 27),
                MedicalAidCode = "567343968",
                Relationship = "Mother",
                Title = "Miss"
            };

            Response<PatientMedicalAidDependancyDto> response = _PhekoServiceClient.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void UpdateWithExistingPatientMemberPrincipal()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto()
            {
                PatientMedicalAidDependanciesId = 14,
                CrudOperation = CrudOperations.Update,
                PrincipalInd = true,
                PatientId = 1,
                FirstFullName = "Existing FirstName",
                LastName = "Molefe",
                BirthDate = new DateTime(1981, 6, 27),
                MedicalAidCode = "567343968",
                Relationship = "Mother",
                Title = "Miss"
            };

            Response<PatientMedicalAidDependancyDto> response = _PhekoServiceClient.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }
    }
}
