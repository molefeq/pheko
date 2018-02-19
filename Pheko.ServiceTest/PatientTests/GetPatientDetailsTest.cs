using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pheko.ServicePresentation.ServiceResponses;

using Pheko.ServiceTest.PhekoService;

namespace Pheko.ServiceTest.PatientTests
{
    [TestClass]
    public class GetPatientDetailsTest
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        [TestMethod]
        public void GetNoneExistingPatient()
        {
            PatientDetailResponse response = _PhekoServiceClient.GetPatientDetails(int.MinValue);

            Assert.IsTrue(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count > 0);
            Assert.IsNull(response.Patient);
        }

        [TestMethod]
        public void GetExistingPatient()
        {
            PatientDetailResponse response = _PhekoServiceClient.GetPatientDetails(1);

            Assert.IsFalse(response.HasErrors);
            Assert.IsTrue(response.FieldErrors.Count == 0);
            Assert.IsNotNull(response.Patient);
        }
    }
}
