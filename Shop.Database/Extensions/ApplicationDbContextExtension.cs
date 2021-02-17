using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Shop.Database.Extensions
{
    public static class ApplicationDbContextExtension
    {
        /// <summary>
        /// Same as .Update, but it updates only fields that are not null
        /// For now, this function works only for primitive values.
        /// </summary>
        /// <param name="this"></param>
        /// <param name="entity"></param>
        /// <typeparam name="T"></typeparam>
        public static void PartialUpdate<T>(this ApplicationDbContext @this, T entity)
        {
            @this.Attach(entity);

            IEnumerable<PropertyInfo> primaryKeys = @this.GetPrimaryKeys(entity);
            
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                object value = propertyInfo.GetValue(entity, null);
                if (value != null && primaryKeys.All(x => x.Name != propertyInfo.Name))
                {
                    @this.Entry(entity).Property(propertyInfo.Name).IsModified = true;
                }
            }
        }

        private static ICollection<PropertyInfo> GetPrimaryKeys<T>(this ApplicationDbContext @this, T entity)
        {
            var entry = @this.Entry(entity);
            return entry.Metadata.FindPrimaryKey().Properties.Select(x => x.PropertyInfo).ToList();
        }
    }
}