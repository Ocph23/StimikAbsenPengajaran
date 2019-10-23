using MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public class BeritaAcaraService : IBeritaAcaraService<BeritaAcara>
    {

        public async Task<List<BeritaAcara>> Get(int idjadwa)
        {
            using (var service = new RestService())
            {
                service.SetToken(Helper.Token);
                var response = await service.GetAsync($"api/beritaacara/GetBaMengajar?idjadwal={idjadwa}&&nidn={Helper.Dosen.NIDN}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ResponseResult res = JsonConvert.DeserializeObject<ResponseResult>(content);
                    var datas= JsonConvert.DeserializeObject<List<BeritaAcara>>(res.data.ToString());
                    if(datas !=null)
                    {
                        return datas.OrderByDescending(x => x.Tanggal).ToList();
                    }

                    return null;

                }
                else
                {
                    throw new System.Exception(response.StatusCode.ToString());
                }
            }
        }

        public async Task<BeritaAcara> GetById(int idJadwal, DateTime date)
        {
            try
            {
              var list = await Get(idJadwal);
                if (list != null)
                {
                    var data = list.Where(x => x.JadwalId == idJadwal && x.Tanggal.Value.Day == date.Day &&
                     x.Tanggal.Value.Month == date.Month && x.Tanggal.Value.Year == date.Year).FirstOrDefault();

                    return data;
                }

                return null;
             
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public async Task<BeritaAcara> Save(BeritaAcara t)
        {
            try
            {
                using (var service = new RestService())
                {
                    service.SetToken(Helper.Token);
                    HttpResponseMessage response = null;
                    if(t.BeritaAcaraId==null)
                    {
                        response = await service.PostAsync("api/beritaacara/AddBaMengajar", service.GenerateHttpContent(t));
                        if (response != null && response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            ResponseResult res = JsonConvert.DeserializeObject<ResponseResult>(content);
                            var result = JsonConvert.DeserializeObject<Int32>(res.data.ToString());

                            if(result<=0)
                            {
                                t.BeritaAcaraId = result;
                            }
                            return t;
                        }
                        else
                        {
                            throw new System.Exception(response.StatusCode.ToString());
                        }
                    }
                    else
                    {
                        response = await service.PutAsync("api/beritaacara/updateBaMengajar", service.GenerateHttpContent(t));
                        if (response != null && response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            ResponseResult res = JsonConvert.DeserializeObject<ResponseResult>(content);
                            var result =(bool)res.data;
                            if(result)
                            {
                                return t;
                            }else
                            {
                                throw new System.Exception("Data Tidak Tersimpan");
                            }
                        }
                        else
                        {
                            throw new System.Exception(response.StatusCode.ToString());
                        }
                    }

                   
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
    }
}
