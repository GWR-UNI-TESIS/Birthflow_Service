using BirthflowService.Domain.Interface;

namespace BirthflowService.Application.Services
{
    public class MiddlewareService
    {
        private readonly IAuthRepository _authRepository;

        public MiddlewareService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
    }
}
