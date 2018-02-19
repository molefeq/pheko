using Pheko.Common.UtilityComponent;

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pheko.ServicePresentation.ServiceResponses
{
    [DataContract(Name = "{0}Response")]
    public class Response<T>
    {
        [DataMember]
        public bool HasErrors { get; set; }

        [DataMember]
        public List<FieldError> FieldErrors { get; set; }

        [DataMember]
        public T Model { get; set; }

        public Response()
        {
            FieldErrors = new List<FieldError>();
        }
    }
}
