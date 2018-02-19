using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pheko.ServicePresentation.ServiceResponses
{
    [DataContract(Name = "{0}Result")]
    public class Result<T>
    {
        [DataMember]
        public int Total { get; set; }

        [DataMember]
        public List<T> Models { get; set; }

        public Result()
        {
            Models = new List<T>();
        }
    }
}
