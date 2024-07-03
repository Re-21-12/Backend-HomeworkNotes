using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HomeWorksBackEnd.Models
{
    public partial class AdminTareasContext : DbContext
    {
        public AdminTareasContext()
        {
        }

        public AdminTareasContext(DbContextOptions<AdminTareasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividads { get; set; } = null!;
        public virtual DbSet<Materium> Materia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.ToTable("Actividad");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaEntrega)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fechaEntrega");

                entity.Property(e => e.Materia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("materia");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Nota)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("nota");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.MateriaNavigation)
                    .WithMany(p => p.Actividads)
                    .HasForeignKey(d => d.Materia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__mater__4CA06362");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.HasKey(e => e.NombreMateria)
                    .HasName("PK__Materia__FD8ED82EE0FF06CA");

                entity.Property(e => e.NombreMateria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreMateria");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
