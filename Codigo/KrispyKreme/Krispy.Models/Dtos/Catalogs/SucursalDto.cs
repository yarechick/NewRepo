using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krispy.Models.Dtos.Catalogs
{
    public class SucursalDto
    {
        [Required(ErrorMessage = "Información requerida")]
        public int SucursalId { get; set; }
        [Required(ErrorMessage = "Información requerida")]
        public string Nombre { get; set; }
    }
}
