using System.Data;

namespace Pheko.WebPresentation.ServiceHandlers.Interfaces
{
    public interface IDocumentScheduleHandler
    {
        DataSet GetPatientSchedule(int patientId, int userId);

        DataSet GetPatientSickNoteSchedule(int patientConsultationId, int userId);

        DataSet GetPatientScriptNoteSchedule(int patientConsultationId, int userId);
    }
}
