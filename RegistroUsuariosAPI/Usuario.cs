using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroUsuariosAPI
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe de tener entre 2 y 50 caracteres.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe de tener entre 2 y 50 caracteres.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "La edad es obligatoria.")]
        [Range(18, 65, ErrorMessage = "La edad debe estar entre los 18 y 65 años.")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(250, MinimumLength = 50, ErrorMessage = "La dirección debe de tener entre 50 y 250 caracteres.")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio")]
        [Phone(ErrorMessage = "El formato del número de telefono no es válido.")]
        public string Telefono { get; set; }
    }
}
