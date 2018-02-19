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
    public class PatientDeseaseScreeningManager : IPatientDeseaseScreeningManager
    {
        private PatientDeseaseScreeningBusinessRules _PatientDeseaseScreeningBusinessRules = new PatientDeseaseScreeningBusinessRules();
        private PatientDeseaseScreeningMapper _PatientDeseaseScreeningMapper = new PatientDeseaseScreeningMapper();
        private DeseaseScreeningMapper _DeseaseScreeningMapper = new DeseaseScreeningMapper();

        public Result<PatientDeseaseScreeningDto> GetPatientDeseaseScreenings(int patientId)
        {
            Result<PatientDeseaseScreeningDto> response = new Result<PatientDeseaseScreeningDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                IEnumerable<DeseaseScreening> DeseaseScreenings = unitOfWork.DeseaseScreeningRepository.GetEntities();
                IEnumerable<PatientDeseaseScreening> patientDeseaseScreenings = unitOfWork.PatientDeseaseScreeningRepository.GetEntities(item => item.PatientId == patientId, p => p.OrderBy(o => o.DeseaseScreening.SortKey));

                foreach (DeseaseScreening DeseaseScreening in DeseaseScreenings)
                {
                    DeseaseScreeningDto DeseaseScreeningDto = _DeseaseScreeningMapper.MapToDeseaseScreeningDto(DeseaseScreening);
                    PatientDeseaseScreening patientDeseaseScreening = patientDeseaseScreenings.Where(item => item.DeseaseScreeningId == DeseaseScreening.DeseaseScreeningId).FirstOrDefault();

                    PatientDeseaseScreeningDto patientDeseaseScreeningDto = new PatientDeseaseScreeningDto()
                    {
                        PatientDeseaseScreeningId = patientDeseaseScreening == null ? default(int?) : patientDeseaseScreening.PatientDeseaseScreeningId,
                        PatientId = patientId,
                        DeseaseScreening = DeseaseScreeningDto,
                        YearOfScreening = patientDeseaseScreening == null ? default(int?) : patientDeseaseScreening.YearOfScreening,
                        Value = patientDeseaseScreening == null ? null : patientDeseaseScreening.Value,
                        SelectedInd = patientDeseaseScreening == null ? false : true
                    };

                    response.Models.Add(patientDeseaseScreeningDto);
                }
            }

            return response;
        }

        public Response<PatientDeseaseScreeningDto> SavePatientDeseaseScreenings(List<PatientDeseaseScreeningDto> patientDeseaseScreenings)
        {
            Response<PatientDeseaseScreeningDto> response = new Response<PatientDeseaseScreeningDto>();

            foreach (PatientDeseaseScreeningDto patientDeseaseScreeningDto in patientDeseaseScreenings)
            {
                response = _PatientDeseaseScreeningBusinessRules.SaveCheck(patientDeseaseScreeningDto);
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
                        foreach (PatientDeseaseScreeningDto patientDeseaseScreeningDto in patientDeseaseScreenings)
                        {
                            bool isNewPatientDeseaseScreening = false;
                            PatientDeseaseScreening patientDeseaseScreening = unitOfWork.PatientDeseaseScreeningRepository.GetByID(item => item.PatientId == patientDeseaseScreeningDto.PatientId &&
                                                                                                                                           item.DeseaseScreeningId == patientDeseaseScreeningDto.DeseaseScreening.DeseaseScreeningId.Value);

                            if (patientDeseaseScreening != null && !patientDeseaseScreeningDto.SelectedInd)
                            {
                                unitOfWork.PatientDeseaseScreeningRepository.Delete(patientDeseaseScreening);
                                continue;
                            }

                            if (!patientDeseaseScreeningDto.SelectedInd)
                            {
                                continue;
                            }
                            
                            if (patientDeseaseScreening == null)
                            {
                                isNewPatientDeseaseScreening = true;
                                patientDeseaseScreening = new PatientDeseaseScreening();
                            }

                            _PatientDeseaseScreeningMapper.MapToPatientDeseaseScreening(patientDeseaseScreening, patientDeseaseScreeningDto);

                            if (isNewPatientDeseaseScreening)
                            {
                                unitOfWork.PatientDeseaseScreeningRepository.Insert(patientDeseaseScreening);
                            }
                            else
                            {
                                unitOfWork.PatientDeseaseScreeningRepository.Update(patientDeseaseScreening);
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
