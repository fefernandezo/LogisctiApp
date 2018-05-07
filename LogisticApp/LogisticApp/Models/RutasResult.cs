using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace LogisticApp.Models
{
    public class RutasResult
    {
        [PrimaryKey]
        public int IdRuta { get; set; }

        public bool HasRoute { get; set; }


        public string Nombre { get; set; }

        public string CodBodega { get; set; }

        public string Descripcion { get; set; }

        public string OPMessagge { get; set; }

        //[ManyToOne]
        //public LoginResult Loginresult { get; set; }

        public override int GetHashCode()
        {
            return IdRuta;
        }
    }

    
}
