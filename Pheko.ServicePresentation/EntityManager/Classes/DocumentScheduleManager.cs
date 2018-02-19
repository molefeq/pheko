using Pheko.DataAccess.Enums;
using Pheko.DataAccess.Repository;
using Pheko.DataAccess.Utility;

using Pheko.ServicePresentation.EntityManager.Interfaces;

using System;
using System.Collections.Generic;
using System.Data;

namespace Pheko.ServicePresentation.EntityManager.Classes
{
    public class DocumentScheduleManager : IDocumentScheduleManager
    {
        #region Interface Implementation Methods

        public DataSet GetPatientSchedule(int patientId, int userId)
        {
            DataSet dataSet = new DataSet();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                List<Parameter> parameters = new List<Parameter>();

                parameters.Add(new Parameter() { Name = "PatientId", ParameterType = ParameterType.INT, Value = patientId });
                parameters.Add(new Parameter() { Name = "UserId", ParameterType = ParameterType.INT, Value = userId });
                parameters.Add(new Parameter() { Name = "InfoMsg", ParameterType = ParameterType.GUID, Value = Guid.Empty });

                dataSet = unitOfWork.DataSetExecuteStoredProcedure("pat_PatientSchedule", parameters);
            }

            return dataSet;
        }

        public DataSet GetPatientSickNoteSchedule(int patientConsultationId, int userId)
        {
            DataSet dataSet = new DataSet();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                List<Parameter> parameters = new List<Parameter>();

                parameters.Add(new Parameter() { Name = "PatientConsultationId", ParameterType = ParameterType.INT, Value = patientConsultationId });
                parameters.Add(new Parameter() { Name = "UserId", ParameterType = ParameterType.INT, Value = userId });
                parameters.Add(new Parameter() { Name = "InfoMsg", ParameterType = ParameterType.GUID, Value = Guid.Empty });

                dataSet = unitOfWork.DataSetExecuteStoredProcedure("pat_PatientConsultationSickNoteSchedule", parameters);
            }

            return dataSet;
        }

        public DataSet GetPatientScriptNoteSchedule(int patientConsultationId, int userId)
        {
            DataSet dataSet = new DataSet();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                List<Parameter> parameters = new List<Parameter>();

                parameters.Add(new Parameter() { Name = "PatientConsultationId", ParameterType = ParameterType.INT, Value = patientConsultationId });
                parameters.Add(new Parameter() { Name = "UserId", ParameterType = ParameterType.INT, Value = userId });
                parameters.Add(new Parameter() { Name = "InfoMsg", ParameterType = ParameterType.GUID, Value = Guid.Empty });

                dataSet = unitOfWork.DataSetExecuteStoredProcedure("pat_PatientScriptSchedule", parameters);
            }

            return dataSet;
        }

        #endregion
    }
}
