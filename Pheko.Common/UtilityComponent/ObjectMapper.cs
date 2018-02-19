using Pheko.Common.UtilityComponent;

using System;
using System.Reflection;

namespace Pheko.Common.UtilityComponent
{
  public class ObjectMapper
  {
    public static void MapObject<T, K>(T originalObject, K objectToMapTo)
    {
      Type originalType = typeof(T);
      Type objectToMapToType = typeof(K);

      foreach (PropertyInfo propertyInfo in originalType.GetProperties())
      {
        var propertyValue = propertyInfo.GetValue(originalObject, null);
        PropertyInfo objectToMapToProperty = objectToMapToType.GetProperty(propertyInfo.Name);

        if (objectToMapToProperty != null)
        {
          if (Utility.IsNullable(objectToMapToProperty.PropertyType))
          {
            objectToMapToProperty.SetValue(objectToMapTo, Convert.ChangeType(propertyValue, Nullable.GetUnderlyingType(objectToMapToProperty.PropertyType)), null);
          }
          else
          {
            objectToMapToProperty.SetValue(objectToMapTo, Convert.ChangeType(propertyValue, objectToMapToProperty.PropertyType), null);
          }

        }

      }

    }

  }
}
