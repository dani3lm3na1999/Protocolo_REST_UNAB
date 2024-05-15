using Microsoft.EntityFrameworkCore;

namespace RegistroUsuariosAPI
{
    public class ContextoUsuario : DbContext
    {
        // Inicializar el Contructor 
        public ContextoUsuario(DbContextOptions<ContextoUsuario> options) : base(options)
        {

        }

        // Propiedad DbSet
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
