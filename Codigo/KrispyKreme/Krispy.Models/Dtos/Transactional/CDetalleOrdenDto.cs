using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krispy.Models.Dtos.Transactional
{
    public class CDetalleOrdenDto
    {
        [Required(ErrorMessage = "Información requerida")]
        public required int OrdenId { get; set; }
        [Required(ErrorMessage = "Información requerida")]
        public required int ProductoId { get; set; }
        [Required(ErrorMessage = "Información requerida")]
        public required int Cantidad { get; set; }
        [Required(ErrorMessage = "Información requerida")]
        public required decimal Precio { get; set; }



    }
}
