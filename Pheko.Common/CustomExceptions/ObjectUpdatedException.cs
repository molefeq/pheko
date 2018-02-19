using System;

namespace Pheko.Common.CustomExceptions
{
   public class ObjectUpdatedException : ArgumentException
   {
      public ObjectUpdatedException(): base("Object inserted exception.")
      {
      }

      public ObjectUpdatedException(string strDatabaseError): base(strDatabaseError)
      {
      }
   }
}