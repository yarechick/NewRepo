using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krispy.Models.Dtos.Catalogs
{
    public class ProductoDto
    {
        [Required(ErrorMessage = "Información requerida")]
        public int ProductoId { get; set; }
        [Required(ErrorMessage = "Información requerida")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Información requerida")]
        public decimal Precio { get; set; }
    }
}
