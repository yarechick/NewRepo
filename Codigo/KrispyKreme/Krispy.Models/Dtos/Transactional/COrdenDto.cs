
using System.ComponentModel.DataAnnotations;


namespace Krispy.Models.Dtos.Transactional
{
    public class COrdenDto
    {

        [Required(ErrorMessage = "Información requerida")]
        public required int ClienteId { get; set; }
        [Required(ErrorMessage = "Información requerida")]
        public required int SucursalId { get; set; }
        [Required(ErrorMessage = "Información requerida")]
        public required int MetodoPagoId { get; set; }

        public required List<CDetalleOrdenDto> DetalleOrden { get; set; }
    }
}
