using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProjetoFinal
{
    public class ReflectionHelper
    {
        public static List<string> GetTypesAssignableFrom<T>()
        {
            List<string> list = new List<string>();

            foreach (var t in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (typeof(T).IsAssignableFrom(t) && !t.IsInterface)
                {
                    list.Add(t.Name);
                }
            }
            return list;
        }

        public static Type GetTypeByName(string name)
        {
            foreach (var t in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.Name.Equals(name))
                    return t;
            }
            return default;
        }
    }
}