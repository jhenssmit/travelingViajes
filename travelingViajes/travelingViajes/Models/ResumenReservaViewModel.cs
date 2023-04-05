using System;
using System.Collections.Generic;
using System.Text;

namespace travelingViajes.Models
{
    public class ResumenReservaViewModel
    {
        public List<ServiciosVuelos> ServiciosVuelos { get; set; }

        public ResumenReservaViewModel(List<ServiciosVuelos> serviciosVuelos)
        {
            ServiciosVuelos = serviciosVuelos;
        }
    }
}
