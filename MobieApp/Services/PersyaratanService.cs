using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobieApp.Services
{
    public interface IPersyaratanService
    {
        Task<List<Persyaratan>> GetPersyaratan();
    }
    public class PersyaratanService : IPersyaratanService
    {
        string controller = "/api/persyaratan";

        public ICollection<Persyaratan> _persyaratan = new List<Persyaratan>();

        public async Task<List<Persyaratan>> GetPersyaratan()
        {
            try
            {
                using var client = new RestService();
                var response = await client.GetAsync($"{controller}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.GetResult<IEnumerable<Persyaratan>>();
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
