using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;
using Pheko.DataAccess.Repository;

using Pheko.ServicePresentation.EntityManager.Interfaces;
using Pheko.ServicePresentation.MapDtoToEntityObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pheko.ServicePresentation.EntityManager.Classes
{
    public class ListManager : IListManager
    {
        private CountryMapper _CountryMapper = new CountryMapper();
        private ProvinceMapper _ProvinceMapper = new ProvinceMapper();
        private FieldValueMapper _FieldValueMapper = new FieldValueMapper();
        private DoctorMapper _DoctorMapper = new DoctorMapper();

        public List<CountryDto> GetCountries()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.CountryRepository.GetEntities().Select(item => _CountryMapper.MapToCountryDto(item)).ToList<CountryDto>();
            }
        }

        public List<ProvinceDto> GetCountryProvinces(int? countryId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.ProvinceRepository.GetEntities().Select(item => _ProvinceMapper.MapToProvinceDto(item)).ToList<ProvinceDto>();
            }
        }

        public List<FieldValueDto> GetFieldValues(string tableName, string fieldName)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Expression<Func<FieldValue, bool>> filter = fv => fv.Field.FieldName.ToLower() == fieldName.ToLower() && fv.Field.TableName.ToLower() == tableName.ToLower();
                return unitOfWork.FieldValueRepository.GetEntities(filter).Select(item => _FieldValueMapper.MapToFieldValueDto(item)).ToList<FieldValueDto>();
            }
        }

        public List<DoctorDto> GetDoctors()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.DoctorRepository.GetEntities().Select(item => _DoctorMapper.MapToDoctorDto(item)).ToList<DoctorDto>();
            }
        }
    }
}
