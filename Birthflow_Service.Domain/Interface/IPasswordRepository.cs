using BirthflowService.Domain.Entities;

namespace BirthflowService.Domain.Interface
{
    public interface IPasswordRepository
    {
        public Task<PasswordEntity?> GetPassword(Guid userId);
        public Task CreatePassword(PasswordEntity password);

    }
}
