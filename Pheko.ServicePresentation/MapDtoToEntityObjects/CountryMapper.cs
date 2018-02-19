using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class CountryMapper
    {
        public CountryMapper() { }

        public CountryDto MapToCountryDto(Country country)
        {
            if (country == null)
            {
                return null;
            }

            CountryDto countryDto = new CountryDto();

            countryDto.CountryId = country.CountryId;
            countryDto.CountryCode = country.CountryCode;
            countryDto.CountryName = country.CountryName;

            return countryDto;
        }

        public Country MapToCountry(CountryDto countryDto)
        {
            if (countryDto == null)
            {
                return null;
            }

            Country country = new Country();

            if (countryDto.CountryId != null)
            {
                country.CountryId = countryDto.CountryId.Value;
            }

            country.CountryCode = countryDto.CountryCode;
            country.CountryName = countryDto.CountryName;

            return country;
        }
          
    }
}
