using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;

using Pheko.DataAccess;
using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.BusinessRules;
using Pheko.ServicePresentation.EntityManager.Interfaces;
using Pheko.ServicePresentation.MapDtoToEntityObjects;
using Pheko.ServicePresentation.ServiceResponses;

using System;
using System.Transactions;

namespace Pheko.ServicePresentation.EntityManager.Classes
{
    public class PatientMedicalAidDependancyManager : IPatientMedicalAidDependancyManager
    {
        private PatientMedicalAidDependancyMapper _PatientMedicalAidDependancyMapper = new PatientMedicalAidDependancyMapper();
        private PatientMedicalAidDependancyBusinessRules _PatientMedicalAidDependancyBusinessRules = new PatientMedicalAidDependancyBusinessRules();

        #region Interface Implemantation Methods

        public Response<PatientMedicalAidDependancyDto> SavePatientMedicalAidDependancy(PatientMedicalAidDependancyDto patientMedicalAidDependancyDto)
        {
            Response<PatientMedicalAidDependancyDto> response = _PatientMedicalAidDependancyBusinessRules.SaveCheck(patientMedicalAidDependancyDto);

            if (response.HasErrors) return response;

            switch (patientMedicalAidDependancyDto.CrudOperation)
            {
                case CrudOperations.Create:
                    response.Model = CreatePatientMedicalAidDependancy(patientMedicalAidDependancyDto);
                    break;
                case CrudOperations.Update:
                    response.Model = UpdatePatientMedicalAidDependancy(patientMedicalAidDependancyDto);
                    break;
                case CrudOperations.Delete:
                    DeletePatientMedicalAidDependancy(patientMedicalAidDependancyDto);
                    break;
                default:
                    throw new ArgumentException("Invalid crud operation.");
            }

            return response;
        }

        #endregion

        #region Private Methods

        private PatientMedicalAidDependancyDto CreatePatientMedicalAidDependancy(PatientMedicalAidDependancyDto patientMedicalAidDependancyDto)
        {
            PatientMedicalAidDependancyDto addedPatientMedicalAidDependancyDto = null;
            PatientMedicalAidDependancy patientMedicalAidDependancy = new PatientMedicalAidDependancy();

            _PatientMedicalAidDependancyMapper.MapToPatientMedicalAidDependancy(patientMedicalAidDependancy, patientMedicalAidDependancyDto);

            using (TransactionScope scope = new TransactionScope())
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.PatientMedicalAidDependancyRepository.Insert(patientMedicalAidDependancy);
                    unitOfWork.Save();

                    addedPatientMedicalAidDependancyDto = _PatientMedicalAidDependancyMapper.MapToPatientMedicalAidDependancyDto(unitOfWork.PatientMedicalAidDependancyRepository.GetByID(p => p.PatientMedicalAidDependanciesId == patientMedicalAidDependancy.PatientMedicalAidDependanciesId));
                }

                scope.Complete();
            }

            return addedPatientMedicalAidDependancyDto;
        }

        private PatientMedicalAidDependancyDto UpdatePatientMedicalAidDependancy(PatientMedicalAidDependancyDto patientMedicalAidDependancyDto)
        {
            PatientMedicalAidDependancyDto updatedPatientMedicalAidDependancyDto = null;

            using (TransactionScope scope = new TransactionScope())
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    PatientMedicalAidDependancy patientMedicalAidDependancy = unitOfWork.PatientMedicalAidDependancyRepository.GetByID(p => p.PatientMedicalAidDependanciesId == patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId);

                    _PatientMedicalAidDependancyMapper.MapToPatientMedicalAidDependancy(patientMedicalAidDependancy, patientMedicalAidDependancyDto);

                    unitOfWork.PatientMedicalAidDependancyRepository.Update(patientMedicalAidDependancy);
                    unitOfWork.Save();

                    updatedPatientMedicalAidDependancyDto = _PatientMedicalAidDependancyMapper.MapToPatientMedicalAidDependancyDto(unitOfWork.PatientMedicalAidDependancyRepository.GetByID(p => p.PatientMedicalAidDependanciesId == patientMedicalAidDependancy.PatientMedicalAidDependanciesId));
                }

                scope.Complete();
            }

            return updatedPatientMedicalAidDependancyDto;
        }

        private void DeletePatientMedicalAidDependancy(PatientMedicalAidDependancyDto patientMedicalAidDependancyDto)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.PatientMedicalAidDependancyRepository.Delete(patientMedicalAidDependancyDto.PatientMedicalAidDependanciesId.Value);
                    unitOfWork.Save();
                }

                scope.Complete();
            }
        }

        #endregion
    }
}
