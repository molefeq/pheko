using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;

using Pheko.ServicePresentation.ServiceResponses;

using Pheko.ServiceTest.PhekoService;

using System;

namespace Pheko.ServiceTest.PatientMedicalAidDependancyTests
{
    [TestClass]
    public class DeletePatientMedicalAidDependancyTest
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        [TestMethod]
        public void DeleteNullPatientMedicalAidDependancy()
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
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto() { CrudOperation = CrudOperations.Delete };
            Response<PatientMedicalAidDependancyDto> response = _PhekoServiceClient.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }
        
        [TestMethod]
        public void DeleteNonExistingPatientMedicalAidDependancy()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto()
            {
                PatientId = 1,
                PatientMedicalAidDependanciesId = -5,
                CrudOperation = CrudOperations.Delete,
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
        public void DeleteValidPatientPatientMedicalAidDependancy()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto()
            {
                PatientMedicalAidDependanciesId = 15,
                CrudOperation = CrudOperations.Delete,
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
            Assert.IsNull(response.Model);
        }
        
    }
}
