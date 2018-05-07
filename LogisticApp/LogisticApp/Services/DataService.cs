using LogisticApp.Data;
using LogisticApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogisticApp.Services
{
    public class DataService
    {

        public LoginResult GetUser()
        {
            using (var da2 = new DataAccess())
            {
                return da2.First<LoginResult>(false);
            }
        }

        public Response UpdateUser(LoginResult user)
        {
            try
            {
                using (var da3 = new DataAccess())
                {
                    
                    da3.Update(user);
                }
                return new Response
                {
                    IsSuccess = true,
                    Messagge = "Usuario Actualizado OK,",
                    Result = user,
                };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Messagge = ex.Message,
                };

            }
        }
        public Response InsertUser(LoginResult user)
        {
            try
            {
                using (var da = new DataAccess())
                {
                    var oldUser = da.First<LoginResult>(false);
                    if(oldUser != null)
                    {
                        da.Delete(oldUser);
                    }
                    da.Insert(user);
                }
                return new Response
                {
                    IsSuccess = true,
                    Messagge = "Usuario Insertado OK,",
                    Result = user,
                };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Messagge=ex.Message,
                };
            }
        }
    }
}
