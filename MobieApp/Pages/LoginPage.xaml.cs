namespace MobieApp.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
		
	}


	private string userName;

	public string UserName
	{
		get { return userName; }
		set {  userName = value; }
	}


}

public class LoginViewModel:BaseViewModel
{
    public LoginViewModel()
    {

		LoginCommand = new Command(LoginAction, LoginValidate);
		RegisterCommand = new Command(() => { Application.Current.MainPage.Navigation.PushAsync(new RegisterPage()); });

		this.PropertyChanged += (_, __) => {
			if (__.PropertyName != "LoginCommand")
			{
				LoginCommand.ChangeCanExecute();
			}
		};

    }

    private async void LoginAction(object obj)
    {
		try
		{
			if (IsBusy)
				return;

			var login = await AccountStore.Login(UserName, Password);
			if (login)
				Application.Current.MainPage = new AppShell();

			else
				throw new Exception("Maaf Anda Tidak Memiliki Akses !");

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

    private bool LoginValidate(object arg)
    {
       if(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
			return false;

	   if (IsBusy)
			return false;
	   return true;
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

    public Command LoginCommand { get; }
    public Command RegisterCommand { get; private set; }
}