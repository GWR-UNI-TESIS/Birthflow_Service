using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;

namespace BirthflowService.Infraestructure.Repositories
{
    internal class PartographLogRepository : IPartographLogRepository
    {
        private readonly BirthflowDbContext _context;

        public PartographLogRepository(BirthflowDbContext context)
        {
            _context = context;
        }

        public async Task CreateAuditLogs(List<PartographAuditLogEntity> auditLogs)
        {
            try
            {
                await _context.PartographAuditLogs.AddRangeAsync(auditLogs);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PartographVersionEntity> CreatePartographVersion(PartographVersionEntity partographVersion)
        {
            try
            {
                await _context.PartographVersions.AddAsync(partographVersion);
                await _context.SaveChangesAsync();

                return partographVersion;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
