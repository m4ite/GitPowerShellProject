using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GitPsProject.Model;

public partial class GitPsProjecContext : DbContext
{
    public GitPsProjecContext()
    {
    }

    public GitPsProjecContext(DbContextOptions<GitPsProjecContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Repositorio> Repositorios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-0018D\\SQLEXPRESS;Initial Catalog=GitPsProjec;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Repositorio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reposito__3214EC272D7FC867");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataAtualização)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("Data_atualização");
            entity.Property(e => e.Diretorio)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
