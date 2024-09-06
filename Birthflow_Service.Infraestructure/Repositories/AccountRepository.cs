using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Infraestructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BirthflowDbContext _context;

        public AccountRepository(BirthflowDbContext context) { 
            _context = context;
        }

        public ActivationTokenEntity getActivationToken(string token)
        {
           return _context.ActivationTokenEntities.FirstOrDefault(u => u.Value == token)!;
        }

        public void saveActivationToken(ActivationTokenEntity token)
        {
            try
            {
                _context.ActivationTokenEntities.Add(token);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
