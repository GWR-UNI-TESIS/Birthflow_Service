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
        Task<BaseResponse<PartographEntity>> UpdatePartograph(PartographDto partographDto);
        Task<BaseResponse<PartographEntity>> DeletePartograph(Guid partographId);

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
        Task<BaseResponse<MedicalSurveillanceTableEntity>> CreateMedicalSurveillanceTable(MedicalSurveillanceTableDto medicalDto);
        Task<BaseResponse<MedicalSurveillanceTableEntity>> UpdateMedicalSurveillanceTable(MedicalSurveillanceTableDto medicalDto);
        Task<BaseResponse<MedicalSurveillanceTableEntity>> DeleteMedicalSurveillanceTable(MedicalSurveillanceTableDto medicalDto);


        Task<BaseResponse<FetalHeartRateEntity>> GetFetalHeartRate(long id);
        Task<BaseResponse<IEnumerable<FetalHeartRateEntity>>> GetFetalHeartRateByParthographId(Guid partographId);
        Task<BaseResponse<FetalHeartRateEntity>> CreateFetalHeartRate(FetalHeartRateDto fetalHeartRateDto);
        Task<BaseResponse<FetalHeartRateEntity>> UpdateFetalHeartRateTable(FetalHeartRateDto fetalHeartRateDto);


        //Metodos de Frecuencia Contracciones
        Task<BaseResponse<ContractionFrequencyEntity>> GetContractionFrequency(long id);
        Task<BaseResponse<IEnumerable<ContractionFrequencyEntity>>> GetContractionFrequencyByParthographId(Guid partographId);
        Task<BaseResponse<ContractionFrequencyEntity>> CreateContractionFrequency(ContractionFrequencyDto contractionFrequencyDto);
        Task<BaseResponse<ContractionFrequencyEntity>> UpdateContractionFrequency(ContractionFrequencyDto contractionFrequencyDto);


        // Nota de parto
        Task<BaseResponse<ChildbirthNoteEntity>> GetChildBirthNoteByParthographId(Guid partographId);
        Task<BaseResponse<ChildbirthNoteEntity>> CreateChildBirthNote(ChildbirthNoteDto childbirthNote);
        Task<BaseResponse<ChildbirthNoteEntity>> UpdateChildBirthNote(ChildbirthNoteDto childbirthNote);

        Task<BaseResponse<PartographStateEntity>> GetPartographStateByUser(Guid partographId, Guid userId);
        Task<BaseResponse<PartographStateEntity>> UpdatePartographState(PartographStateEntity partographStateEntity);
    }
}
