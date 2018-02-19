using System;

namespace Pheko.Common.CustomExceptions
{
   public class ObjectFetchedException: ApplicationException
   {
      public ObjectFetchedException(): base("Object fetched exception.")
      {
      }

      public ObjectFetchedException(string strDatabaseError): base(strDatabaseError)
      {
      }
   }
}