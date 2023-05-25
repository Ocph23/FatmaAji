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
    private AddressValidator validator = new AddressValidator();
    public AlamatViewModel()
    {
		Model = Account.Profile.Alamat;
        Model.PropertyChanged += Model_PropertyChanged;
    }

    private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
       Errors = validator.Validate(Model).Errors;
    }

    public Alamat Model { get; }
}