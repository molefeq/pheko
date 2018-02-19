using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;

using Pheko.WebPresentation.MappingViewModelsToDtos;
using Pheko.WebPresentation.PhekoService;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;
using Pheko.WebPresentation.Utility;
using Pheko.WebPresentation.ViewModels;

using System.Collections.Generic;
using System.Linq;

namespace Pheko.WebPresentation.ServiceHandlers.Classes
{
    public class PatientMedicalNoteHandler : IPatientMedicalNoteHandler
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();
        private PatientMedicalNoteViewModelMapper _PatientMedicalNoteViewModelMapper = new PatientMedicalNoteViewModelMapper();
        private PatientChronicDeseaseViewModelMapper _PatientChronicDeseaseViewModelMapper = new PatientChronicDeseaseViewModelMapper();
        private PatientPastMedicalHistoryViewModelMapper _PatientPastMedicalHistoryViewModelMapper = new PatientPastMedicalHistoryViewModelMapper();
        private PatientDeseaseScreeningViewModelMapper _PatientDeseaseScreeningViewModelMapper = new PatientDeseaseScreeningViewModelMapper();

        public PatientMedicalNoteHandler() { }

        public List<PatientMedicalNoteViewModel> GetPatientMedicalNotes(int patientConsultationId)
        {
            PatientMedicalNoteDtoResult response = _PhekoServiceClient.GetPatientMedicalNotes(patientConsultationId);

            return response.Models.Select(item => _PatientMedicalNoteViewModelMapper.MapToPatientMedicalNoteViewModel(item)).ToList<PatientMedicalNoteViewModel>();
        }

        public void SavePatientMedicalNotes(List<PatientMedicalNoteViewModel> patientMedicalNoteViewModels)
        {
            PatientMedicalNoteDto[] patientMedicalNoteDtos = patientMedicalNoteViewModels.Select(item => _PatientMedicalNoteViewModelMapper.MapToPatientMedicalNoteDto(item)).ToArray();
            PatientMedicalNoteDtoResponse response = _PhekoServiceClient.SavePatientMedicalNotes(patientMedicalNoteDtos);

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }

        }
        
        public List<PatientChronicDeseaseViewModel> GetPatientChronicDeseases(int patientId)
        {
            PatientChronicDeseaseDtoResult response = _PhekoServiceClient.GetPatientChronicDeseases(patientId);

            return response.Models.Select(item => _PatientChronicDeseaseViewModelMapper.MapToPatientChronicDeseaseViewModel(item)).ToList<PatientChronicDeseaseViewModel>();
        }

        public void SavePatientChronicDeseases(List<PatientChronicDeseaseViewModel> patientChronicDeseaseViewModels)
        {
            PatientChronicDeseaseDto[] patientChronicDeseaseDtos = patientChronicDeseaseViewModels.Select(item => _PatientChronicDeseaseViewModelMapper.MapToPatientChronicDeseaseDto(item)).ToArray();
            PatientChronicDeseaseDtoResponse response = _PhekoServiceClient.SavePatientChronicDeseases(patientChronicDeseaseDtos);

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }
        }

        public List<PatientPastMedicalHistoryViewModel> GetPatientPastMedicalHistories(int patientId)
        {
            PatientPastMedicalHistoryDtoResult response = _PhekoServiceClient.GetPatientPastMedicalHistories(patientId);

            return response.Models.Select(item => _PatientPastMedicalHistoryViewModelMapper.MapToPatientPastMedicalHistoryViewModel(item)).ToList<PatientPastMedicalHistoryViewModel>();
        }

        public void SavePastMedicalHistories(List<PatientPastMedicalHistoryViewModel> patientPastMedicalHistoryViewModels)
        {
            PatientPastMedicalHistoryDto[] patientPastMedicalHistoryDtos = patientPastMedicalHistoryViewModels.Select(item => _PatientPastMedicalHistoryViewModelMapper.MapToPatientPastMedicalHistoryDto(item)).ToArray();
            PatientPastMedicalHistoryDtoResponse response = _PhekoServiceClient.SavePatientPastMedicalHistories(patientPastMedicalHistoryDtos);

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }
        }

        public List<PatientDeseaseScreeningViewModel> GetPatientDeseaseScreenings(int patientId)
        {
            PatientDeseaseScreeningDtoResult response = _PhekoServiceClient.GetPatientDeseaseScreenings(patientId);

            return response.Models.Select(item => _PatientDeseaseScreeningViewModelMapper.MapToPatientDeseaseScreeningViewModel(item)).ToList<PatientDeseaseScreeningViewModel>();
        }

        public void SavePatientDeseaseScreenings(List<PatientDeseaseScreeningViewModel> patientDeseaseScreeningViewModels)
        {
            PatientDeseaseScreeningDto[] patientDeseaseScreeningDtos = patientDeseaseScreeningViewModels.Select(item => _PatientDeseaseScreeningViewModelMapper.MapToPatientDeseaseScreeningDto(item)).ToArray();
            PatientDeseaseScreeningDtoResponse response = _PhekoServiceClient.SavePatientDeseaseScreenings(patientDeseaseScreeningDtos);

            if (response.HasErrors)
            {
                ModelException modelException = new ModelException();

                response.FieldErrors.ToList<FieldError>().ForEach(item => modelException.ModelErrors.Add(new ModelError() { FieldName = item.FieldName, Message = item.ErrorMessage }));

                throw modelException;
            }
        }
    }
}
