

using System.ComponentModel.DataAnnotations;

namespace Krispy.Models.Dtos.Users
{
    public class UsuarioDto
    {

        [Required(ErrorMessage = "Información requerida")]
        public Guid UsuarioId { get; set; }
        [Required(ErrorMessage = "Información requerida")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Información requerida")]
        public string CorreoElectronico { get; set; }
        [Required(ErrorMessage = "Información requerida")]
        public string Rol { get; set; }

    }
}
