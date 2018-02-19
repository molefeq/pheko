using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;
using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.BusinessRules;
using Pheko.ServicePresentation.EntityManager.Interfaces;
using Pheko.ServicePresentation.MapDtoToEntityObjects;
using Pheko.ServicePresentation.ServiceResponses;

using System.Transactions;

namespace Pheko.ServicePresentation.EntityManager.Classes
{
    public class PatientConsultationSickNoteManager : IPatientConsultationSickNoteManager
    {
        private PatientConsultationSickNoteBusinessRules _PatientConsultationSickNoteBusinessRules = new PatientConsultationSickNoteBusinessRules();
        private PatientConsultationSickNoteMapper _PatientConsultationSickNoteMapper = new PatientConsultationSickNoteMapper();

        #region Interface Implementation Methods

        public PatientConsultationSickNoteDto GetPatientConsultationSickNote(int patientConsultationId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return _PatientConsultationSickNoteMapper.MapToPatientConsultationSickNoteDto(unitOfWork.PatientConsultationSickNoteRepository.GetByID(p => p.PatientConsultationId == patientConsultationId));
            }
        }

        public Response<PatientConsultationSickNoteDto> SavePatientConsultationSickNote(PatientConsultationSickNoteDto patientConsultationSickNoteDto)
        {
            Response<PatientConsultationSickNoteDto> response = _PatientConsultationSickNoteBusinessRules.SaveCheck(patientConsultationSickNoteDto);

            if (response.HasErrors) return response;

            using (TransactionScope scope = new TransactionScope())
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    PatientConsultationSickNote patientConsultationSickNote = unitOfWork.PatientConsultationSickNoteRepository.GetByID(item => item.PatientConsultationId == patientConsultationSickNoteDto.PatientConsultationId);
                    bool isPatientConsultationSickNoteNew = false;

                    if (patientConsultationSickNote == null)
                    {
                        isPatientConsultationSickNoteNew = true;
                        patientConsultationSickNote = new PatientConsultationSickNote();
                    }

                    _PatientConsultationSickNoteMapper.MapToPatientConsultationSickNote(patientConsultationSickNote, patientConsultationSickNoteDto);

                    if (isPatientConsultationSickNoteNew)
                    {
                        unitOfWork.PatientConsultationSickNoteRepository.Insert(patientConsultationSickNote);
                    }
                    else
                    {
                        unitOfWork.PatientConsultationSickNoteRepository.Update(patientConsultationSickNote);
                    }

                    unitOfWork.Save();
                    response.Model = _PatientConsultationSickNoteMapper.MapToPatientConsultationSickNoteDto(unitOfWork.PatientConsultationSickNoteRepository.GetByID(p => p.PatientConsultationSickNoteId == patientConsultationSickNote.PatientConsultationSickNoteId));
                }

                scope.Complete();
            }

            return response;
        }

        #endregion
    }
}
