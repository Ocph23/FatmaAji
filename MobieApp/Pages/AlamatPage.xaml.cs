using ShareModel;

namespace MobieApp.Pages;

public partial class AlamatPage : ContentPage
{
	public AlamatPage()
	{
		InitializeComponent();
		BindingContext = new AlamatViewModel();
	}
}

public class AlamatViewModel:BaseViewModel
{
    public AlamatViewModel()
    {
		Model = Account.Profile.Alamat;
    }

    public Alamat Model { get; }
}