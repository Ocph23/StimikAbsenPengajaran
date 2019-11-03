﻿using MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
   public class JadwalService : IJadwalService<Jadwal>
    {

        public async Task<List<Jadwal>> Get()
        {
            try
            {
                using (var service = new RestService())
                {
                    service.SetToken(Helper.Token);

                    var response = await service.GetAsync("api/jadwal/jadwaldosen");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        ResponseResult res = JsonConvert.DeserializeObject<ResponseResult>(content);
                        return JsonConvert.DeserializeObject<List<Jadwal>>(res.data.ToString());
                    }
                    else
                    {
                        throw new System.Exception(response.StatusCode.ToString());
                    }
                }
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

        public async Task<DataTimeZone> GetDateTimeNow()
        {
            using (var service = new RestService())
            {
                try
                {
                    service.SetToken(Helper.Token);
                    var response = await service.GetAsync("http://worldtimeapi.org/api/timezone/asia/jayapura");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<DataTimeZone>(content);
                       // return JsonConvert.DeserializeObject<DataTimeZone>(res.data.ToString());
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }



    }


    public class DataTimeZone
    {
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("datetime")]
        public DateTime DateTime { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }
    }

}
