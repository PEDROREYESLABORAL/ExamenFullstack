using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Productos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Infrastructure.DB.Configurations
{
    

    public partial class OrdenProductoConfiguration : IEntityTypeConfiguration<OrdenProducto>
    {
        public void Configure(EntityTypeBuilder<OrdenProducto> entity)
        {
            entity.HasKey(e => new { e.IdOrden, e.IdProducto });

            entity.HasIndex(e => e.IdOrden, "IX_OrdenProducto_IdOrden");
            entity.HasIndex(e => e.IdProducto, "IX_OrdenProducto_IdProducto");

            entity.Property(p => p.Cantidad).IsRequired().HasPrecision(18, 2);
            entity.Property(p => p.Total).IsRequired().HasPrecision(18, 2);

            entity.HasOne(d => d.Orden).WithMany(p => p.OrdenProductos)
            .HasForeignKey(d => d.IdOrden)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Orden_OrdenProducto");

            entity.HasOne(d => d.Producto).WithMany(p => p.OrdenProductos)
            .HasForeignKey(d => d.IdProducto)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Producto_OrdenProducto");

            OnConfigurePartial(entity);

        }

        partial void OnConfigurePartial(EntityTypeBuilder<OrdenProducto> entity);
    }
}
