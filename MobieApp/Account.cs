using ShareModel;
using System.Text.Json;

namespace MobieApp
{
    public class Account
    {
        private static CalonPesertaDidik _profile;

        public static bool UserIsLogin
        {
            get
            {
                return GetUser() != null;
            }
        }

        public static AuthenticateResponse GetUser()
        {
            var userString = Preferences.Get("User", null);
            if (string.IsNullOrEmpty(userString))
                return null;
            else
                return JsonSerializer.Deserialize<AuthenticateResponse>(userString, Helper.JsonOptions);
        }

        public static Task SetUser(AuthenticateResponse response)
        {
            try
            {
                var userString = JsonSerializer.Serialize(response);
                Preferences.Set("User", userString);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public static Task LogOut()
        {
            try
            {
                Preferences.Set("User", string.Empty);
                Preferences.Set("Profile", string.Empty);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        internal static Task SetProfile(CalonPesertaDidik response)
        {
            var userString = JsonSerializer.Serialize(response);
            Preferences.Set("Profile", userString);
            _profile = response;
            return Task.CompletedTask;
        }

        public static async Task<CalonPesertaDidik> GetProfile()
        {
            await Task.Delay(100);
            var userString = Preferences.Get("Profile", null);
            if (string.IsNullOrEmpty(userString))
                return null;
            else
                return JsonSerializer.Deserialize<CalonPesertaDidik>(userString, Helper.JsonOptions);
        }

        public static string Token
        {
            get
            {
                var user = GetUser();
                return user == null ? string.Empty : user.Token;
            }
        }

        public static CalonPesertaDidik Profile
        {
            get
            {
                if (_profile == null)
                {
                    var userString = Preferences.Get("Profile", null);
                    if (string.IsNullOrEmpty(userString))
                        return null;
                    else
                        _profile = JsonSerializer.Deserialize<CalonPesertaDidik>(userString, Helper.JsonOptions);
                }

                return _profile;
            }
        }

    }
}
