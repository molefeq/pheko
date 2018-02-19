using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;

using System.Collections.Generic;

namespace Pheko.ServicePresentation.ServiceResponses
{
    public class PatientDetailResponse
    {
        public PatientDto Patient { get; set; }
        public List<PatientMedicalAidDependancyDto> PatientMedicalAidDependancies { get; set; }

        public List<FieldError> FieldErrors { get; set; }
        public bool HasErrors { get; set; }

        public PatientDetailResponse()
        {
            PatientMedicalAidDependancies = new List<PatientMedicalAidDependancyDto>();
            FieldErrors = new List<FieldError>();
        }
    }
}
