using System;

namespace Drafter.Extenstions
{
    public static class ObjectExtensions
    {
        public static object SetPropertyInline(this object Object, string propertyName, object value)
        {
            Object.GetType()
                  .GetProperty(propertyName)
                  .SetValue(Object, value);
            return Object;
        }
    }
}
