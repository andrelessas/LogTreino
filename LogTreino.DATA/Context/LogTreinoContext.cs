using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LogTreino.DATA.Context
{
    public partial class LogTreinoContext:DbContext
    {
        public LogTreinoContext(DbContextOptions options)
            :base(options)
        {
            
        }    

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=.;Database=LogTreino;User Id=sa;Password=@Andre1993;Integrated Security=true;");
            }
        }

        public virtual DbSet<Aparelho> Aparelhos { get; set; } = null!;
        public virtual DbSet<Atleta> Atleta { get; set; } = null!;
        public virtual DbSet<Medicao> Medicaos { get; set; } = null!;
        public virtual DbSet<Serie> Series { get; set; } = null!;
        public virtual DbSet<Treino> Treinos { get; set; } = null!;
        public virtual DbSet<TreinoRealizado> TreinoRealizados { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aparelho>(entity =>
            {
                entity.ToTable("Aparelho");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Atleta>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

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

            modelBuilder.Entity<Medicao>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Medicao");

                entity.Property(e => e.Barriga).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Braco).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Coxa).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdAtleta).HasColumnName("ID_Atleta");

                entity.Property(e => e.Peito).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdAtletaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAtleta)
                    .HasConstraintName("FK_Medicao_Atleta");
            });

            modelBuilder.Entity<Serie>(entity =>
            {
                entity.ToTable("Serie");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.IdTreino).HasColumnName("ID_Treino");

                entity.Property(e => e.IdTreinoRealizado).HasColumnName("ID_TreinoRealizado");

                entity.HasOne(d => d.IdTreinoNavigation)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.IdTreino)
                    .HasConstraintName("FK_Serie_Treino");

                entity.HasOne(d => d.IdTreinoRealizadoNavigation)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.IdTreinoRealizado)
                    .HasConstraintName("FK_Serie_TreinoRealizado");
            });

            modelBuilder.Entity<Treino>(entity =>
            {
                entity.ToTable("Treino");

                entity.HasComment("Treino agendado para o dia");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.IdAparelho).HasColumnName("ID_Aparelho");

                entity.Property(e => e.IdAtleta).HasColumnName("ID_Atleta");

                entity.Property(e => e.IdSerie).HasColumnName("ID_Serie");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAtletaNavigation)
                    .WithMany(p => p.Treinos)
                    .HasForeignKey(d => d.IdAtleta)
                    .HasConstraintName("FK_Treino_Atleta");
            });

            modelBuilder.Entity<TreinoRealizado>(entity =>
            {
                entity.ToTable("TreinoRealizado");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.IdAtleta).HasColumnName("ID_Atleta");

                entity.HasOne(d => d.IdAtletaNavigation)
                    .WithMany(p => p.TreinoRealizados)
                    .HasForeignKey(d => d.IdAtleta)
                    .HasConstraintName("FK_TreinoRealizado_Atleta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}