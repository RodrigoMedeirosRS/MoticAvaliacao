using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAO
{
    public partial class motic_avaliacaoContext : DbContext
    {
        public motic_avaliacaoContext()
        {
        }

        public motic_avaliacaoContext(DbContextOptions<motic_avaliacaoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avaliacao> Avaliacaos { get; set; }
        public virtual DbSet<Avaliador> Avaliadors { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Criterio> Criterios { get; set; }
        public virtual DbSet<Nomecriterio> Nomecriterios { get; set; }
        public virtual DbSet<Trabalho> Trabalhos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "pt_BR.UTF-8");

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("avaliacao_pkey");

                entity.ToTable("avaliacao");

                entity.HasIndex(e => e.Avaliador, "avaliador_trabalho_fkindex1");

                entity.HasIndex(e => e.Trabalho, "avaliador_trabalho_fkindex2");

                entity.HasIndex(e => e.Avaliador, "ifk_rel_01");

                entity.HasIndex(e => e.Trabalho, "ifk_rel_02");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Avaliador).HasColumnName("avaliador");

                entity.Property(e => e.Trabalho).HasColumnName("trabalho");

                entity.HasOne(d => d.AvaliadorNavigation)
                    .WithMany(p => p.Avaliacaos)
                    .HasForeignKey(d => d.Avaliador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("avaliacao_avaliador_fkey");

                entity.HasOne(d => d.TrabalhoNavigation)
                    .WithMany(p => p.Avaliacaos)
                    .HasForeignKey(d => d.Trabalho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("avaliacao_trabalho_fkey");
            });

            modelBuilder.Entity<Avaliador>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("avaliador_pkey");

                entity.ToTable("avaliador");

                entity.HasIndex(e => e.Cpf, "avaliador_cpf_key")
                    .IsUnique();

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("senha");

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("sobrenome");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .HasColumnName("telefone");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("categoria_pkey");

                entity.ToTable("categoria");

                entity.HasIndex(e => e.Nome, "categoria_nome_key")
                    .IsUnique();

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Nome).HasColumnName("nome");
            });

            modelBuilder.Entity<Criterio>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("criterio_pkey");

                entity.ToTable("criterio");

                entity.HasIndex(e => e.Nomecriterio, "criterio_fkindex1");

                entity.HasIndex(e => e.Avaliacao, "criterio_fkindex2");

                entity.HasIndex(e => e.Nomecriterio, "ifk_rel_04");

                entity.HasIndex(e => e.Avaliacao, "ifk_rel_09");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Avaliacao).HasColumnName("avaliacao");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(500)
                    .HasColumnName("descricao");

                entity.Property(e => e.Nomecriterio).HasColumnName("nomecriterio");

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(500)
                    .HasColumnName("observacao");

                entity.HasOne(d => d.AvaliacaoNavigation)
                    .WithMany(p => p.Criterios)
                    .HasForeignKey(d => d.Avaliacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("criterio_avaliacao_fkey");

                entity.HasOne(d => d.NomecriterioNavigation)
                    .WithMany(p => p.Criterios)
                    .HasForeignKey(d => d.Nomecriterio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("criterio_nomecriterio_fkey");
            });

            modelBuilder.Entity<Nomecriterio>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("nomecriterio_pkey");

                entity.ToTable("nomecriterio");

                entity.HasIndex(e => e.Nome, "nomecriterio_nome_key")
                    .IsUnique();

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.Peso).HasColumnName("peso");
            });

            modelBuilder.Entity<Trabalho>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("trabalho_pkey");

                entity.ToTable("trabalho");

                entity.HasIndex(e => e.Categoria, "ifk_rel_03");

                entity.HasIndex(e => e.Categoria, "trabalho_fkindex1");

                entity.HasIndex(e => e.Nome, "trabalho_nome_key")
                    .IsUnique();

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Anoapresentacao).HasColumnName("anoapresentacao");

                entity.Property(e => e.Categoria).HasColumnName("categoria");

                entity.Property(e => e.Escola)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("escola");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("nome");

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Trabalhos)
                    .HasForeignKey(d => d.Categoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trabalho_categoria_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
