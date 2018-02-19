
namespace Pheko.Common.DataTransformObjects
{
    public class FieldValueDto
    {
        public int? FieldValueId { get; set; }
        public int FieldId { get; set; }
        public int? SortOrder { get; set; }
        public string PropertyValue { get; set; }
        public string DisplayValue { get; set; }
    }
}
