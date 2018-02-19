using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

using Pheko.ServiceTest.PhekoService;

namespace Pheko.ServiceTest.PatientTests
{
    [TestClass]
    public class SearchPatientTest
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        [TestMethod]
        public void SearchNullPatient()
        {
            PatientDto searchPatient = null;
            Result<PatientDto> response = _PhekoServiceClient.Search(searchPatient);

            Assert.AreEqual(response.Models.Count, 0);
        }

        [TestMethod]
        public void SearchEmptyPatient()
        {
            PatientDto searchPatient = new PatientDto();
            Result<PatientDto> response = _PhekoServiceClient.Search(searchPatient);

            Assert.IsTrue(response.Models.Count > 0);
        }

        [TestMethod]
        public void SearchPatient()
        {
            PatientDto searchPatient = new PatientDto() { FirstName = "q" };
            Result<PatientDto> response = _PhekoServiceClient.Search(searchPatient);

            Assert.IsTrue(response.Models.Count > 0);
        }
    }
}
