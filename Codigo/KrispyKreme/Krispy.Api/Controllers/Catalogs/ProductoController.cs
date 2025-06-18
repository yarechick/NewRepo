using AutoMapper;
using Krispy.AccessData.Data.Repository.IRepository;
using Krispy.Models.Dtos.Catalogs;
using Krispy.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Krispy.Api.Controllers.Catalogs
{
    [Authorize]
    public class ProductoController : Controller
    {
        private readonly IContent _content;
        private readonly IMapper _mapper;

        public ProductoController(IContent content, IMapper mapper)
        {
            _content = content;
            _mapper = mapper;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetProducto")]
        public IActionResult Get() {

            var items = _content.Producto.GetAll(p => p.Activo == true);
            if (items == null || !items.Any())
                return BadRequest((ApiResponse<List<ProductoDto>>.ErrorResponse("No existen productos")));

            return Ok(_mapper.Map<List<ProductoDto>>(items));
        }
    }
}
