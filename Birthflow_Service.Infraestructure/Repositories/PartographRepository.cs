using Birthflow_Service.Infraestructure.DbContexts;
using BirthflowService.Domain.Entities;
using BirthflowService.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BirthflowService.Infraestructure.Repositories
{
    public class PartographRepository : IPartographRepository
    {
        private readonly BirthflowDbContext _context;
        private readonly ILogger<PartographRepository> _logger;

        public PartographRepository(BirthflowDbContext _context, ILogger<PartographRepository> logger)
        {
            this._context = _context;
            _logger = logger;
        }

        public async Task<PartographEntity> CreatePartograph(PartographEntity partographEntity)
        {
            try
            {
                var partographState = new PartographStateEntity()
                {
                    PartographId = partographEntity.PartographId,
                    UserId = (Guid)partographEntity.CreatedBy!,
                    IsAchived = false,
                    Set = false,
                    Silenced = false,
                    Favorite = false,
                };

                await _context.Partographs.AddAsync(partographEntity);
                await _context.PartographStateEntities.AddAsync(partographState);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Partograma creado correctamente");
                return partographEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el partograma");
                throw;
            }
        }

        public async Task<PartographEntity> UpdatePartograph(PartographEntity partographEntity)
        {
            try
            {
                _logger.LogInformation($"Actualizando partograma con ID {partographEntity.PartographId}");
                _context.Partographs.Update(partographEntity);

                await _context.SaveChangesAsync();

                _logger.LogInformation("Partograma modificado correctamente");
                return partographEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al modificar el partograma");
                throw;
            }
        }
        public async Task<IEnumerable<PartographEntity>> GetPartographs(Guid userId)
        {
            try
            {
                _logger.LogInformation($"Obteniendo partogramas para el usuario {userId}");

                var result = await _context.Partographs
                .Include(p => p.PartographStateEntities)
                .Where(p => p.CreatedBy == userId && p.IsDelete == false &&
                            p.PartographStateEntities.Any(state => state.UserId == userId))
                .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los partogramas");
                throw;
            }
        }

        public async Task<PartographEntity> GetPartograph(Guid partographId)
        {
            try
            {
                _logger.LogInformation($"Obteniendo partograma con ID {partographId}");

                var result = await _context.Partographs
                  .Include(p => p.CervicalDilationEntities.OrderBy(cd => cd.CreateAt))
                  .FirstOrDefaultAsync(p => p.PartographId == partographId && p.IsDelete != true);

                if (result == null)
                {
                    _logger.LogWarning($"Partograma con ID {partographId} no encontrado");
                }

                return result!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el partograma");
                throw;
            }
        }

        public async Task<CervicalDilationEntity> CreateCervicalDilation(CervicalDilationEntity cervicalDilationEntity)
        {
            try
            {
                _logger.LogInformation("Creando dilatación cervical");
                await _context.CervicalDilations.AddAsync(cervicalDilationEntity);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Dilatación cervical creada correctamente");
                return cervicalDilationEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la dilatación cervical");
                throw;
            }
        }

        public async Task<CervicalDilationEntity> DeleteCervicalDilation(long? id, Guid? userId)
        {
            try
            {
                var cervicalDilation = await _context.CervicalDilations.FindAsync(id);

                if (cervicalDilation == null)
                {
                    _logger.LogWarning($"Dilatación cervical con ID {id} no encontrada");
                    return null!;
                }

                cervicalDilation.IsDelete = true;
                cervicalDilation.DeleteBy = userId;
                cervicalDilation.DeleteAt = DateTime.Now;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Dilatación cervical eliminada correctamente");
                return cervicalDilation;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la dilatación cervical");
                throw;
            }
        }

        public async Task<IEnumerable<CervicalDilationEntity>> GetCervicalDilations(Guid partographId)
        {
            try
            {
                _logger.LogInformation($"Buscando dilataciones cervicales para el partograma {partographId}");

                var result = await _context.CervicalDilations
                    .Where(e => e.PartographId == partographId && !e.IsDelete)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las dilataciones cervicales");
                throw;
            }
        }

        public async Task<CervicalDilationEntity> GetCervicalDilation(long id)
        {
            try
            {
                _logger.LogInformation($"Buscando dilatacion cervical con el partograma {id}");

                var result = await _context.CervicalDilations.FindAsync(id);

                return result!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las dilataciones cervicales");
                throw;
            }
        }

        public async Task<CervicalDilationEntity> UpdateCervicalDilation(CervicalDilationEntity cervicalDilationEntity)
        {
            try
            {
                _logger.LogInformation($"Actualizando dilatacion cervical con ID {cervicalDilationEntity.Id}");
                _context.CervicalDilations.Update(cervicalDilationEntity);

                await _context.SaveChangesAsync();

                _logger.LogInformation("Dilatación cervical actualizada correctamente");
                return cervicalDilationEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la dilatación cervical");
                throw;
            }
        }

        //Metodos de variedad de posicion fetal - plano de hodge
        public async Task<IEnumerable<PresentationPositionVarietyEntity>> GetAllPresentationPositionVariety()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las variedades de posición de presentación");
                var result = await _context.PresentationPositionVarietyEntities.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las variedades de posición de presentación");
                throw;
            }
        }

        public async Task<IEnumerable<PresentationPositionVarietyEntity>> GetPresentationPositionVarietyByParthographId(Guid partographId)
        {
            try
            {
                _logger.LogInformation($"Obteniendo variedades de posición de presentación para el partograma {partographId}");
                var result = await _context.PresentationPositionVarietyEntities
                    .Where(ppv => ppv.PartographId == partographId)
                    .ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener las variedades de posición de presentación para el partograma {partographId}");
                throw;
            }
        }

        public async Task<PresentationPositionVarietyEntity> GetPresentationPositionVarietyById(long presentationId)
        {
            try
            {
                _logger.LogInformation($"Buscando variedad de posición de presentación con ID {presentationId}");
                var result = await _context.PresentationPositionVarietyEntities.FirstOrDefaultAsync(ppv => ppv.Id == presentationId);
                return result!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al buscar variedad de posición de presentación con ID {presentationId}");
                throw;
            }
        }

        public async Task<PresentationPositionVarietyEntity> CreatePresentationPositionVariety(PresentationPositionVarietyEntity presentation)
        {
            try
            {
                _logger.LogInformation("Creando una nueva variedad de posición de presentación");
                await _context.PresentationPositionVarietyEntities.AddAsync(presentation);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Variedad de posición de presentación creada correctamente");
                return presentation;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la variedad de posición de presentación");
                throw;
            }
        }

        public async Task<PresentationPositionVarietyEntity> UpdatePresentationPositionVariety(PresentationPositionVarietyEntity presentation)
        {
            try
            {
                _logger.LogInformation($"Actualizando variedad de posición de presentación con ID {presentation.Id}");
                _context.PresentationPositionVarietyEntities.Update(presentation);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Variedad de posición de presentación actualizada correctamente");
                return presentation;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar la variedad de posición de presentación con ID {presentation.Id}");
                throw;
            }
        }

        public async Task<IEnumerable<MedicalSurveillanceTableEntity>> GetAllMedicalSurveillanceTables()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las tablas de vigilancia médica");
                var result = await _context.MedicalSurveillanceTables.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las tablas de vigilancia médica");
                throw;
            }
        }

        public async Task<MedicalSurveillanceTableEntity> GetMedicalSurveillanceTablesById(long medicalId)
        {
            try
            {
                _logger.LogInformation($"Buscando tabla de vigilancia médica con ID {medicalId}");
                var result = await _context.MedicalSurveillanceTables.FirstOrDefaultAsync(mst => mst.Id == medicalId);
                return result!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al buscar la tabla de vigilancia médica con ID {medicalId}");
                throw;
            }
        }

        public async Task<IEnumerable<MedicalSurveillanceTableEntity>> GetMedicalSurveillanceTablesByParthographId(Guid partograph)
        {
            try
            {
                _logger.LogInformation($"Buscando tabla de vigilancia médica con partograma ID {partograph}");
                var result = await _context.MedicalSurveillanceTables.Where(mst => mst.PartographId == partograph).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al buscar la tabla de vigilancia médica con partograma {partograph}");
                throw;
            }
        }

        public async Task<MedicalSurveillanceTableEntity> CreateMedicalSurveillanceTable(MedicalSurveillanceTableEntity medical)
        {
            try
            {
                _logger.LogInformation("Creando nueva tabla de vigilancia médica");
                await _context.MedicalSurveillanceTables.AddAsync(medical);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Tabla de vigilancia médica creada correctamente");
                return medical;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la tabla de vigilancia médica");
                throw;
            }
        }

        public async Task<MedicalSurveillanceTableEntity> UpdateMedicalSurveillanceTable(MedicalSurveillanceTableEntity medical)
        {
            try
            {
                _logger.LogInformation($"Actualizando tabla de vigilancia médica con ID {medical.Id}");
                _context.MedicalSurveillanceTables.Update(medical);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Tabla de vigilancia médica actualizada correctamente");
                return medical;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar la tabla de vigilancia médica con ID {medical.Id}");
                throw;
            }
        }

        public async Task<PartographStateEntity> GetPartographStateByUser(Guid partographId, Guid userId)
        {
            try
            {
                _logger.LogInformation($"Obteniendo estado de partograma con ID {userId}");

                var result = await _context.PartographStateEntities.FirstOrDefaultAsync(ps => ps.UserId == userId && ps.PartographId == partographId);

                if (result == null)
                {
                    _logger.LogWarning($"Estado de partograma con ID {partographId} no encontrada");
                    return null!;
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al encontrar el estado del partograma con ID {partographId} del usuario {userId}");
                throw;
            }
        }

        public async Task<PartographStateEntity> UpdatePartographState(PartographStateEntity partographState)
        {
            try
            {
                _logger.LogInformation($"Actualizando tabla de estados del partograma con ID {partographState.Id}");
                _context.PartographStateEntities.Update(partographState);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Tabla de estados del partograma actualizada correctamente");
                return partographState;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar la tabla de estados del partograma con ID {partographState.Id}");
                throw;
            }
        }

        public async Task<FetalHeartRateEntity> GetFetalHeartRate(long id)
        {
            try
            {
                _logger.LogInformation($"Buscando Frecuencia cardíaca fetal con el Id: {id}");

                var result = await _context.FetalHeartRateEntities.FindAsync(id);

                return result!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las Frecuencia cardíaca fetal");
                throw;
            }
        }

        public async Task<IEnumerable<FetalHeartRateEntity>> GetFetalHeartRateByParthographId(Guid partographId)
        {
            try
            {
                _logger.LogInformation($"Buscando las Frecuencia cardíaca fetal con el partograma: {partographId}");

                var result = await _context.FetalHeartRateEntities.Where(e => e.PartographId == partographId && !e.IsDelete)
                    .ToListAsync();

                return result!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las Frecuencia cardíaca fetal");
                throw;
            }
        }

        public async Task<FetalHeartRateEntity> CreateFetalHeartRate(FetalHeartRateEntity fetalHeartRateEntity)
        {
            try
            {
                _logger.LogInformation("Creando Frecuencia cardíaca fetal");
                await _context.FetalHeartRateEntities.AddAsync(fetalHeartRateEntity);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Frecuencia cardíaca fetal creada correctamente");
                return fetalHeartRateEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la Frecuencia cardíaca fetal");
                throw;
            }
        }

        public async Task<FetalHeartRateEntity> UpdateFetalHeartRateTable(FetalHeartRateEntity fetalHeartRateEntity)
        {
            try
            {
                _logger.LogInformation("Modificando Frecuencia cardíaca fetal");
                _context.FetalHeartRateEntities.Update(fetalHeartRateEntity);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Frecuencia cardíaca fetal modificada correctamente");
                return fetalHeartRateEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al modificar la Frecuencia cardíaca fetal");
                throw;
            }
        }

        public async Task<ContractionFrequencyEntity> GetContractionFrequency(long id)
        {
            try
            {
                _logger.LogInformation($"Buscando Frecuencia de contracciones con el Id: {id}");

                var result = await _context.ContractionFrequencyEntities.FindAsync(id);

                return result!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las Frecuencia de contracciones");
                throw;
            }
        }

        public async Task<IEnumerable<ContractionFrequencyEntity>> GetContractionFrequencyByParthographId(Guid partographId)
        {
            try
            {
                _logger.LogInformation("Buscando las Frecuencia de contracciones");
                var result = await _context.ContractionFrequencyEntities.Where(e => e.PartographId == partographId && !e.IsDelete)
                    .ToListAsync(); 
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar las Frecuencia de contracciones");
                throw;
            }
        }

        public async Task<ContractionFrequencyEntity> CreateContractionFrequency(ContractionFrequencyEntity contractionFrequency)
        {
            try
            {
                _logger.LogInformation("Creando Frecuencia de contracciones");
                await _context.ContractionFrequencyEntities.AddAsync(contractionFrequency);
                await _context.SaveChangesAsync();

                _logger.LogInformation(" Frecuencia de contracciones creada correctamente");
                return contractionFrequency;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la  Frecuencia de contracciones");
                throw;
            }
        }

        public async Task<ContractionFrequencyEntity> UpdateContractionFrequency(ContractionFrequencyEntity contractionFrequency)
        {
            try
            {
                _logger.LogInformation("Modificando Frecuencia de contracciones");
                _context.ContractionFrequencyEntities.Update(contractionFrequency);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Frecuencia de contracciones modificada correctamente");
                return contractionFrequency;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al modificar la Frecuencia contracciones");
                throw;
            }
        }

        public async Task<ChildbirthNoteEntity> GetChildBirthNoteByParthographId(Guid partographId)
        {
            try
            {
                _logger.LogInformation("Buscando Nota de parto");
                var result = await _context.ChildbirthNotes.FirstAsync(e => e.PartographId == partographId);

                return result!;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar la Nota de parto");
                throw;
            }
        }

        public async Task<ChildbirthNoteEntity> CreateChildBirthNote(ChildbirthNoteEntity childbirthNote)
        {
            try
            {
                _logger.LogInformation("Creando Nota de parto");
                await _context.ChildbirthNotes.AddAsync(childbirthNote);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Nota de parto creada correctamente");
                return childbirthNote;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la Nota de parto");
                throw;
            }
        }

        public async Task<ChildbirthNoteEntity> UpdateChildBirthNote(ChildbirthNoteEntity childbirthNote)
        {
            try
            {
                _logger.LogInformation("Modificando Nota de parto");
                _context.ChildbirthNotes.Update(childbirthNote);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Nota de parto modificada correctamente");
                return childbirthNote;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al modificar la Nota de parto");
                throw;
            }
        }

        public List<WorkTimeItemEntity> GetWorkTimeItems(string worktime)
        {
            try
            {
                return _context.WorkTimeItemEntities.Where(wti => wti.WorkTimeId == worktime).ToList();
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}