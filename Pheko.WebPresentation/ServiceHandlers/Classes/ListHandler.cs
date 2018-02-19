using Pheko.WebPresentation.PhekoService;
using Pheko.WebPresentation.ServiceHandlers.Interfaces;

using System.Web.Mvc;

namespace Pheko.WebPresentation.ServiceHandlers.Classes
{
    public class ListHandler: IListHandler
    {
        private PhekoServiceClient _PhekoServiceClient = new PhekoServiceClient();

        public SelectList GetCountries()
        {
            return new SelectList(_PhekoServiceClient.GetCountries(), "CountryId", "CountryName");
        }

        public SelectList GetProvinces()
        {
            return new SelectList(_PhekoServiceClient.GetCountryProvinces(null), "ProvinceId", "ProvinceName");
        }

        public SelectList GetFieldValues(string tableName, string fieldName)
        {
            return new SelectList(_PhekoServiceClient.GetFieldValues(tableName, fieldName), "PropertyValue", "DisplayValue");
        }

        public SelectList GetDoctors()
        {
            return new SelectList(_PhekoServiceClient.GetDoctors(), "DoctorId", "FirstName");
        }
    }
}
