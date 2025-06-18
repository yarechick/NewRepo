using AutoMapper;
using Krispy.AccessData.Data.Repository.IRepository;
using Krispy.Models.Dtos.Transactional;
using Krispy.Models.Model.Transactional;
using Krispy.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;

namespace Krispy.Api.Controllers.Transactional
{
    [Authorize]
    public class VentaController : Controller
    {
       
        private readonly IContent _content;
        private readonly IMapper _mapper;
        IHttpContextAccessor _httpContextAccessor;
      
        public VentaController(IContent content, IMapper mapper)
        {
            _content = content;
            _mapper = mapper;
           

        }
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetOrder")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
           
            var items = _content.Orden.GetAll(includeProperties: "Sucursal,MetodoPago,Usuario,EstatusOrden");
            if (items == null || !items.Any())
                return BadRequest(ApiResponse<OrdenGralDto>.ErrorResponse("No existen ventas"));

          
            return Ok(_mapper.Map<List<OrdenGralDto>>(items.ToList()));

        }



        
        [HttpPost("PostVenta")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Create([FromBody] COrdenDto item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse<OrdenGralDto>.ErrorResponse(ModelState));


            if (item == null)
                return BadRequest(ApiResponse<OrdenGralDto>.ErrorResponse(ModelState));

            try
            {
                if (item.DetalleOrden == null || !item.DetalleOrden.Any())
                    return BadRequest(ApiResponse<OrdenGralDto>.ErrorResponse("No existen productos"));

                // TODO:Validamos inventario

                //Obtenemos Cliente 
                var cliente = _content.Cliente.GetFirstOrDefault(c => c.ClienteId == item.ClienteId);

                if (cliente == null)
                    return BadRequest(ApiResponse<OrdenGralDto>.ErrorResponse("No existen cliente"));

                
                var orden = _mapper.Map<Orden>(item);
                orden.DetalleOrden.ForEach(d => d.SubTotal = (d.Cantidad * d.PrecioUnitario));
                orden.SubTotal = orden.DetalleOrden.Sum(p => p.SubTotal);
                orden.Impuesto = CTE.Impuesto;
                orden.Descuento = cliente.Descuento;
                orden.Total = orden.SubTotal+orden.Impuesto - orden.Descuento;
                orden.UsuarioId = Guid.Parse(User.GetUserId()); 
                orden.CreadoPor = User.GetNombreUsuario();
                orden.ModificadoPor = User.GetNombreUsuario();


                orden = _content.Orden.Procesar(orden);

                return CreatedAtAction(
               nameof(Get),
               new { id = orden.OrdenId },
               ApiResponse<OrdenGralDto>.SuccessResponse(_mapper.Map<OrdenGralDto>(orden), "Venta registrada exitosamente"));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<OrdenGralDto>.ErrorResponse("Error al procesar la venta"));
            }


        }
    }
}
