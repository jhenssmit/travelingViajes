using System;
using System.Collections.Generic;
using System.Text;

namespace travelingViajes.Models
{
    public class ReservaViewModel
    {
        public string UserId { get; set; }
        public int IdVuelos { get; set; }
        public string NombreUsuario { get; set; }
        public string PaisDestino { get; set; }
        public string DiaSalida { get; set; }
        public string HoraSalida { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
    }
}
