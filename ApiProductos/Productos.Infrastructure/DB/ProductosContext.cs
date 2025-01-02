using Microsoft.EntityFrameworkCore;
using Productos.Application.Interfaces;
using Productos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Infrastructure.DB
{
    public partial class ProductosContext : DbContext, IProductosContext
    {
        public ProductosContext(DbContextOptions<ProductosContext> options):base(options) 
        { 
        }
        
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<OrdenProducto> OrdenProducto { get; set; }


        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.OrdenConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ProductoConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.OrdenProductoConfiguration());
            

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
