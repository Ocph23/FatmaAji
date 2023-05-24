namespace MobieApp.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
		BindingContext = new RegisterViewModel();
		
	}


	private string userName;

	public string UserName
	{
		get { return userName; }
		set {  userName = value; }
	}


}

public class RegisterViewModel:BaseViewModel
{
    public RegisterViewModel()
    {

		RegisterCommand = new Command(RegisterAction, RegisterValidate);

		this.PropertyChanged += (_, __) => {
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

			var login = await AccountStore.Register(name, UserName, Password);
			if (login)
				await	Application.Current.MainPage.Navigation.PushAsync(new LoginPage());

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
       if(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
			return false;

	   if(!IsZonasi)
			return false;
	   return true;
    }


	private string name;

	public string Name
	{
		get { return name; }
		set {SetProperty(ref name , value); }
	}


	private string userName;

	public string UserName
	{
		get { return userName; }
		set { SetProperty(ref userName , value); }
	}


	private string password;

	public string Password
	{
		get { return password; }
		set { SetProperty(ref password , value); }
	}



	private string confirmPasssword;

	public string ConfirmPassword
	{
		get { return confirmPasssword; }
		set { SetProperty(ref confirmPasssword , value); }
	}

	private bool isZonasi;

	public bool IsZonasi
    {
		get { return isZonasi; }
		set { SetProperty(ref isZonasi , value); }
	}



	public Command RegisterCommand { get; }
}