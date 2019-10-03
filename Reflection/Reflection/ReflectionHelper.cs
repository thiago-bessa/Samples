using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bessa.Reflection
{
    public static class ReflectionHelper
    {
        public static List<Type> GetAllClassesWithInterface<T>() where T : class
        {
            return Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(t => typeof(T).IsAssignableFrom(t) && !(typeof(T) == t))
                .ToList();
        }
    }
}
