using ShareModel;

namespace MobieApp.Pages;

public partial class KontakPage : ContentPage
{
	public KontakPage()
	{
		InitializeComponent();
		BindingContext = new KontakViewModel();
	}
}

public class KontakViewModel:BaseViewModel
{
    public KontakViewModel()
    {
		Model = Account.Profile.Kontak;
    }

    public Kontak Model { get; private set; }
}