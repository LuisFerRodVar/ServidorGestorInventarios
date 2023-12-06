using System;
using System.Collections.Generic;
using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Context;

public partial class GestionInventarioContext : DbContext
{
    public GestionInventarioContext()
    {
    }

    public GestionInventarioContext(DbContextOptions<GestionInventarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Credito> Creditos { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<SubCategorium> SubCategoria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KFMKD8A;Database=gestionInventario;Trust Server Certificate=true;User Id=AdminGestorInventario;Password=1234;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Articulo__3213E83FD1D51836");

            entity.ToTable("Articulo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Conversion).HasColumnName("conversion");
            entity.Property(e => e.Detalle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.IdSubCategoria).HasColumnName("idSubCategoria");
            entity.Property(e => e.Marca)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdSubCategoriaNavigation).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.IdSubCategoria)
                .HasConstraintName("FK__Articulo__idSubC__3C69FB99");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3213E83F233A3B8C");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Credito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Credito__3213E83FB09612F4");

            entity.ToTable("Credito");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("fecha");
            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.Monto).HasColumnName("monto");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.Creditos)
                .HasForeignKey(d => d.IdFactura)
                .HasConstraintName("FK__Credito__idFactu__412EB0B6");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Factura__3213E83F64903557");

            entity.ToTable("Factura");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Credito).HasColumnName("credito");
            entity.Property(e => e.Fecha)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("fecha");
            entity.Property(e => e.Impuesto).HasColumnName("impuesto");
            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.Total).HasColumnName("total");
        });

        modelBuilder.Entity<SubCategorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubCateg__3213E83F1429797E");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.SubCategoria)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__SubCatego__idCat__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
