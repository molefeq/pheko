using Pheko.Common.DataTransformObjects;
using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class PatientAddressMapper
    {
        public PatientAddressMapper() { }

        public PatientAddressDto MapToPatientAddressDto(PatientAddress patientAddress)
        {
            if (patientAddress == null)
            {
                return null;
            }

            PatientAddressDto patientAddressDto = new PatientAddressDto();

            patientAddressDto.PatientAddressId = patientAddress.PatientAddressId;
            patientAddressDto.Line1 = patientAddress.Line1;
            patientAddressDto.Line2 = patientAddress.Line2;
            patientAddressDto.Suburb = patientAddress.Suburb;
            patientAddressDto.City = patientAddress.City;
            patientAddressDto.PostalCode = patientAddress.PostalCode;
            patientAddressDto.ProvinceId = patientAddress.ProvinceId;
            patientAddressDto.CountryId = patientAddress.CountryId;

            return patientAddressDto;
        }

        public void MapToPatientAddress(PatientAddress patientAddress, PatientAddressDto patientAddressDto)
        {
            if (patientAddressDto == null)
            {
                return;
            }

            patientAddress = patientAddress ?? new PatientAddress();
            
            patientAddress.Line1 = patientAddressDto.Line1;
            patientAddress.Line2 = patientAddressDto.Line2;
            patientAddress.Suburb = patientAddressDto.Suburb;
            patientAddress.City = patientAddressDto.City;
            patientAddress.PostalCode = patientAddressDto.PostalCode;
            patientAddress.ProvinceId = patientAddressDto.ProvinceId;
            patientAddress.CountryId = patientAddressDto.CountryId;

        }

    }
}
