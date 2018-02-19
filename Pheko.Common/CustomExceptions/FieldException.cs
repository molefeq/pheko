using System;

namespace Pheko.Common.CustomExceptions
{
    public class FieldException : ArgumentException
    {
        public FieldException()
            : base("Binding error.")
        {
        }

        public FieldException(string strBindError)
            : base(strBindError)
        {

        }
    }

}