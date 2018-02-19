using Pheko.Common.DataTransformObjects;

using System.Collections.Generic;

namespace Pheko.ServicePresentation.EntityManager.Interfaces
{
    public interface IListManager
    {
        List<CountryDto> GetCountries();

        List<ProvinceDto> GetCountryProvinces(int? countryId);

        List<FieldValueDto> GetFieldValues(string tableName, string fieldName);

        List<DoctorDto> GetDoctors();
    }
}
