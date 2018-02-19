using Pheko.Common.DataTransformObjects;

using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class PatientAddressViewModelMapper
    {
        public PatientAddressViewModelMapper() { }

        public PatientAddressDto MapToPatientAddressDto(PatientAddressViewModel patientAddressViewModel)
        {
            if (patientAddressViewModel == null ||
                (string.IsNullOrEmpty(patientAddressViewModel.Line1)) &&
                 patientAddressViewModel.ProvinceId == null &&
                 string.IsNullOrEmpty(patientAddressViewModel.PostalCode) &&
                 string.IsNullOrEmpty(patientAddressViewModel.City))
            {
                return null;
            }

            PatientAddressDto patientAddressDto = new PatientAddressDto();

            patientAddressDto.PatientAddressId = patientAddressViewModel.PatientAddressId;
            patientAddressDto.Line1 = patientAddressViewModel.Line1;
            patientAddressDto.Line2 = patientAddressViewModel.Line2;
            patientAddressDto.Suburb = patientAddressViewModel.Suburb;
            patientAddressDto.City = patientAddressViewModel.City;
            patientAddressDto.ProvinceId = patientAddressViewModel.ProvinceId;
            patientAddressDto.CountryId = patientAddressViewModel.CountryId;
            patientAddressDto.PostalCode = patientAddressViewModel.PostalCode;

            return patientAddressDto;
        }

        public PatientAddressViewModel MapToPatientAddressViewModel(PatientAddressDto patientAddressDto)
        {
            if (patientAddressDto == null)
            {
                return null;
            }

            PatientAddressViewModel patientAddressViewModel = new PatientAddressViewModel();

            patientAddressViewModel.PatientAddressId = patientAddressDto.PatientAddressId;
            patientAddressViewModel.Line1 = patientAddressDto.Line1;
            patientAddressViewModel.Line2 = patientAddressDto.Line2;
            patientAddressViewModel.Suburb = patientAddressDto.Suburb;
            patientAddressViewModel.City = patientAddressDto.City;
            patientAddressViewModel.ProvinceId = patientAddressDto.ProvinceId;
            patientAddressViewModel.CountryId = patientAddressDto.CountryId;
            patientAddressViewModel.PostalCode = patientAddressDto.PostalCode;

            return patientAddressViewModel;
        }
    }
}
