using Productos.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Core.Entities
{
    public class Producto : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<OrdenProducto> OrdenProductos { get; set; } = new List<OrdenProducto>();

    }
}
