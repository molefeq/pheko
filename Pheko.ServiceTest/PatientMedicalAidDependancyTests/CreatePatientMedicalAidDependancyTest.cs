using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;

using Pheko.ServicePresentation.ServiceResponses;

using Pheko.ServiceTest.PhekoService;

using System;

namespace Pheko.ServiceTest.PatientMedicalAidDependancyTests
{
    [TestClass]
    public class CreatePatientMedicalAidDependancyTest
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        [TestMethod]
        public void CreateNullPatientMedicalAidDependancy()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = null;
            Response<PatientMedicalAidDependancyDto> response = _PhekoServiceClient.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void CreateEmptyPatientMedicalAidDependancy()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto() { CrudOperation = CrudOperations.Create };
            Response<PatientMedicalAidDependancyDto> response = _PhekoServiceClient.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void CreateInvalidPatientMedicalAidDependancy()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto()
            {
                PatientId = 1,
                FirstFullName = "Makhosazana",
                CrudOperation = CrudOperations.Create
            };

            Response<PatientMedicalAidDependancyDto> response = _PhekoServiceClient.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Model);
        }

        [TestMethod]
        public void CreateValidPatientPatientMedicalAidDependancy()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto()
            {
                CrudOperation = CrudOperations.Create,
                PrincipalInd = false,
                PatientId = 1,
                FirstFullName = "Makhosazana",
                LastName = "Molefe",
                BirthDate = new DateTime(1988, 4, 21),
                MedicalAidCode = "123543968",
                Relationship = "Brother",
                Title = "Mr"
            };

            Response<PatientMedicalAidDependancyDto> response = _PhekoServiceClient.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);

            Assert.IsFalse(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count == 0);
            Assert.IsNotNull(response.Model);
        }

        [TestMethod]
        public void CreateValidPatientPatientMedicalAidDependancyAsPrincipalMember()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto()
            {
                CrudOperation = CrudOperations.Create,
                PrincipalInd = true,
                PatientId = 2,
                FirstFullName = "Siyabonga",
                LastName = "Molefe",
                BirthDate = new DateTime(1988, 4, 21),
                MedicalAidCode = "123543968",
                Relationship = "Brother",
                Title = "Mr"
            };

            Response<PatientMedicalAidDependancyDto> response = _PhekoServiceClient.SavePatientMedicalAidDependancy(patientMedicalAidDependancyDto);

            Assert.IsFalse(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count == 0);
            Assert.IsNotNull(response.Model);
        }

        [TestMethod]
        public void CreateWithExistingPrincipal()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto()
            {
                CrudOperation = CrudOperations.Create,
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
        
        [TestMethod]
        public void CreateValidPatientPatientMedicalAidDependancyWithExistingPrincipalMember()
        {
            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto()
            {
                CrudOperation = CrudOperations.Create,
                PrincipalInd = false,
                PatientId = 2,
                FirstFullName = "Test",
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
    }
}
