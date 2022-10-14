using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoDBFirst.Entidades
{
    public partial class PruebaModeloContext : DbContext
    {
        public PruebaModeloContext()
        {
        }

        public PruebaModeloContext(DbContextOptions<PruebaModeloContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DesgloseDetalle> DesgloseDetalles { get; set; } = null!;
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Tienda> Tiendas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=MainConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DesgloseDetalle>(entity =>
            {
                entity.HasKey(e => e.DesgloseId);

                entity.ToTable("DesgloseDetalle");

                entity.Property(e => e.DesgloseId).ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Forma)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Leyenda)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Detalle)
                    .WithMany(p => p.DesgloseDetalles)
                    .HasForeignKey(d => d.DetalleId)
                    .HasConstraintName("FK_DesgloseDetalle_DetalleFactura");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.DesgloseDetalles)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("FK_DesgloseDetalle_Facturas");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DesgloseDetalles)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_DesgloseDetalle_Productos");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.DetalleId);

                entity.ToTable("DetalleFactura");

                entity.Property(e => e.DetalleId).ValueGeneratedNever();

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("FK_DetalleFactura_Facturas");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_DetalleFactura_Productos");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.Property(e => e.FacturaId).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.PersonaId).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMail");

                entity.Property(e => e.Materno)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Paterno)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.ProductoId).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tienda>(entity =>
            {
                entity.Property(e => e.TiendaId).ValueGeneratedNever();

                entity.Property(e => e.Apertura).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rfc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RFC");

                entity.HasOne(d => d.Padre)
                    .WithMany(p => p.InversePadre)
                    .HasForeignKey(d => d.PadreId)
                    .HasConstraintName("FK_Tiendas_Tiendas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
