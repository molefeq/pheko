using System;

namespace Pheko.Common.CustomExceptions
{
   public class ObjectDeletedException: ArgumentException
   {
      public ObjectDeletedException(): base("Object deleted exception.")
      {
      }

      public ObjectDeletedException(string strDatabaseError): base(strDatabaseError)
      {
      }
   }
}