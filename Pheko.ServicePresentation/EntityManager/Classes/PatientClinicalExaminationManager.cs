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
    public class PatientClinicalExaminationManager : IPatientClinicalExaminationManager
    {
        private PatientClinicalExaminationBusinessRules _PatientClinicalExaminationBusinessRules = new PatientClinicalExaminationBusinessRules();
        private PatientClinicalExaminationMapper _PatientClinicalExaminationMapper = new PatientClinicalExaminationMapper();
        private ClinicalExaminationMapper _ClinicalExaminationMapper = new ClinicalExaminationMapper();

        public Result<PatientClinicalExaminationDto> GetPatientClinicalExaminations(int patientConsultationId)
        {
            Result<PatientClinicalExaminationDto> response = new Result<PatientClinicalExaminationDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                IEnumerable<ClinicalExamination> ClinicalExaminations = unitOfWork.ClinicalExaminationRepository.GetEntities();
                IEnumerable<PatientClinicalExamination> patientClinicalExaminations = unitOfWork.PatientClinicalExaminationRepository.GetEntities(item => item.PatientConsultationId == patientConsultationId, p => p.OrderBy(o => o.ClinicalExamination.SortKey));

                foreach (ClinicalExamination ClinicalExamination in ClinicalExaminations)
                {
                    ClinicalExaminationDto ClinicalExaminationDto = _ClinicalExaminationMapper.MapToClinicalExaminationDto(ClinicalExamination);
                    PatientClinicalExamination patientClinicalExamination = patientClinicalExaminations.Where(item => item.ClinicalExaminationId == ClinicalExamination.ClinicalExaminationId).FirstOrDefault();

                    PatientClinicalExaminationDto patientClinicalExaminationDto = new PatientClinicalExaminationDto()
                    {
                        PatientClinicalExaminationId = patientClinicalExamination == null ? default(int?) : patientClinicalExamination.PatientClinicalExaminationId,
                        PatientConsultationId = patientConsultationId,
                        ClinicalExamination = ClinicalExaminationDto,
                        Value = patientClinicalExamination == null ? null : patientClinicalExamination.Value
                    };

                    response.Models.Add(patientClinicalExaminationDto);
                }
            }

            return response;
        }

        public Response<PatientClinicalExaminationDto> SavePatientClinicalExaminations(List<PatientClinicalExaminationDto> patientClinicalExaminations)
        {
            Response<PatientClinicalExaminationDto> response = new Response<PatientClinicalExaminationDto>();

            foreach (PatientClinicalExaminationDto patientClinicalExaminationDto in patientClinicalExaminations)
            {
                response = _PatientClinicalExaminationBusinessRules.SaveCheck(patientClinicalExaminationDto);

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
                        foreach (PatientClinicalExaminationDto patientClinicalExaminationDto in patientClinicalExaminations)
                        {
                            bool isNewPatientClinicalExamination = false;
                            PatientClinicalExamination patientClinicalExamination = unitOfWork.PatientClinicalExaminationRepository.GetByID(item => item.PatientConsultationId == patientClinicalExaminationDto.PatientConsultationId &&
                                                                                                                                                    item.ClinicalExaminationId == patientClinicalExaminationDto.ClinicalExamination.ClinicalExaminationId.Value);


                            if (patientClinicalExamination != null && string.IsNullOrEmpty(patientClinicalExaminationDto.Value))
                            {
                                unitOfWork.PatientClinicalExaminationRepository.Delete(patientClinicalExamination);
                                continue;
                            }

                            if (string.IsNullOrEmpty(patientClinicalExaminationDto.Value))
                            {
                                continue;
                            }

                            if (patientClinicalExamination == null)
                            {
                                isNewPatientClinicalExamination = true;
                                patientClinicalExamination = new PatientClinicalExamination();
                            }

                            _PatientClinicalExaminationMapper.MapToPatientClinicalExamination(patientClinicalExamination, patientClinicalExaminationDto);

                            if (isNewPatientClinicalExamination)
                            {
                                unitOfWork.PatientClinicalExaminationRepository.Insert(patientClinicalExamination);
                            }
                            else
                            {
                                unitOfWork.PatientClinicalExaminationRepository.Update(patientClinicalExamination);
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
