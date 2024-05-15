using Microsoft.EntityFrameworkCore;

namespace RegistroUsuariosAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Agregar nuestro DbContext
            builder.Services.AddDbContext<ContextoUsuario>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));
            });

            var app = builder.Build();

            // Read -> Leer | HTTP -> GET
            app.MapGet("/usuarios", async (ContextoUsuario db) =>
            {
                var usuarios = await db.Usuarios.ToListAsync();
                return Results.Ok(usuarios);
            });

            // Read -> Leer Por Id | HTTP -> GET Parámetro Id
            app.MapGet("/usuarios/{id}", async (int id, ContextoUsuario db) =>
            {
                var usuario = await db.Usuarios.FindAsync(id);

                return usuario != null ? Results.Ok(usuario) : Results.NotFound();
            });

            // Create -> Crear | HTTP -> POST
            app.MapPost("/usuarios", async (Usuario usuario, ContextoUsuario db) =>
            {
                db.Usuarios.Add(usuario);
                await db.SaveChangesAsync();

                return Results.Created($"/usuarios/{usuario.UsuarioId}", usuario);
            });

            // Update -> Actualizar | HTTP -> PUT
            app.MapPut("/usuarios/{id}", async (int id, Usuario usuario, ContextoUsuario db) =>
            {
                var _usuario = await db.Usuarios.FindAsync(id);

                if (_usuario is null) return Results.NotFound();

                _usuario.Nombre = usuario.Nombre;
                _usuario.Apellido = usuario.Apellido;
                _usuario.Edad = usuario.Edad;
                _usuario.Direccion = usuario.Direccion;
                _usuario.Telefono = usuario.Telefono;

                db.Update(_usuario);
                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            // Delete -> Eliminar | HTTP -> DELETE
            app.MapDelete("/usuarios/{id}", async (int id, ContextoUsuario db) =>
            {
                var usuario = await db.Usuarios.FindAsync(id);

                if (usuario is null) return Results.NotFound();

                db.Remove(usuario);
                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            app.Run();
        }
    }
}
