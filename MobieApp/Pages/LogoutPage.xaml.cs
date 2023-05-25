namespace MobieApp.Pages;

public partial class LogoutPage : ContentPage
{
	public LogoutPage()
	{
		InitializeComponent();
		LogoutCommand = new Command(LogoutAction);
        BindingContext = this;
	}

    public Command LogoutCommand { get; }

    private void LogoutAction(object obj)
    {
        Account.LogOut();
        Application.Current. MainPage = new AccountShell();
    }
}