using Microsoft.EntityFrameworkCore;
using Entidades;


namespace Services.MyDbContext
{
    public class MyContext : DbContext
    {
       
        public MyContext() { 
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public  DbSet<Paciente> Pacientes { get; set; }
        public  DbSet<Cita> Citas { get; set; }
        public  DbSet<User> Users { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TipoCita> TipoCitas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Cita");

                entity.ToTable("Citas");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.FechaHora).HasColumnType("datetime");
                entity.Property(e => e.Estado).IsRequired();
                entity.Property(e => e.Lugar)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<User>()
                .HasOne(e => e.Paciente) 
                .WithOne(e => e.User) 
                .HasForeignKey<Paciente>(e => e.UserId)
                .IsRequired(); 
            
            modelBuilder.Entity<Cita>()
                .HasOne(e => e.Paciente) 
                .WithMany(e => e.Citas) 
                .HasForeignKey(e => e.IdPaciente)
                .IsRequired(); 

            modelBuilder.Entity<Cita>()
                .HasOne(e => e.TipoCita) 
                .WithMany(e => e.Citas) 
                .HasForeignKey(e => e.IdTipoCita)
                .IsRequired();

            modelBuilder.Entity<Cita>()
                .HasOne(e => e.Sucursal) 
                .WithMany(e => e.Citas) 
                .HasForeignKey(e => e.IdSucursal)
                .IsRequired();



        }

    }
}
