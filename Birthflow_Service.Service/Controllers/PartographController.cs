using Birthflow_Application.DTOs;
using Birthflow_Application.DTOs.Auth;
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

        public PartographController(IPartographService _partographServices)
        {
            this._partographServices = _partographServices;
        }

        [HttpPost("create/partograph")]
        public IActionResult CreatePartograph([FromBody] PartographDto partograph)
        {
            var result = _partographServices.CreatePartograph(partograph);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("get/partographs/{userId}")]
        public IActionResult GetPartographs([FromRoute] Guid userId)
        {
            var result = _partographServices.GetPartographs(userId);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("get/partograph/{partographId}")]
        public IActionResult GetPartograph([FromRoute] Guid partographId)
        {
            var result = _partographServices.GetPartograph(partographId);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("get/cervical-dilations/{partographId}")]
        public IActionResult GetCervicalDilationByUserId([FromRoute] Guid partographId)
        {
            if (partographId == Guid.Empty)
            {
                return BadRequest(new BaseResponse<UsuarioEntityDto>
                {
                    Response = null,
                    Message = "El ID es requerido",
                    StatusCode = StatusCodes.Status404NotFound,
                });
            }

            var response = _partographServices.GetCervicalDilations(partographId);

            return Ok(response);
        }

        [HttpPost("create/cervical-dilation")]
        public IActionResult CreateCervicalDilationByUserId([FromBody] CervicalDilationDto cervicalDilationDto)
        {
            if (cervicalDilationDto == null)
            {
                return BadRequest(new BaseResponse<UsuarioEntityDto>
                {
                    Response = null,
                    Message = "El body es requerido",
                    StatusCode = StatusCodes.Status404NotFound,
                });
            }

            var response = _partographServices.CreateCervicalDilation(cervicalDilationDto);

            return Ok(response);
        }

        [HttpPatch("update/cervical-dilation")]
        public IActionResult UpdateCervicalDilation([FromBody] CervicalDilationDto cervicalDilationDto)
        {
            if (cervicalDilationDto == null)
            {
                return BadRequest(new BaseResponse<UsuarioEntityDto>
                {
                    Response = null,
                    Message = "El body es requerido",
                    StatusCode = StatusCodes.Status404NotFound,
                });
            }

            var response = _partographServices.UpdateCervicalDilation(cervicalDilationDto);

            return Ok(response);
        }

        [HttpPost("delete/cervical-dilation")]
        public IActionResult DeleteCervicalDilation([FromBody] CervicalDilationDto cervicalDilationDto)
        {
            if (cervicalDilationDto == null)
            {
                return BadRequest(new BaseResponse<UsuarioEntityDto>
                {
                    Response = null,
                    Message = "El body es requerido",
                    StatusCode = StatusCodes.Status404NotFound,
                });
            }
            var response = _partographServices.DeleteCervicalDilation(cervicalDilationDto.Id);

            return Ok(response);
        }

        // PRESENTATION POSITION ---------

        [HttpGet("presentation-position-variety/all")]
        public IActionResult GetAllPresentationPositionVariety()
        {
            return Ok(_partographServices.GetAllPresentationPositionVariety());
        }

        [HttpGet("presentation-position-variety/{parthographId}")]
        public IActionResult GetPresentationPositionVarietyByParthographId([FromRoute] Guid parthographId)
        {
            return Ok(_partographServices.GetPresentationPositionVarietyByParthographId(parthographId));
        }

        [HttpPost("create/presentation-position-variety")]
        public IActionResult CreatePresentationPositionVariety(PresentationPositionVarietyDto presentationDto)
        {
            var result = _partographServices.CreatePresentationPositionVariety(presentationDto);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("update/presentation-position-variety")]
        public IActionResult UpdatePresentationPositionVariety(PresentationPositionVarietyDto presentationDto)
        {
            var result = _partographServices.UpdatePresentationPositionVariety(presentationDto);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("delete/presentation-position-variety")]
        public IActionResult DeletePresentationPositionVariety(PresentationPositionVarietyDto presentationDto)
        {
            var result = _partographServices.DeletePresentationPositionVariety(presentationDto);

            return StatusCode(result.StatusCode, result);
        }

        // MEDICAL SUREVILANCE ---------

        [HttpGet("medical-surveillance-table/all")]
        public IActionResult GetAllMedicalSurveillanceTable()
        {
            return Ok(_partographServices.GetAllMedicalSurveillanceTable());
        }

        [HttpGet("medical-surveillance-table/{parthographId}")]
        public IActionResult GetAllPresentationPositionVarietyByParthograph([FromRoute] Guid parthographId)
        {
            return Ok(_partographServices.GetMedicalSurveillanceTableByParthographId(parthographId));
        }

        [HttpPost("create/medical-surveillance-table")]
        public IActionResult CreateMedicalSurveillanceTable(MedicalSurveillanceTableDTO presentationDto)
        {
            var result = _partographServices.CreateMedicalSurveillanceTable(presentationDto);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("update/medical-surveillance-table")]
        public IActionResult UpdateMedicalSurveillanceTable(MedicalSurveillanceTableDTO presentationDto)
        {
            var result = _partographServices.UpdateMedicalSurveillanceTable(presentationDto);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("delete/medical-surveillance-table")]
        public IActionResult DeleteMedicalSurveillanceTable(MedicalSurveillanceTableDTO presentationDto)
        {
            var result = _partographServices.DeleteMedicalSurveillanceTable(presentationDto);

            return StatusCode(result.StatusCode, result);
        }
    }
}