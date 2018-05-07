using System;
using System.Collections.Generic;
using System.Text;

namespace LogisticApp.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        public string Messagge { get; set; }

        public object Result { get; set; }
    }
}
