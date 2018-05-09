using System;
using System.Collections.Generic;
using System.Text;

namespace LogisticApp.Models
{
    public class ProductResult
    {
        public string Codigo { get; set; }
        public string Detalle { get; set; }
        public string UnidadMed { get; set; }
        public string Messagge { get; set; }
        public bool IsSuccess { get; set; }
    }
}
