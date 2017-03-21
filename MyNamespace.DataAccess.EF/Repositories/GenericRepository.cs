using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using MyNamespace.DataAccess.Contracts.Repositories;
using MyNamespace.DataAccess.Model;

namespace MyNamespace.DataAccess.EF.Repositories
{
    class GenericRepository<T>: IGenericRepository<T> where T:BaseModel
    {
        public GenericRepository(Entities dbContext)
        {
            this.DbContext = dbContext;
        }

        protected Entities DbContext;

        public T Get(object id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }

        public void Delete(T obj)
        {
            DbContext.Set<T>().Remove(obj);
        }

        public void Add(T obj)
        {
            var objContext = ((IObjectContextAdapter)DbContext).ObjectContext;
            var objSet = objContext.CreateObjectSet<T>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, obj);

            //var val = entityKey.EntityKeyValues.First().Value;
            Object foundEntity;
            // TryGetObjectByKey attaches a found entity
            var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);
            /*
             * But Attach and SaveChanges won't save any changes because attaching leaves the entity in state Unchanged. 
             * You must set the state to Modified after Attach. But this is ineffective since all columns will be updated 
             * no matter if they really did change. To avoid this you have to load the original into the context and apply 
             * the changes on property level. But then you don't need Exists since it would only cause to load the entity twice. 
             * And what will you do when entity has navigation properties and related objects have to be updated or not? 
             * I have doubt in a generic Save approach
             */

            if (obj != null)
            {
                
                if (obj.Id!=0)
                {
                    DbContext.Set<T>().Attach(obj);
                    DbContext.Entry(obj).State = EntityState.Modified;
                }
                else
                {
                    DbContext.Set<T>().Add(obj);
                }

            }


            ////1. If you are working with attached object (object loaded from the same instance of the context) you can simply use:
            //if (context.ObjectStateManager.GetObjectStateEntry(myEntity).State == EntityState.Detached)
            //{
            //    context.MyEntities.AddObject(myEntity);
            //}
            //// Attached object tracks modifications automatically
            //context.SaveChanges();

            ////2. If you can use any knowledge about the object's key you can use something like this:
            //if (myEntity.Id != 0)
            //{
            //    context.MyEntities.Attach(myEntity);
            //    context.ObjectStateManager.ChangeObjectState(myEntity, EntityState.Modified);
            //}
            //else
            //{
            //    context.MyEntities.AddObject(myEntity);
            //}
            //context.SaveChanges();

            ////3. If you can't decide existance of the object by its Id you must exectue lookup query:
            //var id = myEntity.Id;
            //if (context.MyEntities.Any(e => e.Id == id))
            //{
            //    context.MyEntities.Attach(myEntity);
            //    context.ObjectStateManager.ChangeObjectState(myEntity, EntityState.Modified);
            //}
            //else
            //{
            //    context.MyEntities.AddObject(myEntity);
            //}
            //context.SaveChanges();
        }
    }
}
