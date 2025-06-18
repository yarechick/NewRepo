using AutoMapper;
using Krispy.AccessData.Data.Repository.IRepository;
using Krispy.Models.Dtos.Catalogs;
using Krispy.Models.Dtos.Transactional;
using Krispy.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krispy.Api.Controllers.Catalogs
{
    [Authorize]
    public class SucursalController : Controller
    {
        private readonly IContent _content;
        private readonly IMapper _mapper;

        public SucursalController(IContent content, IMapper mapper)
        {
            _content = content;
            _mapper = mapper;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetSucursal")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get() 
        {

            var items = _content.Sucursal.GetAll(filter: s => s.Activo == true);
            if(items == null)
                return BadRequest(ApiResponse<SucursalDto>.ErrorResponse("No existen sucursales"));

            return Ok(_mapper.Map<List<SucursalDto>>(items));
        }
        
    }
}
