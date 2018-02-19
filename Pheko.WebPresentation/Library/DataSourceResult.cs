using System.Collections;

namespace Pheko.WebPresentation.Library
{
    public class DataSourceResult
    {
        public int Total { get; set; }
        public IEnumerable Data { get; set; }
    }
}
