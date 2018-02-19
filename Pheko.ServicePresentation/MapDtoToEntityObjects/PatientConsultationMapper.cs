using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class PatientConsultationMapper
    {
        public PatientConsultationMapper() { }

        public PatientConsultationDto MapToPatientConsultationDto(PatientConsultation patientConsultation)
        {
            if (patientConsultation == null)
            {
                return null;
            }

            PatientConsultationDto patientConsultationDto = new PatientConsultationDto();

            patientConsultationDto.PatientConsultationId = patientConsultation.PatientConsultationId;
            patientConsultationDto.DoctorId = patientConsultation.DoctorId;
            patientConsultationDto.PatientId = patientConsultation.PatientId;
            patientConsultationDto.ConsultationStatus = patientConsultation.ConsultationStatus;
            patientConsultationDto.StartDate = patientConsultation.StartDate;
            patientConsultationDto.EndDate = patientConsultation.EndDate;

            return patientConsultationDto;
        }

        public void MapToPatientConsultation(PatientConsultation patientConsultation, PatientConsultationDto patientConsultationDto)
        {
            if (patientConsultationDto == null)
            {
                return;
            }

            patientConsultation = patientConsultation ?? new PatientConsultation();

            patientConsultation.DoctorId = patientConsultationDto.DoctorId;
            patientConsultation.PatientId = patientConsultationDto.PatientId;
            patientConsultation.ConsultationStatus = patientConsultationDto.ConsultationStatus;
            patientConsultation.StartDate = patientConsultationDto.StartDate.Value;
            patientConsultation.EndDate = patientConsultationDto.EndDate.Value;
        }
    }
}
