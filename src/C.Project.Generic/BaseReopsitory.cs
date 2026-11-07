using System;
using System.Collections.Generic;
using System.Text;

namespace C.Project.Generic
{
    public class BaseRepository<T, Id> where T : class where Id : struct
    {


        public List<T> entities { get; set; } = new List<T>();

        public void Add(T entity)
        {
            entities.Add(entity);
        }

        public void Remove(T entity)
        {
            entities.Remove(entity);
        }

        public T FindById(Id id)

        {
            // Assuming T has a property named "Id" of type Id

            var propertyInfo = typeof(T).GetProperty("Id") ?? throw new InvalidOperationException($"Type {typeof(T).Name} does not have an Id property.");

          
            

            T? entity = entities.Find(e =>
            {
                var value = propertyInfo.GetValue(e);
                return value is Id entityId && EqualityComparer<Id>.Default.Equals(entityId, id);
            }) ?? throw new Exception("Entity not found");
            
            return entity;
        }
        public List<T> GetAll()
        {
            return entities;
        }
    }
}
