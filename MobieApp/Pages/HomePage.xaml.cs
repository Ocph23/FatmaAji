namespace MobieApp.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        BindingContext = new HomeViewModel();
    }
}

public class HomeViewModel : BaseViewModel
{
    public HomeViewModel()
    {
        SyncProfileCommand = new Command(async (x) => await SyncProfileAction(x));
    }

    public Command SyncProfileCommand { get; }

    private async Task SyncProfileAction(object obj)
    {
        try
        {
            IsBusy = true;
            var profile = await PendaftaranStore.GetProfile();
            if (profile != null)
            {
                await Account.SetProfile(profile);
                var shellvm = Shell.Current.BindingContext as AppShellViewModel;
                shellvm.ShowStatus = profile != null && profile.Status != ShareModel.StatusPenerimaan.None ? true : false;
            }
        }
        catch (Exception ex)
        {
            await MessageHelper.ErrorAsync(ex.Message);
        }
        finally { IsBusy = false; }
    }


}