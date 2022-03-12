using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Venta>();
        }

        public int Id { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public short Disabled { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
