using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Venta
    {
        public long Id { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public int IdUsuario { get; set; }
        public short Disabled { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Cliente IdUsuarioNavigation { get; set; }
    }
}
