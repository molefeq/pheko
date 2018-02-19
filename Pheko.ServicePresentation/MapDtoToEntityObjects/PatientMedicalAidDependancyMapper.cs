using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class PatientMedicalAidDependancyMapper
    {
        public PatientMedicalAidDependancyMapper() { }

        public PatientMedicalAidDependancyDto MapToPatientMedicalAidDependancyDto(PatientMedicalAidDependancy patientMedicalAidDependancy)
        {
            if (patientMedicalAidDependancy == null)
            {
                return null;
            }

            PatientMedicalAidDependancyDto patientMedicalAidDependancyDto = new PatientMedicalAidDependancyDto();

            patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId = patientMedicalAidDependancy.PatientMedicalAidDependanciesId;
            patientMedicalAidDependancyDto.PatientId = patientMedicalAidDependancy.PatientId;
            patientMedicalAidDependancyDto.FirstFullName = patientMedicalAidDependancy.FirstFullName;
            patientMedicalAidDependancyDto.LastName = patientMedicalAidDependancy.LastName;
            patientMedicalAidDependancyDto.MedicalAidCode = patientMedicalAidDependancy.MedicalAidCode;
            patientMedicalAidDependancyDto.BirthDate = patientMedicalAidDependancy.BirthDate;
            patientMedicalAidDependancyDto.Relationship = patientMedicalAidDependancy.Relationship;
            patientMedicalAidDependancyDto.PrincipalInd = patientMedicalAidDependancy.PrincipalInd;
            patientMedicalAidDependancyDto.Title = patientMedicalAidDependancy.Title;
            patientMedicalAidDependancyDto.CrudOperation = CrudOperations.Update;

            return patientMedicalAidDependancyDto;
        }

        public void MapToPatientMedicalAidDependancy(PatientMedicalAidDependancy patientMedicalAidDependancy, PatientMedicalAidDependancyDto patientMedicalAidDependancyDto)
        {
            if (patientMedicalAidDependancyDto == null)
            {
                return;
            }

            if (patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId != null)
            {
                patientMedicalAidDependancy.PatientMedicalAidDependanciesId = patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId.Value;
            }

            patientMedicalAidDependancy.PatientId = patientMedicalAidDependancyDto.PatientId;
            patientMedicalAidDependancy.FirstFullName = patientMedicalAidDependancyDto.FirstFullName;
            patientMedicalAidDependancy.LastName = patientMedicalAidDependancyDto.LastName;
            patientMedicalAidDependancy.MedicalAidCode = patientMedicalAidDependancyDto.MedicalAidCode;
            patientMedicalAidDependancy.BirthDate = patientMedicalAidDependancyDto.BirthDate;
            patientMedicalAidDependancy.Relationship = patientMedicalAidDependancyDto.Relationship;
            patientMedicalAidDependancy.PrincipalInd = patientMedicalAidDependancyDto.PrincipalInd;
            patientMedicalAidDependancy.Title = patientMedicalAidDependancyDto.Title;
        }
    }
}
