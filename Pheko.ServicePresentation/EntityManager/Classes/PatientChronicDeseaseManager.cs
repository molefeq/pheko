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
    public class PatientChronicDeseaseManager : IPatientChronicDeseaseManager
    {
        private PatientChronicDeseaseBusinessRules _PatientChronicDeseaseBusinessRules = new PatientChronicDeseaseBusinessRules();
        private PatientChronicDeseaseMapper _PatientChronicDeseaseMapper = new PatientChronicDeseaseMapper();
        private ChronicDeseaseMapper _ChronicDeseaseMapper = new ChronicDeseaseMapper();

        #region Interface Implementation Methods

        public Result<PatientChronicDeseaseDto> GetPatientChronicDeseases(int patientId)
        {
            Result<PatientChronicDeseaseDto> response = new Result<PatientChronicDeseaseDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                IEnumerable<ChronicDesease> ChronicDeseases = unitOfWork.ChronicDeseaseRepository.GetEntities();
                IEnumerable<PatientChronicDesease> patientChronicDeseases = unitOfWork.PatientChronicDeseaseRepository.GetEntities(item => item.PatientId == patientId, p => p.OrderBy(o => o.ChronicDesease.SortKey));

                foreach (ChronicDesease ChronicDesease in ChronicDeseases)
                {
                    ChronicDeseaseDto ChronicDeseaseDto = _ChronicDeseaseMapper.MapToChronicDeseaseDto(ChronicDesease);
                    PatientChronicDesease patientChronicDesease = patientChronicDeseases.Where(item => item.ChronicDeseaseId == ChronicDesease.ChronicDeseaseId).FirstOrDefault();

                    PatientChronicDeseaseDto patientChronicDeseaseDto = new PatientChronicDeseaseDto()
                    {
                        PatientChronicDeseaseId = patientChronicDesease == null ? default(int?) : patientChronicDesease.PatientChronicDeseaseId,
                        PatientId = patientId,
                        ChronicDesease = ChronicDeseaseDto,
                        YearOfDiagnoses = patientChronicDesease == null ? default(int?) : patientChronicDesease.YearOfDiagnoses,
                        Value = patientChronicDesease == null ? null : patientChronicDesease.Value,
                        SelectedInd = patientChronicDesease == null ? false : true
                    };

                    response.Models.Add(patientChronicDeseaseDto);
                }
            }

            return response;
        }

        public Response<PatientChronicDeseaseDto> SavePatientChronicDeseases(List<PatientChronicDeseaseDto> patientChronicDeseases)
        {
            Response<PatientChronicDeseaseDto> response = new Response<PatientChronicDeseaseDto>();

            foreach (PatientChronicDeseaseDto patientChronicDeseaseDto in patientChronicDeseases)
            {
                response = _PatientChronicDeseaseBusinessRules.SaveCheck(patientChronicDeseaseDto);
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
                        foreach (PatientChronicDeseaseDto patientChronicDeseaseDto in patientChronicDeseases)
                        {
                            bool isNewPatientChronicDesease = false;
                            PatientChronicDesease patientChronicDesease = unitOfWork.PatientChronicDeseaseRepository.GetByID(item => item.PatientId == patientChronicDeseaseDto.PatientId &&
                                                                                                                                     item.ChronicDeseaseId == patientChronicDeseaseDto.ChronicDesease.ChronicDeseaseId.Value);

                            if (patientChronicDesease != null && !patientChronicDeseaseDto.SelectedInd)
                            {
                                unitOfWork.PatientChronicDeseaseRepository.Delete(patientChronicDesease);
                                continue;
                            }

                            if (!patientChronicDeseaseDto.SelectedInd)
                            {
                                continue;
                            }
                            
                            if (patientChronicDesease == null)
                            {
                                isNewPatientChronicDesease = true;
                                patientChronicDesease = new PatientChronicDesease();
                            }

                            _PatientChronicDeseaseMapper.MapToPatientChronicDesease(patientChronicDesease, patientChronicDeseaseDto);

                            if (isNewPatientChronicDesease)
                            {
                                unitOfWork.PatientChronicDeseaseRepository.Insert(patientChronicDesease);
                            }
                            else
                            {
                                unitOfWork.PatientChronicDeseaseRepository.Update(patientChronicDesease);
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

        #endregion
    }
}
