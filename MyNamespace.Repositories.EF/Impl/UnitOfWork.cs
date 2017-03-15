using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNamespace.Repositories.Contracts;

namespace MyNamespace.Repositories.EF.Impl
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly Entities _dbContext;

        public UnitOfWork()
        {
            _dbContext= new Entities();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
