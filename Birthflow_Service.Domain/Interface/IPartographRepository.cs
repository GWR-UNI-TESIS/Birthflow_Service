using Birthflow_Application.DTOs;
using BirthflowService.Domain.DTOs.Partograph;
using BirthflowService.Domain.Entities;


namespace BirthflowService.Domain.Interface
{
    public interface IPartographRepository
    {
        BaseResponse<IEnumerable<PartographEntity>> GetPartographs(Guid userId);
        BaseResponse<PartographEntity> GetPartograph(Guid partographId);
        BaseResponse<PartographEntity> CreatePartograph(PartographDto partographDto);

        BaseResponse<CervicalDilationEntity> CreateCervicalDilation(CervicalDilationDto cervicalDilationDto);
        BaseResponse<CervicalDilationEntity> UpdateCervicalDilation(CervicalDilationDto cervicalDilationDto);
        BaseResponse<CervicalDilationEntity> DeleteCervicalDilation(int? id, Guid? userId);
        BaseResponse<IEnumerable<CervicalDilationEntity>> GetCervicalDilations(Guid partographId);

        // Metodos de Variedad de Posicion Fetal - Planos de Hodge
        BaseResponse<List<PresentationPositionVarietyEntity>> GetAllPresentationPositionVariety();
        BaseResponse<List<PresentationPositionVarietyEntity>> GetPresentationPositionVarietyByParthographId(Guid parthographId);
        BaseResponse<PresentationPositionVarietyEntity> GetPresentationPositionVarietyById(int presentationId);
        BaseResponse<PresentationPositionVarietyEntity> CreatePresentationPositionVariety(PresentationPositionVarietyEntity presentation);
        BaseResponse<PresentationPositionVarietyEntity> UpdatePresentationPositionVariety(PresentationPositionVarietyEntity presentation);

        // Metodos de tabla del partograma
        BaseResponse<List<MedicalSurveillanceTableEntity>> GetAllMedicalSurveillanceTables();
        BaseResponse<MedicalSurveillanceTableEntity> GetMedicalSurveillanceTablesById(int medicalId);
        BaseResponse<List<MedicalSurveillanceTableEntity>> GetMedicalSurveillanceTablesByParthographId(Guid parthographId);
        BaseResponse<MedicalSurveillanceTableEntity> CreateMedicalSurveillanceTable(MedicalSurveillanceTableEntity medical);
        BaseResponse<MedicalSurveillanceTableEntity> UpdateMedicalSurveillanceTable(MedicalSurveillanceTableEntity medical);
    }
}
