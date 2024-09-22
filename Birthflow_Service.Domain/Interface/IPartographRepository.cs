using BirthflowService.Domain.Entities;


namespace BirthflowService.Domain.Interface
{
    public interface IPartographRepository
    {
        Task<IEnumerable<PartographEntity>> GetPartographs(Guid userId);
        Task<PartographEntity> GetPartograph(Guid partographId);
        Task<PartographEntity> CreatePartograph(PartographEntity partograph);

        Task<CervicalDilationEntity> CreateCervicalDilation(CervicalDilationEntity cervicalDilation);
        Task<CervicalDilationEntity> UpdateCervicalDilation(CervicalDilationEntity cervicalDilation);
        Task<CervicalDilationEntity> GetCervicalDilation(long id);
        Task<CervicalDilationEntity> DeleteCervicalDilation(long? id, Guid? userId);
        Task<IEnumerable<CervicalDilationEntity>> GetCervicalDilations(Guid partographId);

        // Metodos de Variedad de Posicion Fetal - Planos de Hodge
        Task<IEnumerable<PresentationPositionVarietyEntity>> GetAllPresentationPositionVariety();
        Task<IEnumerable<PresentationPositionVarietyEntity>> GetPresentationPositionVarietyByParthographId(Guid parthographId);
        Task<PresentationPositionVarietyEntity> GetPresentationPositionVarietyById(long presentationId);
        Task<PresentationPositionVarietyEntity> CreatePresentationPositionVariety(PresentationPositionVarietyEntity presentation);
        Task<PresentationPositionVarietyEntity> UpdatePresentationPositionVariety(PresentationPositionVarietyEntity presentation);

        // Metodos de tabla del partograma
        Task<IEnumerable<MedicalSurveillanceTableEntity>> GetAllMedicalSurveillanceTables();
        Task<MedicalSurveillanceTableEntity> GetMedicalSurveillanceTablesById(long medicalId);
        Task<IEnumerable<MedicalSurveillanceTableEntity>> GetMedicalSurveillanceTablesByParthographId(Guid partographId);
        Task<MedicalSurveillanceTableEntity> CreateMedicalSurveillanceTable(MedicalSurveillanceTableEntity medical);
        Task<MedicalSurveillanceTableEntity> UpdateMedicalSurveillanceTable(MedicalSurveillanceTableEntity medical);

        Task<PartographStateEntity> GetPartographStateByUser(Guid partographId, Guid userId);
        Task<PartographStateEntity> UpdatePartographState(PartographStateEntity partographState);
    }
}

