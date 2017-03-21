using System.Threading.Tasks;

namespace MyNamespace.DataAccess.Contracts.UnitsOfWork
{
    public interface IBaseUnitOfWork
    {
        Task SaveAsync();
        void Save();
    }
}
