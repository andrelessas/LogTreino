using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTreino.DOMAIN;
using Microsoft.EntityFrameworkCore;

namespace LogTreino.DATA.Context
{
    public partial class LogTreinoContext : DbContext
    {
        public LogTreinoContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Aparelho> Aparelhos { get; set; } = null!;
        public virtual DbSet<Atleta> Atleta { get; set; } = null!;
        public virtual DbSet<Medida> Medidas { get; set; } = null!;
        public virtual DbSet<Serie> Series { get; set; } = null!;
        public virtual DbSet<TreinoDia> TreinoDia { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=.;Database=LogTreino;User Id=sa;Password=@Andre1993;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aparelho>(entity =>
            {
                entity.ToTable("Aparelho");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Atleta>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medida>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Barriga).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BicepsD).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BicepsE).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Cintura).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CoxaD).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CoxaE).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DataMedicao).HasColumnType("datetime");

                entity.Property(e => e.IdAtleta).HasColumnName("ID_Atleta");

                entity.Property(e => e.Peito).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdAtletaNavigation)
                    .WithMany(p => p.Medida)
                    .HasForeignKey(d => d.IdAtleta)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Medidas_Atleta");
            });

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.ToTable("Serie");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdTreinoDia).HasColumnName("ID_TreinoDia");

                entity.Property(e => e.Serie1).HasColumnName("Serie");

                entity.HasOne(d => d.IdTreinoDiaNavigation)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.IdTreinoDia)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Serie_TreinoDia");
            });

            modelBuilder.Entity<TreinoDia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.IdAparelho).HasColumnName("ID_Aparelho");

                entity.Property(e => e.IdAtleta).HasColumnName("ID_Atleta");

                entity.HasOne(d => d.IdAtletaNavigation)
                    .WithMany(p => p.TreinoDia)
                    .HasForeignKey(d => d.IdAtleta)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TreinoDia_Atleta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}