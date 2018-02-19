using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;
using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.BusinessRules;
using Pheko.ServicePresentation.EntityManager.Interfaces;
using Pheko.ServicePresentation.MapDtoToEntityObjects;
using Pheko.ServicePresentation.ServiceResponses;

using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Pheko.ServicePresentation.EntityManager.Classes
{
    public class PatientMedicalMonitoringManager : IPatientMedicalMonitoringManager
    {
        private PatientMedicalMonitoringBusinessRules _PatientMedicalMonitoringBusinessRules = new PatientMedicalMonitoringBusinessRules();
        private PatientMedicalMonitoringMapper _PatientMedicalMonitoringMapper = new PatientMedicalMonitoringMapper();
        private MedicalMonitoringMapper _MedicalMonitoringMapper = new MedicalMonitoringMapper();

        public Result<PatientMedicalMonitoringDto> GetPatientMedicalMonitorings(int patientConsultationId)
        {
            Result<PatientMedicalMonitoringDto> response = new Result<PatientMedicalMonitoringDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                IEnumerable<MedicalMonitoring> MedicalMonitorings = unitOfWork.MedicalMonitoringRepository.GetEntities();
                IEnumerable<PatientMedicalMonitoring> patientMedicalMonitorings = unitOfWork.PatientMedicalMonitoringRepository.GetEntities(item => item.PatientConsultationId == patientConsultationId, p => p.OrderBy(o => o.MedicalMonitoring.SortKey));

                foreach (MedicalMonitoring MedicalMonitoring in MedicalMonitorings)
                {
                    MedicalMonitoringDto MedicalMonitoringDto = _MedicalMonitoringMapper.MapToMedicalMonitoringDto(MedicalMonitoring);
                    PatientMedicalMonitoring patientMedicalMonitoring = patientMedicalMonitorings.Where(item => item.MedicalMonitoringId == MedicalMonitoring.MedicalMonitoringId).FirstOrDefault();

                    PatientMedicalMonitoringDto patientMedicalMonitoringDto = new PatientMedicalMonitoringDto()
                    {
                        PatientMedicalMonitoringId = patientMedicalMonitoring == null ? default(int?) : patientMedicalMonitoring.PatientMedicalMonitoringId,
                        PatientConsultationId = patientConsultationId,
                        MedicalMonitoring = MedicalMonitoringDto,
                        Value = patientMedicalMonitoring == null ? null : patientMedicalMonitoring.Value
                    };

                    response.Models.Add(patientMedicalMonitoringDto);
                }
            }

            return response;
        }

        public Response<PatientMedicalMonitoringDto> SavePatientMedicalMonitorings(List<PatientMedicalMonitoringDto> patientMedicalMonitorings)
        {
            Response<PatientMedicalMonitoringDto> response = new Response<PatientMedicalMonitoringDto>();

            foreach (PatientMedicalMonitoringDto patientMedicalMonitoringDto in patientMedicalMonitorings)
            {
                response = _PatientMedicalMonitoringBusinessRules.SaveCheck(patientMedicalMonitoringDto);
                if (response.HasErrors) return response;
            }

            using (TransactionScope scope = new TransactionScope())
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.AutoDetectChanges = false;
                    unitOfWork.ValidateOnSave = false;

                    try
                    {
                        foreach (PatientMedicalMonitoringDto patientMedicalMonitoringDto in patientMedicalMonitorings)
                        {
                            bool isNewPatientMedicalMonitoring = false;
                            PatientMedicalMonitoring patientMedicalMonitoring = unitOfWork.PatientMedicalMonitoringRepository.GetByID(item => item.PatientConsultationId == patientMedicalMonitoringDto.PatientConsultationId &&
                                                                                                                                              item.MedicalMonitoringId == patientMedicalMonitoringDto.MedicalMonitoring.MedicalMonitoringId.Value);
                            
                            if (patientMedicalMonitoring != null && string.IsNullOrEmpty(patientMedicalMonitoringDto.Value))
                            {
                                unitOfWork.PatientMedicalMonitoringRepository.Delete(patientMedicalMonitoring);
                                continue;
                            }

                            if (string.IsNullOrEmpty(patientMedicalMonitoringDto.Value))
                            {
                                continue;
                            }

                            if (patientMedicalMonitoring == null)
                            {
                                isNewPatientMedicalMonitoring = true;
                                patientMedicalMonitoring = new PatientMedicalMonitoring();
                            }

                            _PatientMedicalMonitoringMapper.MapToPatientMedicalMonitoring(patientMedicalMonitoring, patientMedicalMonitoringDto);

                            if (isNewPatientMedicalMonitoring)
                            {
                                unitOfWork.PatientMedicalMonitoringRepository.Insert(patientMedicalMonitoring);
                            }
                            else
                            {
                                unitOfWork.PatientMedicalMonitoringRepository.Update(patientMedicalMonitoring);
                            }
                        }
                    }
                    finally
                    {
                        unitOfWork.AutoDetectChanges = true;
                    }

                    unitOfWork.Save();
                }

                scope.Complete();
            }

            return response;
        }
    }
}
