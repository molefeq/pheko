using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface IPatientMedicalAidDependancyManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientMedicalAidDependancyDto"></param>
        /// <returns></returns>
        Response<PatientMedicalAidDependancyDto> SavePatientMedicalAidDependancy(PatientMedicalAidDependancyDto patientMedicalAidDependancyDto);
    }
}
