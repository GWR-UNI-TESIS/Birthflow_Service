using Birthflow_Application.DTOs;
using BirthflowService.Domain.DTOs.Partograph;
using BirthflowService.Domain.Entities;

namespace BirthflowService.Application.Interfaces
{
    public interface IPartographService
    {
        Task<BaseResponse<IEnumerable<PartographEntity>>> GetPartographs(Guid userId);
        Task<BaseResponse<PartographEntity>> GetPartograph(Guid partographId);
        Task<BaseResponse<PartographEntity>> CreatePartograph(PartographDto partographDto);

        // Dilatacion Cervical
        Task<BaseResponse<CervicalDilationEntity>> CreateCervicalDilation(CervicalDilationDto cervicalDilationDto);
        Task<BaseResponse<CervicalDilationEntity>> UpdateCervicalDilation(CervicalDilationDto cervicalDilationDto);
        Task<BaseResponse<CervicalDilationEntity>> DeleteCervicalDilation(CervicalDilationDto cervicalDilationDto);
        Task<BaseResponse<IEnumerable<CervicalDilationEntity>>> GetCervicalDilations(Guid partographId);

        // PRESENTATION POSITION

        Task<BaseResponse<IEnumerable<PresentationPositionVarietyEntity>>> GetAllPresentationPositionVariety();
        Task<BaseResponse<IEnumerable<PresentationPositionVarietyEntity>>> GetPresentationPositionVarietyByParthographId(Guid parthographId);
        Task<BaseResponse<PresentationPositionVarietyEntity>> CreatePresentationPositionVariety(PresentationPositionVarietyDto presentationDto);
        Task<BaseResponse<PresentationPositionVarietyEntity>> UpdatePresentationPositionVariety(PresentationPositionVarietyDto presentationDto);
        Task<BaseResponse<PresentationPositionVarietyEntity>> DeletePresentationPositionVariety(PresentationPositionVarietyDto presentationDto);

        // MEDICAL SURVEILLANCE TABLE

        Task<BaseResponse<MedicalSurveillanceTableEntity>> GetMedicalSurveillanceTableById(int medicalId);
        Task<BaseResponse<IEnumerable<MedicalSurveillanceTableEntity>>> GetMedicalSurveillanceTableByParthographId(Guid parthographId);
        Task<BaseResponse<MedicalSurveillanceTableEntity>> CreateMedicalSurveillanceTable(MedicalSurveillanceTableDTO medicalDto);
        Task<BaseResponse<MedicalSurveillanceTableEntity>> UpdateMedicalSurveillanceTable(MedicalSurveillanceTableDTO medicalDto);
        Task<BaseResponse<MedicalSurveillanceTableEntity>> DeleteMedicalSurveillanceTable(MedicalSurveillanceTableDTO medicalDto);

        Task<BaseResponse<PartographStateEntity>> UpdatePartographState(PartographStateEntity partographStateEntity);
    }
}
