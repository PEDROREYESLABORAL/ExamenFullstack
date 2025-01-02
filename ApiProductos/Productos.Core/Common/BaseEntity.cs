using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Core.Common
{
    public class BaseEntity
    {
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
