using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class FieldValueMapper
    {
        public FieldValueMapper() { }

        public FieldValueDto MapToFieldValueDto(FieldValue fieldValue)
        {
            if (fieldValue == null)
            {
                return null;
            }

            FieldValueDto fieldValueDto = new FieldValueDto();

            fieldValueDto.FieldValueId = fieldValue.FieldValueId;
            fieldValueDto.FieldId = fieldValue.FieldId;
            fieldValueDto.SortOrder = fieldValue.SortOrder;
            fieldValueDto.PropertyValue = fieldValue.PropertyValue;
            fieldValueDto.DisplayValue = fieldValue.DisplayValue;

            return fieldValueDto;
        }

        public FieldValue MapToFieldValue(FieldValueDto fieldValueDto)
        {
            if (fieldValueDto == null)
            {
                return null;
            }

            FieldValue fieldValue = new FieldValue();

            if (fieldValueDto.FieldValueId != null)
            {
                fieldValue.FieldValueId = fieldValueDto.FieldValueId.Value;
            }

            fieldValue.FieldId = fieldValueDto.FieldId;
            fieldValue.SortOrder = fieldValueDto.SortOrder;
            fieldValue.PropertyValue = fieldValueDto.PropertyValue;
            fieldValue.DisplayValue = fieldValueDto.DisplayValue;

            return fieldValue;
        }
    }
}
