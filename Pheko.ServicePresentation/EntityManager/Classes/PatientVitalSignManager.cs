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
    public class PatientVitalSignManager : IPatientVitalSignManager
    {
        private PatientVitalSignBusinessRules _PatientVitalSignBusinessRules = new PatientVitalSignBusinessRules();
        private PatientVitalSignMapper _PatientVitalSignMapper = new PatientVitalSignMapper();
        private VitalSignMapper _VitalSignMapper = new VitalSignMapper();

        public Result<PatientVitalSignDto> GetPatientVitalSigns(int patientConsultationId)
        {
            Result<PatientVitalSignDto> response = new Result<PatientVitalSignDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                IEnumerable<VitalSign> vitalSigns = unitOfWork.VitalSignRepository.GetEntities();
                IEnumerable<PatientVitalSign> patientVitalSigns = unitOfWork.PatientVitalSignRepository.GetEntities(item => item.PatientConsultationId == patientConsultationId, p => p.OrderBy(o => o.VitalSign.Name));

                foreach (VitalSign vitalSign in vitalSigns)
                {
                    VitalSignDto vitalSignDto = _VitalSignMapper.MapToVitalSignDto(vitalSign);
                    PatientVitalSign patientVitalSign = patientVitalSigns.Where(item => item.VitalSignId == vitalSign.VitalSignId).FirstOrDefault();

                    PatientVitalSignDto patientVitalSignDto = new PatientVitalSignDto()
                    {
                        PatientVitalSignId = patientVitalSign == null ? default(int?) : patientVitalSign.PatientVitalSignId,
                        PatientConsultationId = patientConsultationId,
                        VitalSign = vitalSignDto,
                        VitalSignValue = patientVitalSign == null ? null : patientVitalSign.VitalSignValue
                    };

                    response.Models.Add(patientVitalSignDto);
                }
            }

            return response;
        }

        public Response<PatientVitalSignDto> SavePatientVitalSigns(List<PatientVitalSignDto> patientVitalSigns)
        {
            Response<PatientVitalSignDto> response = new Response<PatientVitalSignDto>();

            foreach (PatientVitalSignDto patientVitalSignDto in patientVitalSigns)
            {
                response = _PatientVitalSignBusinessRules.SaveCheck(patientVitalSignDto);
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
                        foreach (PatientVitalSignDto patientVitalSignDto in patientVitalSigns)
                        {
                            bool isNewPatientVitalSign = false;
                            PatientVitalSign patientVitalSign = unitOfWork.PatientVitalSignRepository.GetByID(item => item.PatientConsultationId == patientVitalSignDto.PatientConsultationId &&
                                                                                                                      item.VitalSignId == patientVitalSignDto.VitalSign.VitalSignId.Value);

                            if (patientVitalSign != null && string.IsNullOrEmpty(patientVitalSignDto.VitalSignValue))
                            {
                                unitOfWork.PatientVitalSignRepository.Delete(patientVitalSign);
                                continue;
                            }

                            if (string.IsNullOrEmpty(patientVitalSignDto.VitalSignValue))
                            {
                                continue;
                            }

                            if (patientVitalSign == null)
                            {
                                isNewPatientVitalSign = true;
                                patientVitalSign = new PatientVitalSign();
                            }

                            _PatientVitalSignMapper.MapToPatientVitalSign(patientVitalSignDto, patientVitalSign);

                            if (isNewPatientVitalSign)
                            {
                                unitOfWork.PatientVitalSignRepository.Insert(patientVitalSign);
                            }
                            else
                            {
                                unitOfWork.PatientVitalSignRepository.Update(patientVitalSign);
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
