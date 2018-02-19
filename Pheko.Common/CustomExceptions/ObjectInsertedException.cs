using System;

namespace Pheko.Common.CustomExceptions
{
   public class ObjectInsertedException: ArgumentException
   {
      public ObjectInsertedException(): base("Object inserted exception.")
      {
      }

      public ObjectInsertedException(string strDatabaseError): base(strDatabaseError)
      {
      }
   }
}