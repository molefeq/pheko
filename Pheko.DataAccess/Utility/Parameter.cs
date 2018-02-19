using Pheko.DataAccess.Enums;

namespace Pheko.DataAccess.Utility
{
    public class Parameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public ParameterType ParameterType { get; set; }
        public int Size { get; set; }
    }
}
