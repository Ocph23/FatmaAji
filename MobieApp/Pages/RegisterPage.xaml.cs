using FluentValidation;
using FluentValidation.Results;
using MobieApp.Models;
using ShareModel;
using System.Collections.ObjectModel;

namespace MobieApp.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel();

    }
}

public class RegisterViewModel : BaseViewModel
{
    public ObservableCollection<AntrianZonasi> DataZonasi { get; set; } = new();


    private RegisterRequestValidator validationRules = new();

    public Register Model { get; set; } = new Register();

    public RegisterViewModel()
    {

        RegisterCommand = new Command(RegisterAction, RegisterValidate);

        Model.PropertyChanged += (_, __) =>
        {
            if (__.PropertyName != "RegisterCommand")
            {
                RegisterCommand.ChangeCanExecute();
            }
        };
        _= Load();

    }

    private async Task Load()
    {
        try
        {
            IEnumerable<AntrianZonasi> dataZonasi = await AccountStore.GetZonasi(); 
            if(!dataZonasi.Any())
            {
                await Task.Delay(1000);
                await Application.Current.MainPage.Navigation.PopAsync(); 
                throw new Exception("Maaf Pendaftaran Belum Di buka !");
            }

            DataZonasi.Clear();
            foreach (var item in dataZonasi)
            {
                DataZonasi.Add(item);
            }
        }
        catch (Exception ex)
        {
           await MessageHelper.ErrorAsync(ex.Message);
        }
    }

    private async void RegisterAction(object obj)
    {
        try
        {
            if (IsBusy)
                return;

            var login = await AccountStore.Register(Model.Name, Model.Email, Model.Password, Model.Zonasi);
            if (login)
                await Application.Current.MainPage.Navigation.PopAsync();

            else
                throw new Exception("Maaf Anda Tidak Memiliki Akses !");

        }
        catch (Exception ex)
        {

            await MessageHelper.ErrorAsync(ex.Message);
        }
    }

    private bool RegisterValidate(object arg)
    {
        ValidationResult validator = validationRules.Validate(Model);
        if (validator.IsValid)
            return true;
        return false;
    }





    public Command RegisterCommand { get; }
}