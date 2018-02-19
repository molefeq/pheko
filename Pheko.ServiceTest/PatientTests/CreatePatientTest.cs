using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;
using Pheko.ServicePresentation.ServiceResponses;
using Pheko.ServiceTest.PhekoService;

namespace Pheko.ServiceTest.PatientTest
{
    [TestClass]
    public class CreatePatientTest
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        [TestMethod]
        public void CreateNullPatient()
        {
            PatientDto newPatient = null;
            PatientDetailResponse response = _PhekoServiceClient.SavePatient(newPatient);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Patient);
        }

        [TestMethod]
        public void CreateEmptyPatient()
        {
            PatientDto newPatient = new PatientDto() { CrudOperation = CrudOperations.Create};
            PatientDetailResponse response = _PhekoServiceClient.SavePatient(newPatient);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 1);
            Assert.IsNull(response.Patient);
        }

        [TestMethod]
        public void CreateFirstNameOnlyPatient()
        {
            PatientDto newPatient = new PatientDto() { FirstName = "Qinisela", CrudOperation = CrudOperations.Create };
            PatientDetailResponse response = _PhekoServiceClient.SavePatient(newPatient);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Patient);
        }

        [TestMethod]
        public void CreateLastNameOnlyPatient()
        {
            PatientDto newPatient = new PatientDto() { LastName = "Molefe", CrudOperation = CrudOperations.Create };
            PatientDetailResponse response = _PhekoServiceClient.SavePatient(newPatient);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Patient);
        }

        [TestMethod]
        public void CreatePatient()
        {
            PatientDto newPatient = new PatientDto() { FirstName = "Qinisela", LastName = "Molefe", CrudOperation = CrudOperations.Create };
            PatientDetailResponse response = _PhekoServiceClient.SavePatient(newPatient);

            Assert.IsFalse(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count == 0);
            Assert.IsNotNull(response.Patient);
            Assert.IsNotNull(response.Patient.PatientId);
        }
    }
}
