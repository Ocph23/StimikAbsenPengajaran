using MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Services
{
    public class AuthService : IAuthService
    {
        public Task<Dosen> GetProfile(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Login(string userName, string password)
        {
            using (var service = new RestService())
            {
                try
                {
                    var response = await service.PostAsync("api/users/login",
                        service.GenerateHttpContent( new User { UserName=userName, Password=password}));
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        ResponseResult res = JsonConvert.DeserializeObject<ResponseResult>(content);
                        var token = JsonConvert.DeserializeObject<AuthenticationToken>(res.data.ToString());
                        Helper.Token = token.Token;

                        service.SetToken(Helper.Token);
                        var profileResponse = await service.GetAsync("api/home/getHome?role=dosen");
                        if(profileResponse.IsSuccessStatusCode)
                        {
                            var profileString = await profileResponse.Content.ReadAsStringAsync();
                            ResponseResult resResult = JsonConvert.DeserializeObject<ResponseResult>(profileString);
                            var Dosens = JsonConvert.DeserializeObject<List<Dosen>>(resResult.data.ToString());
                            if (Dosens != null)
                                Helper.Dosen = Dosens.FirstOrDefault();
                            else
                                throw new SystemException("Anda Tidak Memiliki Profile");
                        }
                        else
                        {
                            throw new System.Exception(profileResponse.StatusCode.ToString());
                        }
                    }
                    else
                    {
                        throw new System.Exception(response.StatusCode.ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);  
                }
            }

        }

    

    public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
