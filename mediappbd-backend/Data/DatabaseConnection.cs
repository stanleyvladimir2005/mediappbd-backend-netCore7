using Microsoft.EntityFrameworkCore;
using mediappbd_backend.Model;


namespace mediappbd_backend.Data
{
    public class DatabaseConnection : DbContext
    {
        public DatabaseConnection(DbContextOptions<DatabaseConnection> options) : base(options)
        { }

        public DbSet<Patient> patient => Set<Patient>();
        public DbSet<Medic> medic => Set<Medic>();
        public DbSet<Exam> exam => Set<Exam>();
        public DbSet<Specialty> specialty => Set<Specialty>();
    }
}
