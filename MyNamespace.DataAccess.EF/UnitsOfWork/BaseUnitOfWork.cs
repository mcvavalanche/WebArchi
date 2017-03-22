using System.Threading.Tasks;
using MyNamespace.DataAccess.Contracts.UnitsOfWork;

namespace MyNamespace.DataAccess.EF.UnitsOfWork
{
    public class BaseUnitOfWork:IBaseUnitOfWork
    {
        protected Entities DbContext { get; private set; }

        protected BaseUnitOfWork(Entities context)
        {
            DbContext = context;
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }


        public Task GetRepository<T>()
        {
            return null;
        }
    }
}
