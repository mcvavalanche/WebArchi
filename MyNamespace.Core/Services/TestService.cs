using MyNamespace.DataAccess.Contracts.Repositories;
using MyNamespace.DataAccess.Contracts.UnitsOfWork;

namespace MyNamespace.Core.Services
{
    public interface ITestService
    {
    
    }
    public class TestService: ITestService
    {
        private readonly IBaseUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public TestService(IBaseUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
    }
}
