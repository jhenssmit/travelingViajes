using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace travelingViajes.Models
{
    public class Admin
    {
        [PrimaryKey, AutoIncrement]
        public int IdAdmin { get; set; }
        [MaxLength(100)]
        public string Usuario { get; set; }
        [MaxLength(100)]
        public string Contraseña { get; set; }

    }
}
