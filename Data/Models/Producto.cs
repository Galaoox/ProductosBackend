using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal ValorUnitario { get; set; }
        public short Disabled { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
