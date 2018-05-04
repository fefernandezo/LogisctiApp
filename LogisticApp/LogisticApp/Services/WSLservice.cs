using LogisticApp.Models;
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
                HttpClient client = new HttpClient();
                HttpResponseMessage responseGet = await client.GetAsync(geturi);
                string response = await responseGet.Content.ReadAsStringAsync();

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
                        UserId = 1,
                    
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
                    Messagge = ex.Message,

                };
            }
        }
    }
}
