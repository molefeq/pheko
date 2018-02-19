using System;

namespace Pheko.Common.CustomExceptions
{
   public class BindException : ArgumentException
   {
      public BindException() : base("Binding error.")
      {
      }

      public BindException(string strBindError) : base(strBindError)
      {
      }
   }
}