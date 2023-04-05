using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions.Attributes;

namespace travelingViajes.Models
{
    public class Reserva
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(ServiciosVuelos))]
        public int IdVuelos { get; set; }

        [ForeignKey(typeof(Usuarios))]
        public string UserId { get; set; }
    }
}
