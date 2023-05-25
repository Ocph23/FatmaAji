using ShareModel;

namespace MobieApp.Services
{


    public interface IAccountService
    {
        Task<bool> Login(string userName, string Password);
        Task<bool> Register(string name, string email, string Password);
    }

    public class AccountService : IAccountService
    {
        string controller = "/api/account";
        public async Task<bool> Login(string userName, string Password)
        {
            try
            {
                using var client = new RestService();
                var response = await client.PostAsync($"{controller}/login", client.GenerateHttpContent(new LoginRequest(userName, Password)));
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.GetResult<AuthenticateResponse>();
                    if (result != null)
                    {
                        await Account.SetUser(result);
                        client.SetToken(result.Token);
                        response = await client.GetAsync($"/api/pendaftaran");
                        if (response.IsSuccessStatusCode)
                        {
                            var profile = await response.GetResult<CalonPesertaDidik>();
                            if (profile != null)
                            {
                                await Account.SetProfile(profile);
                                return true;
                            }
                        }
                        else
                            throw new SystemException(await client.Error(response));
                    }
                    return false;
                }
                else
                    throw new SystemException(await client.Error(response));
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public async Task<bool> Register(string name, string email, string Password)
        {
            try
            {
                using var client = new RestService();
                var response = await client.PostAsync($"{controller}/register", client.GenerateHttpContent(new RegisterRequest(name, email, Password)));
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.GetResult<AuthenticateResponse>();
                    if (result != null)
                    {
                        await Account.SetUser(result);
                        client.SetToken(result.Token);
                        return true;
                    }
                    return false;
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
