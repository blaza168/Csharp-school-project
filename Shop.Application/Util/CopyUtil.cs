using System;
using System.Reflection;

namespace Shop.Application.Util
{
    public static class CopyUtil
    {
        
        /// <summary>Copy not null public attributes from one instance to another</summary>
        /// Can be used for updating entities in database
        ///
        public static void CopyAttributesToInstance<TSource, TResult>(TSource source, TResult result)
        {
            BindingFlags publicBinding = BindingFlags.Public | BindingFlags.Instance;

            foreach (PropertyInfo sourceProp in typeof(TSource).GetProperties(publicBinding))
            {
                PropertyInfo destProp = typeof(TResult).GetProperty(sourceProp.Name);
                object sourceValue = sourceProp.GetValue(source, null);

                if (sourceValue != null)
                {
                    destProp.SetValue(result, sourceValue, null);
                }
            }
        }
        
        /// <summary>Copy not null public attributes from one instance to new instance</summary>
        ///
        public static TResult CopyAttributes<TSource, TResult>(TSource source)
        {
            TResult instance = (TResult) Activator.CreateInstance(typeof(TResult));
            BindingFlags publicBinding = BindingFlags.Public | BindingFlags.Instance;

            foreach (PropertyInfo sourceProp in typeof(TSource).GetProperties(publicBinding))
            {
                PropertyInfo destProp = typeof(TResult).GetProperty(sourceProp.Name);
                object sourceValue = sourceProp.GetValue(source, null);

                if (sourceValue != null)
                {
                    destProp.SetValue(instance, sourceValue, null);
                }
            }

            return instance;
        }
    }
}