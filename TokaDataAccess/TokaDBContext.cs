using Microsoft.EntityFrameworkCore;
using TokaDomain.Modelos;
using TokaDomain.Respuesta;

namespace TokaDataAccess
{

    public partial class TokaDBContext : DbContext
    {

        public TokaDBContext(DbContextOptions<TokaDBContext> options) : base(options)
        {

        }
        public TokaDBContext() { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }
        public virtual DbSet<TbPersonasFisicas> PersonasFisica { get; set; }
        public virtual DbSet<RespuestaSP> RespuestaSP { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbPersonasFisicas>(entity =>
            {
                entity.HasKey(e => e.IdPersonaFisica);

                entity.ToTable("Tb_PersonasFisicas");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rfc)
                    .HasColumnName("RFC")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<RespuestaSP>().HasNoKey().ToView(null);
            modelBuilder.Entity<Usuario>().HasNoKey().ToView(null);

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
