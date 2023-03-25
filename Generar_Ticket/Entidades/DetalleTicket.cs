using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleTicket
    {
        public int IdTicket { get; set; }
        public string TipoSoporte { get; set; }
        public string DescripcionSolicitud { get; set; }
        public string DescripcionRespuesta { get; set; }

        public DetalleTicket()
        {
        }

        public DetalleTicket(int idTicket, string tipoSoporte, string descripcionSolicitud, string descripcionRespuesta)
        {
            IdTicket = idTicket;
            TipoSoporte = tipoSoporte;
            DescripcionSolicitud = descripcionSolicitud;
            DescripcionRespuesta = descripcionRespuesta;
        }
    }
}
