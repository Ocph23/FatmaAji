using FluentValidation;
using FluentValidation.Results;
using MobieApp.Models;
using ShareModel;

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

    }

    private async void RegisterAction(object obj)
    {
        try
        {
            if (IsBusy)
                return;

            var login = await AccountStore.Register(Model.Name, Model.Email, Model.Password);
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