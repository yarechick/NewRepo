using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krispy.Models.Model.Users
{
    [Table("Usuario", Schema = "usr")]
    [Index(nameof(NombreUsuario), IsUnique=true)]
    public class Usuario
    {
        [Key]
        [Column("usuarioId", Order = 0)]
        public Guid UsuarioId { get; set; }
        [Column("nombreUsuario", Order = 1)]
        [StringLength(100)]
        public required string NombreUsuario { get; set; }
        [Column ("rolId", Order = 2)]
        public Int16 RolId { get; set; }
        [StringLength(100)]
        [Column("contrasenaHash", Order = 3)]
        public required string ContrasenaHash { get; set; }
        [Column("nombre", Order = 4)]
        public string Nombre { get; set; }
        [Column("apellidoPaterno", Order = 5)]
        public string ApellidoPaterno { get; set; }
        [Column("apellidoMaterno", Order = 6)]
        public string ApellidoMaterno { get; set; }

        [Column("nomberoTelefono", Order = 7)]
        public string NumeroTelefono { get; set; }
        [Column("correoElectronico", Order = 8)]
        public string CorreoElectronico { get; set; }
        [Column("bloqueoFin", Order = 9)]
        public DateTime BloqueoFin { get; set; }
        [Column("bloqueoHabilitado", Order = 10)]
        public bool BloqueoHabilitado { get; set; }
        [Column("accesoFalloConteo", Order = 11)]
        public int AccesoFalloConteo { get; set; }
        [Column("fechaModificacion", Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaModificacion { get; set; }
        [Column("activo", Order = 13)]
        public bool Activo { get; set; }


        [ForeignKey("RolId")]
        public Rol Rol { get; set; }
    }
}
