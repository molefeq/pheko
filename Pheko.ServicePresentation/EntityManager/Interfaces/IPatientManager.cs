using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface IPatientManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientDto"></param>
        /// <returns></returns>
        PatientDetailResponse SavePatient(PatientDto patientDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="securityUserId"></param>
        /// <returns></returns>
        PatientDetailResponse GetPatientDetails(int patientId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchPatient"></param>
        /// <returns></returns>
        Result<PatientDto> Search(PatientDto searchPatient);
    }
}
