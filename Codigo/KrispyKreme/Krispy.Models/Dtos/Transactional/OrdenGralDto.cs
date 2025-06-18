using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krispy.Models.Dtos.Transactional
{
    public class OrdenGralDto
    {
        public int OrdenId { get; set; }
        public string FechaOrden { get; set; }
        public string Vendedor { get; set; }
        public string Sucursal { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; }
        public string EstatusOrden { get; set; }
    }
}
