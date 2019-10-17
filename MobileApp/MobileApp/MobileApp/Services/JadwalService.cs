using MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
   public class JadwalService : IJadwalService<Jadwal>
    {

        private List<Jadwal> list { get; set; }

        public async Task<List<Jadwal>> Get()
        {
            try
            {
                if(list==null)
                {
                    using (var service = new RestService())
                    {
                        service.SetToken(Helper.Token);
                        var response = await service.GetAsync("api/jadwal/jadwaldosen");
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            ResponseResult res = JsonConvert.DeserializeObject<ResponseResult>(content);
                            list = JsonConvert.DeserializeObject<List<Jadwal>>(res.data.ToString());
                        }
                        else
                        {
                            throw new System.Exception(response.StatusCode.ToString());
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Task<List<Jadwal>> GetJadwalToday()
        {
            throw new NotImplementedException();
        }
    }
}
