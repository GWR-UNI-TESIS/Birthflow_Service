using BirthflowService.Application.Interfaces;
using BirthflowService.Domain.DTOs.Partograph;
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

        [HttpGet("get/partographs/{userId}")]
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

        [HttpGet("get/partograph/{partographId}")]
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

        [HttpGet("get/cervical-dilations/{partographId}")]
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

        [HttpPost("delete/cervical-dilation")]
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

        [HttpGet("presentation-position-variety/all")]
        public async Task<IActionResult> GetAllPresentationPositionVariety()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las variedades de posición de presentación.");
                var result = await _partographServices.GetAllPresentationPositionVariety();
                _logger.LogInformation("Variedades de posición de presentación obtenidas exitosamente.");
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al obtener todas las variedades de posición de presentación.");
                return StatusCode(500, "Ocurrió un error interno.");
            }
        }

        [HttpGet("presentation-position-variety/{parthographId}")]
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

        [HttpPost("update/presentation-position-variety")]
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

        [HttpPost("delete/presentation-position-variety")]
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

        [HttpGet("medical-surveillance-table/{parthographId}")]
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
        public async Task<IActionResult> CreateMedicalSurveillanceTable(MedicalSurveillanceTableDTO presentationDto)
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

        [HttpPost("update/medical-surveillance-table")]
        public async Task<IActionResult> UpdateMedicalSurveillanceTable(MedicalSurveillanceTableDTO presentationDto)
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

        [HttpPost("delete/medical-surveillance-table")]
        public async Task<IActionResult> DeleteMedicalSurveillanceTable(MedicalSurveillanceTableDTO presentationDto)
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
    }
}