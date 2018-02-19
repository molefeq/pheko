using Pheko.Common.DataTransformObjects;

using Pheko.ServicePresentation.ServiceResponses;

using System.Collections.Generic;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface IPatientMedicalNoteManager
    {
        Result<PatientMedicalNoteDto> GetPatientMedicalNotes(int patientConsultationId);
        Response<PatientMedicalNoteDto> SavePatientMedicalNotes(List<PatientMedicalNoteDto> patientMedicalNotes);
    }
}
