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
    public class PatientPastMedicalHistoryManager : IPatientPastMedicalHistoryManager
    {
        private PatientPastMedicalHistoryBusinessRules _PatientPastMedicalHistoryBusinessRules = new PatientPastMedicalHistoryBusinessRules();
        private PatientPastMedicalHistoryMapper _PatientPastMedicalHistoryMapper = new PatientPastMedicalHistoryMapper();
        private PastMedicalHistoryMapper _PastMedicalHistoryMapper = new PastMedicalHistoryMapper();

        public Result<PatientPastMedicalHistoryDto> GetPatientPastMedicalHistories(int patientId)
        {
            Result<PatientPastMedicalHistoryDto> response = new Result<PatientPastMedicalHistoryDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                IEnumerable<PastMedicalHistory> PastMedicalHistorys = unitOfWork.PastMedicalHistoryRepository.GetEntities();
                IEnumerable<PatientPastMedicalHistory> patientPastMedicalHistorys = unitOfWork.PatientPastMedicalHistoryRepository.GetEntities(item => item.PatientId == patientId, p => p.OrderBy(o => o.PastMedicalHistory.SortKey));

                foreach (PastMedicalHistory PastMedicalHistory in PastMedicalHistorys)
                {
                    PastMedicalHistoryDto PastMedicalHistoryDto = _PastMedicalHistoryMapper.MapToPastMedicalHistoryDto(PastMedicalHistory);
                    PatientPastMedicalHistory patientPastMedicalHistory = patientPastMedicalHistorys.Where(item => item.PastMedicalHistoryId == PastMedicalHistory.PastMedicalHistoryId).FirstOrDefault();

                    PatientPastMedicalHistoryDto patientPastMedicalHistoryDto = new PatientPastMedicalHistoryDto()
                    {
                        PatientPastMedicalHistoryId = patientPastMedicalHistory == null ? default(int?) : patientPastMedicalHistory.PatientPastMedicalHistoryId,
                        PatientId = patientId,
                        PastMedicalHistory = PastMedicalHistoryDto,
                        Value = patientPastMedicalHistory == null ? null : patientPastMedicalHistory.Value
                    };

                    response.Models.Add(patientPastMedicalHistoryDto);
                }
            }

            return response;
        }

        public Response<PatientPastMedicalHistoryDto> SavePatientPastMedicalHistories(List<PatientPastMedicalHistoryDto> pastMedicalHistories)
        {
            Response<PatientPastMedicalHistoryDto> response = new Response<PatientPastMedicalHistoryDto>();
            foreach (PatientPastMedicalHistoryDto patientPastMedicalHistoryDto in pastMedicalHistories)
            {
                response = _PatientPastMedicalHistoryBusinessRules.SaveCheck(patientPastMedicalHistoryDto);
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
                        foreach (PatientPastMedicalHistoryDto patientPastMedicalHistoryDto in pastMedicalHistories)
                        {
                            bool isNewPatientPastMedicalHistory = false;
                            PatientPastMedicalHistory patientPastMedicalHistory = unitOfWork.PatientPastMedicalHistoryRepository.GetByID(item => item.PatientId == patientPastMedicalHistoryDto.PatientId &&
                                                                                                                                                 item.PastMedicalHistoryId == patientPastMedicalHistoryDto.PastMedicalHistory.PastMedicalHistoryId.Value);

                            if (patientPastMedicalHistory != null && string.IsNullOrEmpty(patientPastMedicalHistoryDto.Value))
                            {
                                unitOfWork.PatientPastMedicalHistoryRepository.Delete(patientPastMedicalHistory);
                                continue;
                            }

                            if (string.IsNullOrEmpty(patientPastMedicalHistoryDto.Value))
                            {
                                continue;
                            }

                            if (patientPastMedicalHistory == null)
                            {
                                isNewPatientPastMedicalHistory = true;
                                patientPastMedicalHistory = new PatientPastMedicalHistory();
                            }

                            _PatientPastMedicalHistoryMapper.MapToPatientPastMedicalHistory(patientPastMedicalHistory, patientPastMedicalHistoryDto);

                            if (isNewPatientPastMedicalHistory)
                            {
                                unitOfWork.PatientPastMedicalHistoryRepository.Insert(patientPastMedicalHistory);
                            }
                            else
                            {
                                unitOfWork.PatientPastMedicalHistoryRepository.Update(patientPastMedicalHistory);
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
