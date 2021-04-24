using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WSTienda.Models
{
    public partial class BDTiendaContext : DbContext
    {
        public BDTiendaContext()
        {
        }

        public BDTiendaContext(DbContextOptions<BDTiendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CabeceraDetalle> CabeceraDetalle { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Detalle> Detalle { get; set; }
        public virtual DbSet<Organizacion> Organizacion { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-ATU6LQJ;Database=BDTienda;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CabeceraDetalle>(entity =>
            {
                entity.HasKey(e => e.IdCabeceraDetalle);

                entity.HasIndex(e => e.IdCliente)
                    .HasName("IX_Relationship5");

                entity.HasIndex(e => e.IdOrganizacion)
                    .HasName("IX_Relationship4");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.CabeceraDetalle)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship5");

                entity.HasOne(d => d.IdOrganizacionNavigation)
                    .WithMany(p => p.CabeceraDetalle)
                    .HasForeignKey(d => d.IdOrganizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship4");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Detalle>(entity =>
            {
                entity.HasKey(e => e.IdDetalle);

                entity.HasIndex(e => e.IdCabeceraDetalle)
                    .HasName("IX_Relationship3");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("IX_Relationship6");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("decimal(5, 1)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PrecioActual).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PrecioTotal).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.IdCabeceraDetalleNavigation)
                    .WithMany(p => p.Detalle)
                    .HasForeignKey(d => d.IdCabeceraDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship3");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Detalle)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship6");
            });

            modelBuilder.Entity<Organizacion>(entity =>
            {
                entity.HasKey(e => e.IdOrganizacion);

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.HasComment("");

                entity.HasIndex(e => e.IdTipoProducto)
                    .HasName("IX_Relationship2");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Costo)
                    .HasColumnType("decimal(16, 2)")
                    .HasComment("precio de compra del producto. Servirá para sacar las utilidades.");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(16, 2)")
                    .HasComment("Precio de venta al cliente.");

                entity.HasOne(d => d.IdTipoProductoNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdTipoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship2");
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProducto);

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoProducto1)
                    .IsRequired()
                    .HasColumnName("TipoProducto")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuario1)
                    .IsRequired()
                    .HasColumnName("TipoUsuario")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.IdTipoUsuario)
                    .HasName("IX_Relationship1");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Ingreso al sistema.");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
