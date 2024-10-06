using BirthflowService.Domain.Entities;

namespace BirthflowService.Domain.Interface
{
    public interface IPartographLogRepository
    {
        Task<PartographVersionEntity> CreatePartographVersion(PartographVersionEntity partographVersion);

        Task CreateAuditLogs(List<PartographAuditLogEntity> auditLogs);
    }
}
