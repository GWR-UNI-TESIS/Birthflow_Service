using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace BirthflowService.Infraestructure.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly BirthflowDbContext _context;

        public PasswordRepository(BirthflowDbContext context)
        {
            _context = context;
        }

        public async Task<PasswordEntity?> GetPassword(Guid userId)
        {
            try
            {
                return await _context.Passwords.FirstOrDefaultAsync(u => u.UserId == userId && u.IsCurrent == true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
