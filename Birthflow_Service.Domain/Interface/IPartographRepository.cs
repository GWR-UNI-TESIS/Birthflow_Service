using Birthflow_Application.DTOs;
using BirthflowService.Domain.DTOs.Partograph;
using BirthflowService.Domain.Entities;


namespace BirthflowService.Domain.Interface
{
    public interface IPartographRepository
    {
        BaseResponse<IEnumerable<PartographEntity>> GetPartograph(Guid userId);
        BaseResponse<PartographEntity> CreatePartograph(PartographDto partographDto);
        BaseResponse<CervicalDilationEntity> CreateCervicalDilation(CervicalDilationDto cervicalDilationDto);
        BaseResponse<CervicalDilationEntity> UpdateCervicalDilation(CervicalDilationDto cervicalDilationDto);
        BaseResponse<CervicalDilationEntity> DeleteCervicalDilation(int? id, Guid? userId);
        BaseResponse<IEnumerable<CervicalDilationEntity>> GetCervicalDilations(Guid partographId);
    }
}
