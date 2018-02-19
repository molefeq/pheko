
namespace Pheko.Common.DataTransformObjects
{
    public class PatientAddressDto
    {
        public int? PatientAddressId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? ProvinceId { get; set; }
        public int? CountryId { get; set; }
    }
}
