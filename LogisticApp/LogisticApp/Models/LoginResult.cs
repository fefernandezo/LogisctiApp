using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace LogisticApp.Models
{
    public class LoginResult
    {
        [PrimaryKey]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsSuccess { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Messagge { get; set; }

        public bool IsRemember { get; set; }


        public override int GetHashCode()
        {
            return UserId;

        }
    }
}
