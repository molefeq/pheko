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
    public class PatientMedicalNoteManager : IPatientMedicalNoteManager
    {
        private PatientMedicalNoteBusinessRules _PatientMedicalNoteBusinessRules = new PatientMedicalNoteBusinessRules();
        private PatientMedicalNoteMapper _PatientMedicalNoteMapper = new PatientMedicalNoteMapper();
        private MedicalNoteMapper _MedicalNoteMapper = new MedicalNoteMapper();
       
        public Result<PatientMedicalNoteDto> GetPatientMedicalNotes(int patientConsultationId)
        {
            Result<PatientMedicalNoteDto> response = new Result<PatientMedicalNoteDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                IEnumerable<MedicalNote> medicalNotes = unitOfWork.MedicalNoteRepository.GetEntities();
                IEnumerable<PatientMedicalNote> patientMedicalNotes = unitOfWork.PatientMedicalNoteRepository.GetEntities(item => item.PatientConsultationId == patientConsultationId, p => p.OrderBy(o => o.MedicalNote.SortKey));

                foreach (MedicalNote medicalNote in medicalNotes)
                {
                    MedicalNoteDto medicalNoteDto = _MedicalNoteMapper.MapToMedicalNoteDto(medicalNote);
                    PatientMedicalNote patientMedicalNote = patientMedicalNotes.Where(item => item.MedicalNoteId == medicalNote.MedicalNoteId).FirstOrDefault();

                    PatientMedicalNoteDto patientMedicalNoteDto = new PatientMedicalNoteDto()
                    {
                        PatientMedicalNoteId = patientMedicalNote == null ? default(int?) : patientMedicalNote.PatientMedicalNoteId,
                        PatientConsultationId = patientConsultationId,
                        MedicalNote = medicalNoteDto,
                        Value = patientMedicalNote == null ? null : patientMedicalNote.Value
                    };

                    response.Models.Add(patientMedicalNoteDto);
                }
            }

            return response;
        }

        public Response<PatientMedicalNoteDto> SavePatientMedicalNotes(List<PatientMedicalNoteDto> patientMedicalNotes)
        {
            Response<PatientMedicalNoteDto> response = new Response<PatientMedicalNoteDto>();

            foreach (PatientMedicalNoteDto patientMedicalNoteDto in patientMedicalNotes)
            {
                response = _PatientMedicalNoteBusinessRules.SaveCheck(patientMedicalNoteDto);
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
                        foreach (PatientMedicalNoteDto patientMedicalNoteDto in patientMedicalNotes)
                        {
                            bool isNewPatientMedicalNote = false;
                            PatientMedicalNote patientMedicalNote = unitOfWork.PatientMedicalNoteRepository.GetByID(item => item.PatientConsultationId == patientMedicalNoteDto.PatientConsultationId &&
                                                                                                                            item.MedicalNoteId == patientMedicalNoteDto.MedicalNote.MedicalNoteId.Value);
                            
                            if (patientMedicalNote != null && string.IsNullOrEmpty(patientMedicalNoteDto.Value))
                            {
                                unitOfWork.PatientMedicalNoteRepository.Delete(patientMedicalNote);
                                continue;
                            }

                            if (string.IsNullOrEmpty(patientMedicalNoteDto.Value))
                            {
                                continue;
                            }

                            if (patientMedicalNote == null)
                            {
                                isNewPatientMedicalNote = true;
                                patientMedicalNote = new PatientMedicalNote();
                            }

                            _PatientMedicalNoteMapper.MapToPatientMedicalNote(patientMedicalNote, patientMedicalNoteDto);

                            if (isNewPatientMedicalNote)
                            {
                                unitOfWork.PatientMedicalNoteRepository.Insert(patientMedicalNote);
                            }
                            else
                            {
                                unitOfWork.PatientMedicalNoteRepository.Update(patientMedicalNote);
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
