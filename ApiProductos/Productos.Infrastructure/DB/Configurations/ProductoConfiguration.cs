using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Productos.Core.Entities;

namespace Productos.Infrastructure.DB.Configurations
{


    public partial class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_Producto_Id");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(p=>p.Nombre).IsRequired().HasMaxLength(50);
            entity.Property(p=>p.Descripcion).IsRequired().HasMaxLength(100);
            entity.Property(p=>p.Precio).IsRequired().HasPrecision(18,2);
            entity.Property(p => p.Stock).IsRequired();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Producto> entity);
    }
}
