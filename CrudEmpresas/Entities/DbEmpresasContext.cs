using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudEmpresas.Entities;

public partial class DbEmpresasContext : DbContext
{
    public DbEmpresasContext()
    {
    }

    public DbEmpresasContext(DbContextOptions<DbEmpresasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atividadeecomica> Atividadeecomicas { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Empresaemail> Empresaemails { get; set; }

    public virtual DbSet<Empresafilial> Empresafilials { get; set; }

    public virtual DbSet<Empresasectoeconomico> Empresasectoeconomicos { get; set; }

    public virtual DbSet<Empresatelefone> Empresatelefones { get; set; }

    public virtual DbSet<Sectoreconomico> Sectoreconomicos { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;port=5434;database=DbEmpresas;Username=postgres;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atividadeecomica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("atividadeecomica_pkey");

            entity.ToTable("atividadeecomica");

            entity.HasIndex(e => e.Nome, "atividadeecomica_nome_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("empresa_pkey");

            entity.ToTable("empresa");

            entity.HasIndex(e => e.Firma, "empresa_firma_key").IsUnique();

            entity.HasIndex(e => e.Nif, "empresa_nif_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abertura).HasColumnName("abertura");
            entity.Property(e => e.Atividadeeconomicaid).HasColumnName("atividadeeconomicaid");
            entity.Property(e => e.Firma)
                .HasMaxLength(100)
                .HasColumnName("firma");
            entity.Property(e => e.Logotipo).HasColumnName("logotipo");
            entity.Property(e => e.Nif)
                .HasMaxLength(10)
                .HasColumnName("nif");
            entity.Property(e => e.Tipoid).HasColumnName("tipoid");

            entity.HasOne(d => d.Atividadeeconomica).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.Atividadeeconomicaid)
                .HasConstraintName("empresa_atividadeeconomicaid_fkey");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.Tipoid)
                .HasConstraintName("empresa_tipoid_fkey");
        });

        modelBuilder.Entity<Empresaemail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("empresaemail");

            entity.HasIndex(e => e.Email, "empresaemail_email_key").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Empresaid).HasColumnName("empresaid");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Empresa).WithMany()
                .HasForeignKey(d => d.Empresaid)
                .HasConstraintName("empresaemail_empresaid_fkey");
        });

        modelBuilder.Entity<Empresafilial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("empresafilial_pkey");

            entity.ToTable("empresafilial");

            entity.HasIndex(e => e.Firma, "empresafilial_firma_key").IsUnique();

            entity.HasIndex(e => e.Nif, "empresafilial_nif_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Atividadeeconomicaid).HasColumnName("atividadeeconomicaid");
            entity.Property(e => e.Empresaid).HasColumnName("empresaid");
            entity.Property(e => e.Firma)
                .HasMaxLength(100)
                .HasColumnName("firma");
            entity.Property(e => e.Logotipo).HasColumnName("logotipo");
            entity.Property(e => e.Nif)
                .HasMaxLength(10)
                .HasColumnName("nif");

            entity.HasOne(d => d.Atividadeeconomica).WithMany(p => p.EmpresafilialAtividadeeconomicas)
                .HasForeignKey(d => d.Atividadeeconomicaid)
                .HasConstraintName("empresafilial_atividadeeconomicaid_fkey");

            entity.HasOne(d => d.Empresa).WithMany(p => p.EmpresafilialEmpresas)
                .HasForeignKey(d => d.Empresaid)
                .HasConstraintName("empresafilial_empresaid_fkey");
        });

        modelBuilder.Entity<Empresasectoeconomico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("empresasectoeconomico_pkey");

            entity.ToTable("empresasectoeconomico");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Empresaid).HasColumnName("empresaid");
            entity.Property(e => e.Sectoreconomicoid).HasColumnName("sectoreconomicoid");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Empresasectoeconomicos)
                .HasForeignKey(d => d.Empresaid)
                .HasConstraintName("empresasectoeconomico_empresaid_fkey");

            entity.HasOne(d => d.Sectoreconomico).WithMany(p => p.Empresasectoeconomicos)
                .HasForeignKey(d => d.Sectoreconomicoid)
                .HasConstraintName("empresasectoeconomico_sectoreconomicoid_fkey");
        });

        modelBuilder.Entity<Empresatelefone>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("empresatelefone");

            entity.HasIndex(e => e.Telefone, "empresatelefone_telefone_key").IsUnique();

            entity.Property(e => e.Empresaid).HasColumnName("empresaid");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Telefone)
                .HasMaxLength(9)
                .HasColumnName("telefone");

            entity.HasOne(d => d.Empresa).WithMany()
                .HasForeignKey(d => d.Empresaid)
                .HasConstraintName("empresatelefone_empresaid_fkey");
        });

        modelBuilder.Entity<Sectoreconomico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sectoreconomico_pkey");

            entity.ToTable("sectoreconomico");

            entity.HasIndex(e => e.Nome, "sectoreconomico_nome_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipo_pkey");

            entity.ToTable("tipo");

            entity.HasIndex(e => e.Nome, "tipo_nome_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
