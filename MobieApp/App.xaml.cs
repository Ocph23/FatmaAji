using MobieApp.Pages;
using MobieApp.Services;

namespace MobieApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<IAccountService, AccountService>();
            DependencyService.Register<IPendaftaranService, PendaftaranService>();
            DependencyService.Register<IPersyaratanService, PersyaratanService>();

            if(Account.UserIsLogin)
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new AccountShell();
            }


        }
    }
}