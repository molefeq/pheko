using System.Collections.Generic;

namespace Pheko.WebPresentation.Utility
{
    public class ServiceResponse<T>
    {
        public T ViewModel { get; set; }
        public List<ModelError> ModelErrors { get; set; }
        public bool IsModelValid { get; set; }

        public ServiceResponse()
        {
            ModelErrors = new List<ModelError>();
        }
    }
}
