using Pheko.WebPresentation.PhekoService;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;

using System.Data;

namespace Pheko.WebPresentation.ServiceHandlers.Classes
{
    public class DocumentScheduleHandler : IDocumentScheduleHandler
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        public DataSet GetPatientSchedule(int patientId, int userId)
        {
            return _PhekoServiceClient.GetPatientSchedule(patientId, userId);
        }

        public DataSet GetPatientSickNoteSchedule(int patientConsultationId, int userId)
        {
            return _PhekoServiceClient.GetPatientSickNoteSchedule(patientConsultationId, userId);
        }

        public DataSet GetPatientScriptNoteSchedule(int patientConsultationId, int userId)
        {
            return _PhekoServiceClient.GetPatientScriptNoteSchedule(patientConsultationId, userId);
        }
    }
}
