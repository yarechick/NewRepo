
using Krispy.Models.Model.Catalogs;
using Krispy.Models.Model.Users;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Krispy.Models.Model.Transactional
{
    [Table("Orden", Schema = "trn")]
    public class Orden : Audita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ordenId", Order = 0)]
        public int OrdenId { get; set; }
        [Column("fechaOrden", Order = 1)]
        public DateTime FechaOrden { get; set; } = DateTime.Now;
        [Column("usuarioId", Order = 2)]
        public Guid UsuarioId { get; set; }
        [Column("clienteId", Order = 3)]
        public int ClienteId { get; set; }
        [Column("sucursalId", Order = 4)]
        public int SucursalId { get; set; }
        [Column("subTotal", Order = 5)]
        public required decimal SubTotal { get; set; }
        [DefaultValue(0)]
        [Column("impuesto", Order = 6)]
        public decimal Impuesto { get; set; }
        [DefaultValue(0)]
        [Column("descuento", Order = 7)]
        public decimal Descuento { get; set; }
        [Column("total", Order = 8)]
        public required decimal Total { get; set; }
        [Column("metodoPagoId", Order = 9)]
        public required int MetodoPagoId { get; set; }

        [Column("estatusOrdenId", Order = 10)]
        public required int EstatusOrdenId { get; set; } = 1;



        [Required]
        public List<DetalleOrden> DetalleOrden { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }
        [ForeignKey("MetodoPagoId")]
        public MetodoPago MetodoPago { get; set; }
        [ForeignKey("EstatusOrdenId")]
        public EstatusOrden EstatusOrden { get; set; }


    }
}
