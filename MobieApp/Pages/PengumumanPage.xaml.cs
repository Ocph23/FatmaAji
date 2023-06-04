using ShareModel;
using System.Collections.ObjectModel;

namespace MobieApp.Pages;

public partial class PengumumanPage : ContentPage
{
    public PengumumanPage()
    {
        InitializeComponent();
        BindingContext = new PengumumanViewModel();

    }
}

public class PengumumanViewModel : BaseViewModel
{
    public PengumumanViewModel()
    {
        SelectedCommand = new Command(SelectedAction);
        LoadCommand = new Command(async (x)=> await LoadAction(x));

        LoadCommand.Execute(this);
    }

    private void SelectedAction(object obj)
    {
        if(obj is Informasi model)
            Application.Current.MainPage.Navigation.PushModalAsync(new DetailInformasiPage(model));
    }

    public Command SelectedCommand { get; }
    public Command LoadCommand { get; }

    public ObservableCollection<Informasi> Datas { get; set; } = new ObservableCollection<Informasi>();

    private async Task LoadAction(object obj)
    {
        try
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            var result = await InformasiStore.GetInformasi();
            if (result != null)
            {
                Datas.Clear();
                foreach (var item in result.OrderByDescending(x=>x.Tanggal))
                {
                    Datas.Add(item);
                }
            }
        }
        catch (Exception ex)
        {
           await MessageHelper.ErrorAsync(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }
}