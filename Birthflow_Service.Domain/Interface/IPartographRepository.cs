using BirthflowService.Domain.Entities;

namespace BirthflowService.Domain.Interface
{
    public interface IPartographRepository
    {
        Task<IEnumerable<PartographEntity>> GetPartographs(Guid userId);
        Task<PartographEntity> GetPartograph(Guid partographId);
        Task<PartographEntity> CreatePartograph(PartographEntity partograph);
        Task<PartographEntity> UpdatePartograph(PartographEntity partograph);

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

        //Metodos de la Frecuencia Cardiaca Fetal
        Task<FetalHeartRateEntity> GetFetalHeartRate(long id);
        Task<IEnumerable<FetalHeartRateEntity>> GetFetalHeartRateByParthographId(Guid partographId);
        Task<FetalHeartRateEntity> CreateFetalHeartRate(FetalHeartRateEntity fetalHeartRateEntity);
        Task<FetalHeartRateEntity> UpdateFetalHeartRateTable(FetalHeartRateEntity fetalHeartRateEntity);
        

        //Metodos de Frecuencia Contracciones
        Task<ContractionFrequencyEntity> GetContractionFrequency(long id);
        Task<IEnumerable<ContractionFrequencyEntity>> GetContractionFrequencyByParthographId(Guid partographId);
        Task<ContractionFrequencyEntity> CreateContractionFrequency(ContractionFrequencyEntity contractionFrequencyEntity);
        Task<ContractionFrequencyEntity> UpdateContractionFrequency(ContractionFrequencyEntity contractionFrequencyEntity);


        // Nota de parto
        Task<ChildbirthNoteEntity> GetChildBirthNoteByParthographId(Guid partographId);
        Task<ChildbirthNoteEntity> CreateChildBirthNote(ChildbirthNoteEntity childbirthNote);
        Task<ChildbirthNoteEntity> UpdateChildBirthNote(ChildbirthNoteEntity childbirthNote);


        Task<PartographStateEntity> GetPartographStateByUser(Guid partographId, Guid userId);
        Task<PartographStateEntity> UpdatePartographState(PartographStateEntity partographState);

        List<WorkTimeItemEntity> GetWorkTimeItems(string worktime);
    }
}

