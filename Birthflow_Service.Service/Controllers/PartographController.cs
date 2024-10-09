using BirthflowService.Application.Interfaces;
using BirthflowService.Domain.DTOs.Partograph;
using BirthflowService.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BirthflowService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PartographController : Controller
    {
        private readonly IPartographService _partographServices;
        private readonly ILogger<PartographController> _logger;
        public PartographController(IPartographService _partographServices, ILogger<PartographController> logger)
        {
            this._partographServices = _partographServices;
            _logger = logger;
        }

        [HttpPost("create/partograph")]
        public async Task<IActionResult> CreatePartograph([FromBody] PartographDto partograph)
        {
            try
            {
                _logger.LogInformation("Intentando crear un nuevo partograma.");
                var result = await _partographServices.CreatePartograph(partograph);
                _logger.LogInformation("Partograma creado exitosamente con código de estado: {StatusCode}", result.StatusCode);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al crear el partograma.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpGet("partographs/{userId}")]
        public async Task<IActionResult> GetPartographs([FromRoute] Guid userId)
        {
            try
            {
                _logger.LogInformation("Obteniendo partogramas para el usuario con ID: {UserId}", userId);
                var result = await _partographServices.GetPartographs(userId);
                _logger.LogInformation("Partogramas obtenidos exitosamente con código de estado: {StatusCode}", result.StatusCode);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al obtener los partogramas para el usuario con ID: {UserId}", userId);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }
        // Actualizar partograma
        [HttpPatch("update/partograph")]
        public async Task<IActionResult> UpdatePartograph([FromBody] PartographDto partographDto)
        {
            try
            {
                _logger.LogInformation("Actualizando el partograma con ID: {PartographId}", partographDto.PartographId);
                var result = await _partographServices.UpdatePartograph(partographDto);
                if (result.Response == null)
                {
                    _logger.LogWarning("Partograma con ID: {PartographId} no encontrado.", partographDto.PartographId);
                    return StatusCode(result.StatusCode, result.Message);
                }
                _logger.LogInformation("Partograma actualizado correctamente.");
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el partograma con ID: {PartographId}", partographDto.PartographId);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // Eliminar partograma
        [HttpDelete("delete/partograph/{partographId}")]
        public async Task<IActionResult> DeletePartograph([FromRoute] Guid partographId)
        {
            try
            {
                _logger.LogInformation("Eliminando el partograma con ID: {PartographId}", partographId);
                var result = await _partographServices.DeletePartograph(partographId);
                if (result.Response == null)
                {
                    _logger.LogWarning("Partograma con ID: {PartographId} no encontrado.", partographId);
                    return StatusCode(result.StatusCode, result.Message);
                }
                _logger.LogInformation("Partograma eliminado correctamente.");
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el partograma con ID: {PartographId}", partographId);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }


        [HttpGet("partograph/{partographId}")]
        public async Task<IActionResult> GetPartograph([FromRoute] Guid partographId)
        {
            try
            {
                _logger.LogInformation("Obteniendo partograma con ID: {PartographId}", partographId);
                var result = await _partographServices.GetPartograph(partographId);
                _logger.LogInformation("Partograma obtenido exitosamente con código de estado: {StatusCode}", result.StatusCode);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al obtener el partograma con ID: {PartographId}", partographId);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpGet("cervical-dilation/partograph/{partographId}")]
        public async Task<IActionResult> GetCervicalDilationByUserId([FromRoute] Guid partographId)
        {
            try
            {
                _logger.LogInformation("Obteniendo dilataciones cervicales para el partograma con ID: {PartographId}", partographId);
                var response = await _partographServices.GetCervicalDilations(partographId);
                _logger.LogInformation("Dilataciones cervicales obtenidas exitosamente con código de estado: {StatusCode}", response.StatusCode);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al obtener las dilataciones cervicales para el partograma con ID: {PartographId}", partographId);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpPost("create/cervical-dilation")]
        public async Task<IActionResult> CreateCervicalDilationByUserId([FromBody] CervicalDilationDto cervicalDilationDto)
        {
            try
            {
                _logger.LogInformation("Creando una nueva dilatación cervical.");
                var response = await _partographServices.CreateCervicalDilation(cervicalDilationDto);
                _logger.LogInformation("Dilatación cervical creada exitosamente.");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al crear la dilatación cervical.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpPatch("update/cervical-dilation")]
        public async Task<IActionResult> UpdateCervicalDilation([FromBody] CervicalDilationDto cervicalDilationDto)
        {
            try
            {
                _logger.LogInformation("Actualizando la dilatación cervical con ID: {CervicalDilationId}", cervicalDilationDto.Id);
                var response = await _partographServices.UpdateCervicalDilation(cervicalDilationDto);
                _logger.LogInformation("Dilatación cervical actualizada exitosamente.");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al actualizar la dilatación cervical con ID: {CervicalDilationId}", cervicalDilationDto.Id);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpDelete("delete/cervical-dilation")]
        public async Task<IActionResult> DeleteCervicalDilation([FromBody] CervicalDilationDto cervicalDilationDto)
        {
            try
            {
                _logger.LogInformation("Eliminando la dilatación cervical con ID: {CervicalDilationId}", cervicalDilationDto.Id);
                var response = await _partographServices.DeleteCervicalDilation(cervicalDilationDto);
                _logger.LogInformation("Dilatación cervical eliminada exitosamente.");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al eliminar la dilatación cervical con ID: {CervicalDilationId}", cervicalDilationDto.Id);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // PRESENTATION POSITION ---------

        [HttpGet("presentation-position-variety/partograph/{parthographId}")]
        public async Task<IActionResult> GetPresentationPositionVarietyByParthographId([FromRoute] Guid parthographId)
        {
            try
            {
                _logger.LogInformation("Obteniendo variedades de posición de presentación para el partograma con ID: {ParthographId}", parthographId);
                var result = await _partographServices.GetPresentationPositionVarietyByParthographId(parthographId);
                _logger.LogInformation("Variedades de posición de presentación obtenidas exitosamente.");
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al obtener las variedades de posición de presentación para el partograma con ID: {ParthographId}", parthographId);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpPost("create/presentation-position-variety")]
        public async Task<IActionResult> CreatePresentationPositionVariety(PresentationPositionVarietyDto presentationDto)
        {
            try
            {
                _logger.LogInformation("Creando nueva variedad de posición de presentación.");
                var result = await _partographServices.CreatePresentationPositionVariety(presentationDto);
                _logger.LogInformation("Variedad de posición de presentación creada exitosamente.");
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al crear la variedad de posición de presentación.");
                return StatusCode(500, "Ocurrió un error interno.");
            }

        }

        [HttpPatch("update/presentation-position-variety")]
        public async Task<IActionResult> UpdatePresentationPositionVariety(PresentationPositionVarietyDto presentationDto)
        {
            try
            {
                _logger.LogInformation("Actualizando la variedad de posición de presentación.");
                var result = await _partographServices.UpdatePresentationPositionVariety(presentationDto);
                _logger.LogInformation("Variedad de posición de presentación actualizada exitosamente.");
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al actualizar la variedad de posición de presentación.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpDelete("delete/presentation-position-variety")]
        public async Task<IActionResult> DeletePresentationPositionVariety(PresentationPositionVarietyDto presentationDto)
        {
            try
            {
                _logger.LogInformation("Eliminando la variedad de posición de presentación.");
                var result = await _partographServices.DeletePresentationPositionVariety(presentationDto);
                _logger.LogInformation("Variedad de posición de presentación eliminada exitosamente.");
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al eliminar la variedad de posición de presentación.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // MEDICAL SURVEILLANCE ---------

        [HttpGet("medical-surveillance-table/partograph/{parthographId}")]
        public async Task<IActionResult> GetMedicalSurveillanceTableByParthograph([FromRoute] Guid parthographId)
        {
            try
            {
                _logger.LogInformation("Obteniendo tabla de vigilancia médica para el partograma con ID: {ParthographId}", parthographId);
                var result = await _partographServices.GetMedicalSurveillanceTableByParthographId(parthographId);
                _logger.LogInformation("Tabla de vigilancia médica obtenida exitosamente.");
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al obtener la tabla de vigilancia médica para el partograma con ID: {ParthographId}", parthographId);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpPost("create/medical-surveillance-table")]
        public async Task<IActionResult> CreateMedicalSurveillanceTable(MedicalSurveillanceTableDto presentationDto)
        {
            try
            {
                _logger.LogInformation("Creando nueva tabla de vigilancia médica.");
                var result = await _partographServices.CreateMedicalSurveillanceTable(presentationDto);
                _logger.LogInformation("Tabla de vigilancia médica creada exitosamente.");
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al crear la tabla de vigilancia médica.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpPatch("update/medical-surveillance-table")]
        public async Task<IActionResult> UpdateMedicalSurveillanceTable(MedicalSurveillanceTableDto presentationDto)
        {
            try
            {
                _logger.LogInformation("Actualizando la tabla de vigilancia médica.");
                var result = await _partographServices.UpdateMedicalSurveillanceTable(presentationDto);
                _logger.LogInformation("Tabla de vigilancia médica actualizada exitosamente.");
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al actualizar la tabla de vigilancia médica.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpDelete("delete/medical-surveillance-table")]
        public async Task<IActionResult> DeleteMedicalSurveillanceTable(MedicalSurveillanceTableDto presentationDto)
        {
            try
            {
                _logger.LogInformation("Eliminando la tabla de vigilancia médica.");
                var result = await _partographServices.DeleteMedicalSurveillanceTable(presentationDto);
                _logger.LogInformation("Tabla de vigilancia médica eliminada exitosamente.");
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al eliminar la tabla de vigilancia médica.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // Obtener frecuencia cardíaca fetal por ID
        [HttpGet("fetal-heart-rate/{id}")]
        public async Task<IActionResult> GetFetalHeartRate([FromRoute] long id)
        {
            try
            {
                _logger.LogInformation("Obteniendo la frecuencia cardíaca fetal con ID: {Id}", id);
                var result = await _partographServices.GetFetalHeartRate(id);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la frecuencia cardíaca fetal con ID: {Id}", id);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // Obtener todas las frecuencias cardíacas fetales por partograma
        [HttpGet("fetal-heart-rate/partograph/{partographId}")]
        public async Task<IActionResult> GetFetalHeartRateByParthographId([FromRoute] Guid partographId)
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las frecuencias cardíacas fetales para el partograma con ID: {PartographId}", partographId);
                var result = await _partographServices.GetFetalHeartRateByParthographId(partographId);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las frecuencias cardíacas fetales para el partograma con ID: {PartographId}", partographId);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // Crear frecuencia cardíaca fetal
        [HttpPost("create/fetal-heart-rate")]
        public async Task<IActionResult> CreateFetalHeartRate([FromBody] FetalHeartRateDto fetalHeartRateDto)
        {
            try
            {
                _logger.LogInformation("Creando una nueva frecuencia cardíaca fetal.");
                var result = await _partographServices.CreateFetalHeartRate(fetalHeartRateDto);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la frecuencia cardíaca fetal.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // Actualizar frecuencia cardíaca fetal
        [HttpPatch("update/fetal-heart-rate")]
        public async Task<IActionResult> UpdateFetalHeartRate([FromBody] FetalHeartRateDto fetalHeartRateDto)
        {
            try
            {
                _logger.LogInformation("Actualizando la frecuencia cardíaca fetal con ID: {Id}", fetalHeartRateDto.Id);
                var result = await _partographServices.UpdateFetalHeartRateTable(fetalHeartRateDto);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la frecuencia cardíaca fetal con ID: {Id}", fetalHeartRateDto.Id);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // Obtener frecuencia de contracciones por ID
        [HttpGet("contraction-frequency/{id}")]
        public async Task<IActionResult> GetContractionFrequency([FromRoute] long id)
        {
            try
            {
                _logger.LogInformation("Obteniendo la frecuencia de contracciones con ID: {Id}", id);
                var result = await _partographServices.GetContractionFrequency(id);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la frecuencia de contracciones con ID: {Id}", id);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // Obtener todas las frecuencias de contracciones por partograma
        [HttpGet("contraction-frequency/partograph/{partographId}")]
        public async Task<IActionResult> GetContractionFrequencyByParthographId([FromRoute] Guid partographId)
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las frecuencias de contracciones para el partograma con ID: {PartographId}", partographId);
                var result = await _partographServices.GetContractionFrequencyByParthographId(partographId);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las frecuencias de contracciones para el partograma con ID: {PartographId}", partographId);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // Crear frecuencia de contracciones
        [HttpPost("create/contraction-frequency")]
        public async Task<IActionResult> CreateContractionFrequency([FromBody] ContractionFrequencyDto contractionFrequencyDto)
        {
            try
            {
                _logger.LogInformation("Creando una nueva frecuencia de contracciones.");
                var result = await _partographServices.CreateContractionFrequency(contractionFrequencyDto);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la frecuencia de contracciones.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // Actualizar frecuencia de contracciones
        [HttpPatch("update/contraction-frequency")]
        public async Task<IActionResult> UpdateContractionFrequency([FromBody] ContractionFrequencyDto contractionFrequencyDto)
        {
            try
            {
                _logger.LogInformation("Actualizando la frecuencia de contracciones con ID: {Id}", contractionFrequencyDto.Id);
                var result = await _partographServices.UpdateContractionFrequency(contractionFrequencyDto);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la frecuencia de contracciones con ID: {Id}", contractionFrequencyDto.Id);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // Obtener nota de parto por ID de partograma
        [HttpGet("childbirth-note/partograph/{partographId}")]
        public async Task<IActionResult> GetChildBirthNoteByParthographId([FromRoute] Guid partographId)
        {
            try
            {
                _logger.LogInformation("Obteniendo la nota de parto para el partograma con ID: {PartographId}", partographId);
                var result = await _partographServices.GetChildBirthNoteByParthographId(partographId);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la nota de parto para el partograma con ID: {PartographId}", partographId);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // Crear nota de parto
        [HttpPost("create/childbirth-note")]
        public async Task<IActionResult> CreateChildBirthNote([FromBody] ChildbirthNoteDto childbirthNoteDto)
        {
            try
            {
                _logger.LogInformation("Creando una nueva nota de parto.");
                var result = await _partographServices.CreateChildBirthNote(childbirthNoteDto);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la nota de parto.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        // Actualizar nota de parto
        [HttpPatch("update/childbirth-note")]
        public async Task<IActionResult> UpdateChildBirthNote([FromBody] ChildbirthNoteDto childbirthNoteDto)
        {
            try
            {
                _logger.LogInformation("Actualizando la nota de parto con ID: {Id}", childbirthNoteDto.PartographId);
                var result = await _partographServices.UpdateChildBirthNote(childbirthNoteDto);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la nota de parto con ID: {Id}", childbirthNoteDto.PartographId);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpGet("partograph/curve/{partographId}")]
        public async Task<IActionResult> GetCurves([FromRoute] Guid partographId)
        {
            try
            {
                _logger.LogInformation("Obteniendo curvas del partograma con ID: {PartographId}", partographId);
                var result = await _partographServices.GetAlertCurves(partographId);
                _logger.LogInformation("Curvas obtenida exitosamente con código de estado: {StatusCode}", result.StatusCode);
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al obtener la curva del partograma con ID: {PartographId}", partographId);
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }
    }
}