using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krispy.Models.Model.Catalogs
{
    [Table("Sucursal", Schema = "cat")]
    public class Sucursal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("sucursalId", Order = 0)]
        public int SucursalId { get; set; }
        [Column("nombre", Order = 1)]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [Column("direccion", Order = 2)]
        public string Direccion { get; set; }
        [Column("cp", Order = 3)]
        public string Cp { get; set; }
        [Column("numeroTelefono", Order = 4)]
        public string NumeroTelefono { get; set; }
        [Column("correoElectronico", Order = 5)]
        public string CorreoElectronico { get; set; }
        [Column("activo", Order = 6)]
        public bool Activo { get; set; }
    }
}
