using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace data.Models.Context;

public partial class LavaderoBDContext : DbContext
{
    public LavaderoBDContext(DbContextOptions<LavaderoBDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<tbl_client> tbl_clients { get; set; }

    public virtual DbSet<tbl_encargado> tbl_encargados { get; set; }

    public virtual DbSet<tbl_enterprice> tbl_enterprices { get; set; }

    public virtual DbSet<tbl_rol> tbl_rols { get; set; }

    public virtual DbSet<tbl_service> tbl_services { get; set; }

    public virtual DbSet<tbl_service_category> tbl_service_categories { get; set; }

    public virtual DbSet<tbl_user> tbl_users { get; set; }

    public virtual DbSet<tbl_washed> tbl_washeds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tbl_client>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__tbl_clie__3213E83F0914F596");

            entity.ToTable("tbl_client");

            entity.HasIndex(e => new { e.placa, e.idEnterprice }, "UQ_placa_enterprice").IsUnique();

            entity.Property(e => e.email).HasMaxLength(100);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.phone).HasMaxLength(10);
            entity.Property(e => e.placa).HasMaxLength(10);

            entity.HasOne(d => d.idEnterpriceNavigation).WithMany(p => p.tbl_clients)
                .HasForeignKey(d => d.idEnterprice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_client_enterprice");
        });

        modelBuilder.Entity<tbl_encargado>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__tbl_enca__3213E83FF83028AB");

            entity.ToTable("tbl_encargado");

            entity.Property(e => e.name).HasMaxLength(100);

            entity.HasOne(d => d.idEnterpriceNavigation).WithMany(p => p.tbl_encargados)
                .HasForeignKey(d => d.idEnterprice)
                .HasConstraintName("FK_encargado_enterprice");
        });

        modelBuilder.Entity<tbl_enterprice>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__tbl_ente__3213E83F99FCF0FF");

            entity.ToTable("tbl_enterprice");

            entity.Property(e => e.enterprice).HasMaxLength(70);
        });

        modelBuilder.Entity<tbl_rol>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__tbl_rol__3213E83F4828A594");

            entity.ToTable("tbl_rol");

            entity.Property(e => e.rol).HasMaxLength(10);
        });

        modelBuilder.Entity<tbl_service>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__tbl_serv__3213E83F712C4185");

            entity.ToTable("tbl_service");

            entity.Property(e => e.price).HasColumnType("money");

            entity.HasOne(d => d.idCategoryNavigation).WithMany(p => p.tbl_services)
                .HasForeignKey(d => d.idCategory)
                .HasConstraintName("FK_service_category");

            entity.HasOne(d => d.idEnterpriceNavigation).WithMany(p => p.tbl_services)
                .HasForeignKey(d => d.idEnterprice)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_service_enterprice");
        });

        modelBuilder.Entity<tbl_service_category>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__tbl_serv__3213E83F3D376B20");

            entity.ToTable("tbl_service_category");

            entity.Property(e => e.category).HasMaxLength(100);
        });

        modelBuilder.Entity<tbl_user>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__tbl_user__3213E83F507AB1E5");

            entity.ToTable("tbl_user");

            entity.HasIndex(e => e.document, "UQ__tbl_user__1D810B12833DF2F1").IsUnique();

            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.document).HasMaxLength(50);
            entity.Property(e => e.email).HasMaxLength(100);
            entity.Property(e => e.lastName).HasMaxLength(50);
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.phone).HasMaxLength(20);

            entity.HasOne(d => d.idEnterpriceNavigation).WithMany(p => p.tbl_users)
                .HasForeignKey(d => d.idEnterprice)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_user_enterprice");

            entity.HasOne(d => d.idRolNavigation).WithMany(p => p.tbl_users)
                .HasForeignKey(d => d.idRol)
                .HasConstraintName("FK_user_rol");
        });

        modelBuilder.Entity<tbl_washed>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__tbl_wash__3213E83FFD3B6F07");

            entity.ToTable("tbl_washed");

            entity.Property(e => e.isPaid).HasDefaultValue(false);
            entity.Property(e => e.isWashed).HasDefaultValue(false);

            entity.HasOne(d => d.idClientNavigation).WithMany(p => p.tbl_washeds)
                .HasForeignKey(d => d.idClient)
                .HasConstraintName("FK_washed_client");

            entity.HasOne(d => d.idEncargadoNavigation).WithMany(p => p.tbl_washeds)
                .HasForeignKey(d => d.idEncargado)
                .HasConstraintName("FK_wash_encargado");

            entity.HasOne(d => d.idEnterpriceNavigation).WithMany(p => p.tbl_washeds)
                .HasForeignKey(d => d.idEnterprice)
                .HasConstraintName("FK_washed_enterprice");

            entity.HasOne(d => d.idServiceNavigation).WithMany(p => p.tbl_washeds)
                .HasForeignKey(d => d.idService)
                .HasConstraintName("FK_washed_service");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
