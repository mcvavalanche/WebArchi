using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using MyNamespace.DataAccess.Contracts.Repositories;
using MyNamespace.DataAccess.Model;

namespace MyNamespace.DataAccess.EF.Repositories
{
    class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected Entities DbContext;
        public GenericRepository(Entities dbContext)
        {
            this.DbContext = dbContext;
        }

        public virtual T Get(object id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }

        public virtual void Delete(T obj)
        {
            DbContext.Set<T>().Remove(obj);
        }

        public virtual void Add(T obj)
        {
            if (obj != null)
            {
                if (IsNew(obj)) 
                {
                    //insert
                    DbContext.Set<T>().Add(obj);
                }
                else 
                {
                    //update
                    DbContext.Set<T>().Attach(obj);
                    DbContext.Entry(obj).State = EntityState.Modified;
                }
            }
        }

        /// <summary>
        /// Supports only a simple PK of type int.
        /// If the value of the PK is 0 then returns true, otherwise false.
        /// No checks are done in the database so if the PK > 0 but the object does not exist in the database this will still 
        /// return false wich may cause the Add method to fail as it will try to update.
        /// If the entity has a composed PK or a PK that is not int, it will throw an InvalidOperationException. For these scenarios 
        /// it is best to override it in the specific repo.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual bool IsNew(T obj)
        {
            var objContext = ((IObjectContextAdapter)DbContext).ObjectContext;
            var objSet = objContext.CreateObjectSet<T>();
            if (objSet.EntitySet.ElementType.KeyMembers.Count != 1)
            {
                throw new InvalidOperationException("Composed primary keys are not supported. You must override the IsNew method.");
            }
            var key = objSet.EntitySet.ElementType.KeyMembers[0];
            var val = typeof(T).GetProperty(key.Name).GetValue(obj);
            if (val != null)
            {
                if (val is int)
                {
                    return (int)val == 0;
                }
                else
                {
                    throw new InvalidOperationException("Only int primary keys are supported. You must override the IsNew method.");
                }
            }
            return true;
        }
    }
}
