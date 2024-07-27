using Birthflow_Application.DTOs;
using Birthflow_Domain.DTOs.Partographs;
using Birthflow_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthflow_Domain.Interface
{
    public interface IPartographServices
    {
        BaseResponse<IEnumerable<PartographEntity>> GetPartograph(Guid userId);

        BaseResponse<PartographEntity> CreatePartograph(PartographDto partographDto);
    }
}
