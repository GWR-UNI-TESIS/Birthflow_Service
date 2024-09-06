using BirthflowService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthflowService.Domain.Interface
{
    public interface IAccountRepository
    {
        void saveActivationToken(ActivationTokenEntity token);

        ActivationTokenEntity getActivationToken(string token);
    }
}
