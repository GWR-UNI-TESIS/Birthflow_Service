using Birthflow_Application.DTOs.Auth;
using Birthflow_Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Birthflow_Domain.DTOs.Partographs;
using Birthflow_Domain.Interface;

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
    }
}
