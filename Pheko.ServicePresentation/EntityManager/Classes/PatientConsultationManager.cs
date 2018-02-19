using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;

using Pheko.DataAccess;
using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.BusinessRules;
using Pheko.ServicePresentation.EntityManager.Interfaces;
using Pheko.ServicePresentation.MapDtoToEntityObjects;
using Pheko.ServicePresentation.ServiceResponses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace Pheko.ServicePresentation.EntityManager.Classes
{
    public class PatientConsultationManager : IPatientConsultationManager
    {
        private PatientConsultationMapper _PatientConsultationMapper = new PatientConsultationMapper();
        private PatientConsultationBusinessRules _PatientConsultationBusinessRules = new PatientConsultationBusinessRules();

        #region Interface Implemantation Methods

        public Result<PatientConsultationDto> GetPatientConsultations(int patientId, string searchText)
        {
            Result<PatientConsultationDto> response = new Result<PatientConsultationDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Expression<Func<PatientConsultation, bool>> searchFilter = p => p.PatientId == patientId;
                List<PatientConsultation> patientConsultations = unitOfWork.PatientConsultationRepository.GetEntities(searchFilter, p => p.OrderByDescending(o => o.StartDate)).ToList<PatientConsultation>();

                if (patientConsultations != null && patientConsultations.Count() > 0)
                {
                    response.Models = patientConsultations.Select(item => _PatientConsultationMapper.MapToPatientConsultationDto(item)).ToList<PatientConsultationDto>();
                }
            }

            return response;
        }

        public Response<PatientConsultationDto> SavePatientConsultation(PatientConsultationDto patientConsultationDto)
        {
            Response<PatientConsultationDto> response = _PatientConsultationBusinessRules.SaveCheck(patientConsultationDto);

            if (response.HasErrors) return response;

            switch (patientConsultationDto.CrudOperation)
            {
                case CrudOperations.Create:
                    response.Model = Create(patientConsultationDto);
                    break;
                case CrudOperations.Update:
                    response.Model = Update(patientConsultationDto);
                    break;
                case CrudOperations.Delete:
                    Delete(patientConsultationDto);
                    break;
                default:
                    throw new ArgumentException("Invalid crud operation.");
            }

            return response;
        }

        #endregion

        #region Private Methods

        private PatientConsultationDto Create(PatientConsultationDto patientConsultationDto)
        {
            PatientConsultationDto addedPatientConsultationDto = null;
            PatientConsultation patientConsultation = new PatientConsultation();

            _PatientConsultationMapper.MapToPatientConsultation(patientConsultation, patientConsultationDto);

            using (TransactionScope scope = new TransactionScope())
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.PatientConsultationRepository.Insert(patientConsultation);
                    unitOfWork.Save();

                    addedPatientConsultationDto = _PatientConsultationMapper.MapToPatientConsultationDto(unitOfWork.PatientConsultationRepository.GetByID(p => p.PatientConsultationId == patientConsultation.PatientConsultationId));
                }

                scope.Complete();
            }

            return addedPatientConsultationDto;
        }

        private PatientConsultationDto Update(PatientConsultationDto patientConsultationDto)
        {
            PatientConsultationDto updatedPatientConsultationDto = null;

            using (TransactionScope scope = new TransactionScope())
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    PatientConsultation patientConsultation = unitOfWork.PatientConsultationRepository.GetByID(p => p.PatientConsultationId == patientConsultationDto.PatientConsultationId);

                    _PatientConsultationMapper.MapToPatientConsultation(patientConsultation, patientConsultationDto);

                    unitOfWork.PatientConsultationRepository.Update(patientConsultation);
                    unitOfWork.Save();

                    updatedPatientConsultationDto = _PatientConsultationMapper.MapToPatientConsultationDto(unitOfWork.PatientConsultationRepository.GetByID(p => p.PatientConsultationId == patientConsultation.PatientConsultationId));
                }

                scope.Complete();
            }

            return updatedPatientConsultationDto;
        }

        private void Delete(PatientConsultationDto patientConsultationDto)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.PatientMedicalAidDependancyRepository.Delete(patientConsultationDto.PatientConsultationId.Value);
                    unitOfWork.Save();
                }

                scope.Complete();
            }
        }

        #endregion
    }
}
