using Pheko.Common.DataTransformObjects;
using Pheko.Common.UtilityComponent;
using Pheko.WebPresentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class PatientConsultationViewModelMapper
    {
        public PatientConsultationViewModelMapper() { }

        public PatientConsultationDto MapToPatientConsultationDto(PatientConsultationViewModel patientConsultationViewModel)
        {
            if (patientConsultationViewModel == null)
            {
                return null;
            }

            PatientConsultationDto patientConsultationDto = new PatientConsultationDto();
            CrudOperationsMapper crudOperationsMapper = new CrudOperationsMapper();

            patientConsultationDto.PatientConsultationId = patientConsultationViewModel.PatientConsultationId;
            patientConsultationDto.PatientId = patientConsultationViewModel.PatientId == null? int.MinValue : patientConsultationViewModel.PatientId.Value;
            patientConsultationDto.DoctorId = patientConsultationViewModel.DoctorId == null ? int.MinValue : patientConsultationViewModel.DoctorId.Value;
            patientConsultationDto.ConsultationStatus = patientConsultationViewModel.ConsultationStatus;
            patientConsultationDto.StartDate = Converter.StringToDate(patientConsultationViewModel.StartDate);
            patientConsultationDto.EndDate = Converter.StringToDate(patientConsultationViewModel.EndDate);
            patientConsultationDto.CrudOperation = crudOperationsMapper.MapToCrudOperations(patientConsultationViewModel.CrudOperation);
            
            return patientConsultationDto;
        }

        public PatientConsultationViewModel MapToPatientConsultationViewModel(PatientConsultationDto patientConsultationDto)
        {
            if (patientConsultationDto == null)
            {
                return null;
            }

            PatientConsultationViewModel patientConsultationViewModel = new PatientConsultationViewModel();
            CrudOperationsMapper crudOperationsMapper = new CrudOperationsMapper();

            patientConsultationViewModel.PatientConsultationId = patientConsultationDto.PatientConsultationId;
            patientConsultationViewModel.PatientId = patientConsultationDto.PatientId;
            patientConsultationViewModel.DoctorId = patientConsultationDto.DoctorId;
            patientConsultationViewModel.ConsultationStatus = patientConsultationDto.ConsultationStatus;
            patientConsultationViewModel.StartDate = Converter.DateToString(patientConsultationDto.StartDate);
            patientConsultationViewModel.EndDate = Converter.DateToString(patientConsultationDto.EndDate);
            patientConsultationViewModel.CrudOperation = crudOperationsMapper.MapToModelCrudOperations(patientConsultationDto.CrudOperation);

            return patientConsultationViewModel;
        }
    }
}
