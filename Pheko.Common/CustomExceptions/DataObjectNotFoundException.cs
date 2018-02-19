using System;

namespace Pheko.Common.CustomExceptions
{
   public class DataObjectNotFoundException: ArgumentException
   {
      public DataObjectNotFoundException(): base("Object deleted exception.")
      {
      }

      public DataObjectNotFoundException(string strDatabaseError): base(strDatabaseError)
      {
      }
   }
}