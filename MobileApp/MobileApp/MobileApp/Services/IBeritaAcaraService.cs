using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public interface IBeritaAcaraService<T>
    {
        Task<T> Save(T t);

        Task<T> GetById(int idJadwal, DateTime date);

        Task<List<T>> Get(int id);

    }
}
