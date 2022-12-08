using Microsoft.EntityFrameworkCore;
using mediappbd_backend.Model;


namespace mediappbd_backend.Data
{
    public class DatabaseConnection : DbContext
    {
        public DatabaseConnection(DbContextOptions<DatabaseConnection> options) : base(options)
        {
        }

        public DbSet<Paciente> Paciente => Set<Paciente>();
        public DbSet<Medico> Medico => Set<Medico>();
        public DbSet<Examen> Examen => Set<Examen>();
        public DbSet<Especialidad> Especialidad => Set<Especialidad>();
    }
}
