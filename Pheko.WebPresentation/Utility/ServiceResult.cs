using System.Collections.Generic;

namespace Pheko.WebPresentation.Utility
{
    public class ServiceResult<T>
    {
        public List<T> ViewModels { get; set; }
        public List<ModelError> ModelErrors { get; set; }
        public bool IsModelValid { get; set; }

        public ServiceResult()
        {
            ModelErrors = new List<ModelError>();
            ViewModels = new List<T>();
        }
    }
}
