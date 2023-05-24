using MobieApp.Services;

namespace MobieApp.Pages;

public partial class PersyaratanPage : ContentPage
{
    public PersyaratanPage()
    {
        InitializeComponent();
        BindingContext = new PersyaratanViewModel();
    }
}

public class PersyaratanViewModel : BaseViewModel
{
    public PersyaratanViewModel()
    {
        LoadCommand = new Command(LoadAction);
    }

    public Command LoadCommand { get; }

    private async void LoadAction(object obj)
    {
        try
        {
            var calon = Account.Profile;
            var persyaatans = await PersyaratanStore.GetPersyaratan();
            foreach (var item in persyaatans)
            {
                var notExists = calon.Persyaratan.SingleOrDefault(x => x.Persyaratan.Id == item.Id);
                if (notExists is null)
                {
                    calon.Persyaratan.Add(new ShareModel.ItemPersyaratan { Persyaratan = item });
                }
            }
        }
        catch (Exception ex)
        {
           await MessageHelper.ErrorAsync(ex.Message);
        }
    }
}