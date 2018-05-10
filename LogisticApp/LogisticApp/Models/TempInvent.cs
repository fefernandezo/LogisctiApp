using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogisticApp.Models
{
    public class TempInvent
    {
        [PrimaryKey]
        public int IdAsignRuta { get; set; }

        public string Code { get; set; }

        public string Ruta { get; set; }

        public string DescripcionRuta { get; set; }

        public string Cant { get; set; }

        public override int GetHashCode()
        {
            return IdAsignRuta;
        }
    }
}
