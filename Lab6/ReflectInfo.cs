using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lab6
{
    public static class ReflectInfoExt
    {
        public static string MethodInfo<T>(this T obj) where T : class
        {
            var result = new StringBuilder();
            
            result.Append($"*** Список методов класса {obj} ***\n");

            foreach (var m in typeof(T).GetMethods())
            {
                result.Append(" --> " + m.ReturnType.Name + " \t" + m.Name + "(");
                var p = m.GetParameters();
                for (var i = 0; i < p.Length; i++)
                {
                    result.Append(p[i].ParameterType.Name + " " + p[i].Name);
                    if (i + 1 < p.Length) result.Append(", ");
                }
                result.Append(")\n");
            }

            return result.ToString();
        }
        public static string ConstructorInfo<T>(this T obj) where T : class
        {
            var result = new StringBuilder();

            result.Append($"*** Список конструкторов класса {obj} ***\n");

            foreach (var c in typeof(T).GetConstructors())
            {
                result.Append("--> " + c.Name + "(");
                var p = c.GetParameters();
                for (var i = 0; i < p.Length; i++)
                {
                    result.Append(p[i].ParameterType.Name + " " + p[i].Name);
                    if (i + 1 < p.Length) result.Append(", ");
                }
                result.Append(")\n");
            }

            return result.ToString();
        }
        public static string PropertyInfo<T>(this T obj) where T : class
        {
            var result = new StringBuilder();

            result.Append($"*** Список свойств класса {obj} ***\n");
            
            foreach (var prop in typeof(T).GetProperties())
            {
                result.Append($"--> {prop.PropertyType.Name} \t{prop.Name}\n");
            }

            return result.ToString();
        }

        public static string OutputProperties<T>(this T obj) where T : class
        {
            var result = new StringBuilder();

            foreach (var prop in typeof(T).GetProperties())
            {
                if (((UInfoAttribute[])prop.GetCustomAttributes(typeof(UInfoAttribute), false)).Length != 0)
                {
                    result.Append($"--> {prop.PropertyType.Name} \t{prop.Name}\n");
                }
            }

            return result.ToString();
        }

        public static void СallSomeMethod<T>(this T obj) where T : class
        {
            var method = obj.GetType().GetMethod("SomeMethod");
            method?.Invoke(obj, null);
        }
    }
}