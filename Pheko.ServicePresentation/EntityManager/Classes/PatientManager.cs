using Pheko.Common.DataTransformObjects;
using Pheko.Common.Enums;
using Pheko.Common.UtilityComponent;

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
    public class PatientManager : IPatientManager
    {
        private PatientBusinessRules _PatientBusinessRules = new PatientBusinessRules();
        private PatientMapper _PatientMapper = new PatientMapper();
        private PatientMedicalAidDependancyMapper _PatientMedicalAidDependancyMapper = new PatientMedicalAidDependancyMapper();

        #region Interface Implementation Methods

        public PatientDetailResponse SavePatient(PatientDto patientDto)
        {
            PatientDetailResponse response = _PatientBusinessRules.SaveCheck(patientDto);

            if (response.HasErrors) return response;

            switch (patientDto.CrudOperation)
            {
                case CrudOperations.Create:
                    return CreatePatient(patientDto);
                case CrudOperations.Update:
                    return UpdatePatient(patientDto);
                default:
                    throw new ArgumentException("Invalid crud operation.");
            }
        }

        public PatientDetailResponse GetPatientDetails(int patientId)
        {
            PatientDetailResponse response = new PatientDetailResponse();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Patient patient = unitOfWork.PatientRepository.GetByID(p => p.PatientId == patientId, "PostalAddress, PhysicalAddress, PatientMedicalAidDependancies");

                if (patient == null)
                {
                    response.HasErrors = true;
                    response.FieldErrors.Add(new FieldError() { ErrorMessage = "The patient entry you trying to retrieve does not exist." });
                    return response;
                }

                response.Patient = _PatientMapper.MapToPatientDto(patient);
                response.PatientMedicalAidDependancies = patient.PatientMedicalAidDependancies.Select(item => _PatientMedicalAidDependancyMapper.MapToPatientMedicalAidDependancyDto(item))
                                                                                              .ToList<PatientMedicalAidDependancyDto>();
            }

            return response;
        }

        public Result<PatientDto> Search(PatientDto searchPatient)
        {
            Result<PatientDto> response = new Result<PatientDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Expression<Func<Patient, bool>> searchFilter = p => (searchPatient.PatientId == null || p.PatientId == searchPatient.PatientId) &&
                                                                    (string.IsNullOrEmpty(searchPatient.FirstName) || p.FirstName.Contains(searchPatient.FirstName)) &&
                                                                    (string.IsNullOrEmpty(searchPatient.LastName) || p.LastName.Contains(searchPatient.LastName)) &&
                                                                    (searchPatient.BirthDate == null || p.BirthDate == searchPatient.BirthDate) &&
                                                                    (string.IsNullOrEmpty(searchPatient.IDNumber) || p.IDNumber.Contains(searchPatient.IDNumber));

                List<Patient> patients = unitOfWork.PatientRepository.GetEntities(searchFilter, p => p.OrderBy(o => o.FirstName), "PostalAddress, PhysicalAddress").ToList<Patient>();

                if (patients != null && patients.Count() > 0)
                {
                    response.Models = patients.Select(item => _PatientMapper.MapToPatientDto(item)).ToList<PatientDto>();
                }
            }

            return response;
        }
        
        #endregion

        #region Private Methods

        private PatientDetailResponse CreatePatient(PatientDto insertedPatient)
        {
            PatientDetailResponse response = _PatientBusinessRules.CreateCheck(insertedPatient);

            if (response.HasErrors) return response;

            Patient patient = new Patient();

            _PatientMapper.MapToPatient(patient, insertedPatient);

            using (TransactionScope scope = new TransactionScope())
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.PatientRepository.Insert(patient);
                    unitOfWork.Save();

                    response.Patient = _PatientMapper.MapToPatientDto(unitOfWork.PatientRepository.GetByID(p => p.PatientId == patient.PatientId, "PostalAddress, PhysicalAddress"));
                }

                scope.Complete();
            }

            return response;
        }

        private PatientDetailResponse UpdatePatient(PatientDto updatedPatient)
        {
            PatientDetailResponse response = _PatientBusinessRules.UpdateCheck(updatedPatient);

            if (response.HasErrors) return response;

            using (TransactionScope scope = new TransactionScope())
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Patient patient = unitOfWork.PatientRepository.GetByID(p => p.PatientId == updatedPatient.PatientId, "PostalAddress, PhysicalAddress");

                    _PatientMapper.MapToPatient(patient, updatedPatient);

                    if (updatedPatient.MedicalAidInd == null || !updatedPatient.MedicalAidInd.Value)
                    {
                        patient.PatientMedicalAidDependancies.ToList().ForEach(item => unitOfWork.PatientMedicalAidDependancyRepository.Delete(item));
                    }

                    unitOfWork.PatientRepository.Update(patient);
                    unitOfWork.Save();

                    response.Patient = _PatientMapper.MapToPatientDto(unitOfWork.PatientRepository.GetByID(p => p.PatientId == patient.PatientId, "PostalAddress, PhysicalAddress"));
                }

                scope.Complete();
            }

            return response;
        }

        #endregion

    }
}
