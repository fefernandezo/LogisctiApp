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
                        Nombre = (doc.Descendants(ns + "WSL_User").Elements(ns + "Nombre").First().Value).Trim(),
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

        public async Task<ProductResult> GetProdDetail (string codigo)
        {
            try
            {
                string BaseUri = "http://e.phglass.cl/ServiciosWeb/WSlogistica.asmx/Producto?codigo=";
                string Url = codigo;

                Uri geturi = new Uri(BaseUri + Url);
                HttpClient client1 = new HttpClient();

                HttpResponseMessage responseGet1 = await client1.GetAsync(geturi);

                
                    string response = await responseGet1.Content.ReadAsStringAsync();

                    XDocument doc = XDocument.Parse(response);
                    XNamespace ns = "http://www.phglass.cl/";

                var validacion = (doc.Descendants(ns + "WSL_Producto").Elements(ns + "Existe").First().Value).Trim();

                if(validacion=="true")
                {
                    return new ProductResult
                    {
                        IsSuccess = true,
                        Codigo = (doc.Descendants(ns + "WSL_Producto").Elements(ns + "Codigo").First().Value).Trim(),
                        Detalle = (doc.Descendants(ns + "WSL_Producto").Elements(ns + "Nombre").First().Value).Trim(),
                        UnidadMed = (doc.Descendants(ns + "WSL_Producto").Elements(ns + "UnidMed").First().Value).Trim(),

                    };
                }
                else
                {
                    return new ProductResult
                    {
                        IsSuccess = false,
                        Messagge = "El código no existe en RANDOM",

                    };
                }
                    
               

                
                
            }
            
            catch (Exception ex)
            {

                return new ProductResult
                {
                    IsSuccess = false,
                    Messagge = ex.Message + " Problemas de conección",

                };
            }
        }

        public async Task<IngElemInventoryConfirm> IngProdInvConfirm(string Idasign, string User, string Kopr, string Cant, string Unit)
        {

            try
            {
                var Token = "BaPRiThWJLYvy3KOn04K43we4XtyMdJIiYzqFwvLH0";
                string BaseUri = "http://e.phglass.cl/ServiciosWeb/WSlogistica.asmx/IngresoInventario?Idasign=";
                string Url = Idasign + "&User=" + User + "&Kopr=" + Kopr + "&Cant=" + Cant.Replace(",",".") + "&Unit=" + Unit +"&Token=" + Token;

                Uri geturi = new Uri(BaseUri + Url);
                HttpClient client1 = new HttpClient();

                HttpResponseMessage responseGet1 = await client1.GetAsync(geturi);


                string response = await responseGet1.Content.ReadAsStringAsync();

                XDocument doc = XDocument.Parse(response);
                XNamespace ns = "http://www.phglass.cl/";

                var validacion = (doc.Descendants(ns + "WSL_IngProdInventory").Elements(ns + "Validate").First().Value).Trim();

                if (validacion == "true")
                {
                    return new IngElemInventoryConfirm
                    {
                        IsSuccess = true,
                       IdTable = (doc.Descendants(ns + "WSL_IngProdInventory").Elements(ns + "IdOperacion").First().Value).Trim(),
                       

                    };
                }
                else
                {
                    return new IngElemInventoryConfirm
                    {
                        IsSuccess = false,
                        Messagge = "Problemas al ingresar el producto",

                    };
                }





            }

            catch (Exception ex)
            {

                return new IngElemInventoryConfirm
                {
                    IsSuccess = false,
                    Messagge = ex.Message + " Problemas de conección",

                };
            }
        }
    }
}
