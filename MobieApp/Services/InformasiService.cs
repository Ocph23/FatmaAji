using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobieApp.Services
{
    public interface IInformasiService
    {
        Task<List<Informasi>> GetInformasi();
    }
    public class InformasiService : IInformasiService
    {
        string controller = "/api/informasi";

        public ICollection<Informasi> _persyaratan = new List<Informasi>();

        public async Task<List<Informasi>> GetInformasi()
        {
            try
            {
                using var client = new RestService();
                var response = await client.GetAsync($"{controller}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.GetResult<IEnumerable<Informasi>>();
                    if (result != null)
                    {
                        _persyaratan.Clear();

                        foreach (var persyaratan in result)
                        {
                            _persyaratan.Add(persyaratan);
                        }
                        return _persyaratan.ToList();
                    }
                }
                throw new SystemException(await client.Error(response));
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
    }
}
