using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Model;

public partial class BdccodexContext : DbContext
{
    public BdccodexContext()
    {
    }

    public BdccodexContext(DbContextOptions<BdccodexContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SNCCHLAB02F236\\TEW_SQLEXPRESS;Initial Catalog=BDCCODEX;Integrated Security=SSPI;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC27726DB5EA");

            entity.ToTable("Post");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Conteudo).IsUnicode(false);
            entity.Property(e => e.Publicante)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC27896E162A");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
