
using System.ComponentModel.DataAnnotations;

namespace Krispy.Models.Dtos.Users
{
    public class AccesoDto
    {
        [Required(ErrorMessage = "Información requerida")]
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }
        
        [Required(ErrorMessage = "Información requerida.")]
        [DataType(DataType.Password, ErrorMessage = "La contraseña no es válida.")]
        [Display(Name = "Contraseña")]
        public string ContrasenaHash { get; set; }
    }
}
