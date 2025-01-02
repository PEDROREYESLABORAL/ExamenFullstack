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
    public partial class OrdenConfiguration : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> entity)
        {
            entity.HasKey(e => e.IdOrden).HasName("PK_Orden_IdOrden");
            entity.Property(e => e.IdOrden).ValueGeneratedOnAdd();
            entity.Property(p => p.Total).IsRequired().HasPrecision(18, 2);
            entity.Property(p => p.FechaOrden).HasColumnType("datetime").HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired();
            entity.Property(p => p.Activo).IsRequired().HasDefaultValue(true);


            OnConfigurePartial(entity);


        }

        partial void OnConfigurePartial(EntityTypeBuilder<Orden> entity);
    }
}
