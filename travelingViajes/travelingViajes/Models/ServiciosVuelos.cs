using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace travelingViajes.Models
{
    public class ServiciosVuelos
    {
        [PrimaryKey, AutoIncrement]
        public int IdVuelos { get; set; }
        [MaxLength(100)]
        public string PaisDestino { get; set; }
        [MaxLength(200)]
        public string DiaSalida { get; set; }
        [MaxLength(200)]
        public string HoraSalida { get; set; }
        [MaxLength(200)]
        public string Descripcion { get; set; }
        [MaxLength(100)]
        public string Precio { get; set; }
        [OneToMany]
        public List<Reserva> Reservas { get; set; }
    }
}
