
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krispy.Models.Model.Catalogs
{
    [Table("Cliente", Schema ="cat")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("clienteId",Order = 0)]
        public int ClienteId { get; set; }
        [Column("nombre", Order = 1)]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [Column("apellidoPaterno", Order = 2)]
        public string ApellidoPaterno { get; set; }
        [Column("descuento", Order = 3)]
        public decimal Descuento { get; set; }
        [Column("numeroTelefono", Order = 4)]
        public string NumeroTelefono { get; set; }
        [Column("correoElectronico", Order = 5)]
        public string CorreoElectronico{ get; set; }
        [Column("activo", Order = 6)]
        public bool Activo { get; set; }

    }
}
