using LogisticApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogisticApp.Services
{
    public class WSLservice
    {
        public async Task<LoginResult> Login(string username, string password)
        {
            try
            {
               
                string BaseUri = "http://e.phglass.cl/ServiciosWeb/WSlogistica.asmx/LoginApp?UserName=";
                string Url = username + "&Password=" + password;

                Uri geturi = new Uri(BaseUri + Url);
                HttpClient client1 = new HttpClient();

                HttpResponseMessage responseGet1 = await client1.GetAsync(geturi);
                
                if (!responseGet1.IsSuccessStatusCode)
                {
                    return null;
                }

                string response = await responseGet1.Content.ReadAsStringAsync();

                XDocument doc = XDocument.Parse(response);
                XNamespace ns = "http://www.phglass.cl/";
                var validacion = doc.Descendants(ns + "WSL_User").Elements(ns + "Validate").First().Value;

                if (string.Join("", validacion) == "true")
                {
                    return new LoginResult
                    {
                        IsSuccess = true,
                        Messagge = "Usuario válido",
                        Nombre = doc.Descendants(ns + "WSL_User").Elements(ns + "Nombre").First().Value,
                        Correo = doc.Descendants(ns + "WSL_User").Elements(ns + "Correo").First().Value,
                        Password = password,
                        UserName = username,
                        UserId = Convert.ToInt32(doc.Descendants(ns + "WSL_User").Elements(ns + "Id_tab").First().Value),
                        IsRemember = false,
                    
                    };
                    
                }
                else
                {
                    return new LoginResult
                    {
                        IsSuccess = false,
                        Messagge = "Usuario o clave incorrecta " + validacion + " " + username + "&Password=" + password,
                    };
                }
            }


            catch (Exception ex)
            {

                return new LoginResult
                {
                    IsSuccess = false,
                    Messagge = ex.Message + "en el login",

                };
            }
        }

        public async Task<List<RutasResult>> GetRutas(int UserId)
        {
            List<RutasResult> Rutaresult = new List<RutasResult>();
            try
            {

                string BaseUri = "http://e.phglass.cl/ServiciosWeb/WSlogistica.asmx/Rutas?operario=";
                string Uri = UserId.ToString();

                Uri geturi = new Uri(BaseUri + Uri);
                HttpClient client = new HttpClient();
                HttpResponseMessage responseGet = await client.GetAsync(geturi);
               

                
                

                if(!responseGet.IsSuccessStatusCode)
                {
                    return null;
                }

                string response = await responseGet.Content.ReadAsStringAsync();
                XDocument doc = XDocument.Parse(response);
                XNamespace ns = "http://www.phglass.cl/";
                var XMLruta = doc.Descendants(ns + "WSL_Rutas");
                
                foreach(var item in XMLruta)
                {
                    var ruta = new RutasResult {
                        IdRuta = Convert.ToInt32(item.Element(ns +"Id").Value),
                        Nombre = item.Element(ns + "Nombre").Value,
                        CodBodega = item.Element(ns + "CodBodega").Value,
                        Descripcion = item.Element(ns + "Descripcion").Value,
                        HasRoute = true,

                    };
                    Rutaresult.Add(ruta);
                }

                return Rutaresult;
                
            }


            catch 
            {

                return null;
            }
        }
    }
}
