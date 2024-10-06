
using BirthflowService.Domain.Entities;

namespace BirthflowService.Application.Interfaces
{
    public interface IPartographLogService
    {
        public Task SaveLog<T>(T newEntity, PartographEntity partographEntity, Guid userId);

        public Task SaveLog<T>(T newEntity, T oldEntity, PartographEntity partographEntity, Guid userId);
    }
}
