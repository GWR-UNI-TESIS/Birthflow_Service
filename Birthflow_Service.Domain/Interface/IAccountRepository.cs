using BirthflowService.Domain.Entities;

namespace BirthflowService.Domain.Interface
{
    public interface IAccountRepository
    {
        void saveActivationToken(ActivationTokenEntity token);

        ActivationTokenEntity getActivationToken(string token);
    }
}
