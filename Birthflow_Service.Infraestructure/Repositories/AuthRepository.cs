using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowMicroServices.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Infraestructure.Repositories
{
    public class AuthRepository
    {
        private readonly BirthflowDbContext _context;

        public AuthRepository(BirthflowDbContext context)
        {
          _context = context;
        }
    }
}
