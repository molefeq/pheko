using System.Web.Mvc;

namespace Pheko.WebPresentation.ServiceHandlers.Interfaces
{
    public interface IListHandler
    {
        SelectList GetCountries();

        SelectList GetProvinces();

        SelectList GetFieldValues(string tableName, string fieldName);

        SelectList GetDoctors();
    }
}
