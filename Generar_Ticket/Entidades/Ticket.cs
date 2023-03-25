using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Ticket
    {
        public string Id { get; set; }
        public DateTime Fecha { get; set; }
        public string IdCliente { get; set; }
        public string CodigoUsuario { get; set; }
        public decimal Precio { get; set; }
        public decimal ISV { get; set; }
        public decimal Descuento { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public Ticket()
        {
        }

        public Ticket(string id, DateTime fecha, string idCliente, string codigoUsuario, decimal precio, decimal iSV, decimal descuento, decimal subTotal, decimal total)
        {
            Id = id;
            Fecha = fecha;
            IdCliente = idCliente;
            CodigoUsuario = codigoUsuario;
            Precio = precio;
            ISV = iSV;
            Descuento = descuento;
            SubTotal = subTotal;
            Total = total;
        }
    }
}
