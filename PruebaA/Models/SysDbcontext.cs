using Microsoft.EntityFrameworkCore;

namespace PruebaA.Models
{
    public class SysDbcontext : DbContext
    {

        public SysDbcontext(DbContextOptions<SysDbcontext> opciones) : base(opciones)
        {
        }
        public DbSet<Libros> Libros { get; set; }
        public DbSet<Autores> Autores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Libros>()
             .HasOne(l => l.autores)
             .WithMany(a => a.Libros)
             .HasForeignKey(l => l.AutorId);

        }
    }
}
