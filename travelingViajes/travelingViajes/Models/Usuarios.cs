using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace travelingViajes.Models
{
    public class Usuarios
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }
        [MaxLength(100)]
        public string Nombres { get; set; }
        [MaxLength(100)]
        public string AplellidoPaterno { get; set; }
        [MaxLength(100)]
        public string AplellidoMaterno { get; set; }
        [MaxLength(8)]
        public string DNI { get; set;}
        [MaxLength(9)]
        public string Celular { get; set;}
        [MaxLength(200)]
        public string Correo { get; set;}
        [MaxLength(100)]
        public string Contrasena{ get; set;}

    }
}
