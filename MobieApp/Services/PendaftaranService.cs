using ShareModel;

namespace MobieApp.Services
{


    public interface IPendaftaranService
    {
        Task<CalonPesertaDidik> GetProfile();
        Task<bool> Update(CalonPesertaDidik calon);
        Task<ItemPersyaratan> AddPersyaratan(int idCalon, ItemPersyaratan model);
        Task<string> UpdatePersyaratan(int idItemPersyaratan, MultipartFormDataContent content);
    }

    public class PendaftaranService : IPendaftaranService
    {
        string controller = "/api/pendaftaran";

        public async Task<ItemPersyaratan> AddPersyaratan(int idCalon, ItemPersyaratan model)
        {
            try
            {
                using var client = new RestService();
                var response = await client.PostAsync($"{controller}/persyaratan/{idCalon}", client.GenerateHttpContent(model));
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.GetResult<ItemPersyaratan>();
                    return result;
                }
                throw new SystemException(await client.Error(response));
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public async Task<CalonPesertaDidik> GetProfile()
        {
            try
            {
                using var client = new RestService();
                var response = await client.GetAsync($"{controller}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.GetResult<CalonPesertaDidik>();
                    if (result != null)
                    {
                        return result;
                    }
                }
                throw new SystemException(await client.Error(response));
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }


        public async Task<bool> Update(CalonPesertaDidik calon)
        {
            try
            {
                using var client = new RestService();
                var response = await client.PutAsync($"{controller}", client.GenerateHttpContent(calon));
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.GetResult<CalonPesertaDidik>();
                    await Account.SetProfile(result);
                    return true;
                }
                throw new SystemException(await client.Error(response));
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public async Task<string> UpdatePersyaratan(int idItemPersyaratan, MultipartFormDataContent content)
        {
            try
            {
                using var client = new RestService();
                var response = await client.PostAsync($"{controller}/upload/{idItemPersyaratan}", content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                    throw new SystemException(await client.Error(response));
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
    }
}
