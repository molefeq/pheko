using System.Data;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface IDocumentScheduleManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        DataSet GetPatientSchedule(int patientId, int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        DataSet GetPatientSickNoteSchedule(int patientConsultationId, int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientConsultationId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        DataSet GetPatientScriptNoteSchedule(int patientConsultationId, int userId);
    }
}
