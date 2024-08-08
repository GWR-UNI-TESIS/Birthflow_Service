using Birthflow_Application.DTOs.Auth;
using Birthflow_Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Birthflow_Domain.DTOs.Partographs;
using Birthflow_Domain.Interface;
using Birthflow_Application.Models;

namespace Birthflow_API.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PartographController : Controller
    {

        private readonly IPartographServices _partographServices;
        public PartographController(IPartographServices _partographServices)
        {
            this._partographServices = _partographServices;
        }

        [HttpPost("Create/partograph")]
        public IActionResult CreatePartograph([FromBody] PartographDto partograph)
        {
            if (partograph is null)
            {
                return BadRequest(new BaseResponse<UsuarioEntityDto>
                {
                    Response = null,
                    Message = "El modelo es requerido",
                    StatusCode = StatusCodes.Status404NotFound,
                });
            }

            var response = _partographServices.CreatePartograph(partograph);

            return Ok(response);
        }

        [HttpGet("Get/partograph/{userId}")]
        public IActionResult GetPartographs([FromRoute] Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest(new BaseResponse<UsuarioEntityDto>
                {
                    Response = null,
                    Message = "El ID es requerido",
                    StatusCode = StatusCodes.Status404NotFound,
                });
            }

            var response = _partographServices.GetPartograph(userId);

            return Ok(response);
        }

        [HttpGet("Get/cervical-dilation/{partographId}")]
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

        [HttpPost("Create/cervical-dilation")]
        public IActionResult CreateCervicalDilationByUserId([FromBody] CervicalDilationDto cervicalDilationDto )
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

        [HttpPatch("Update/cervical-dilation")]
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


        [HttpPost("Delete/cervical-dilation")]
        public IActionResult DepeteCervicalDilation([FromBody] CervicalDilationDto cervicalDilationDto)
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

            var response = _partographServices.DeleteCervicalDilation(cervicalDilationDto.Id, cervicalDilationDto.UserId);

            return Ok(response);
        }
    }
}
