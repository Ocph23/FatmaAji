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
    private KontakValidator validator = new KontakValidator();

    public KontakViewModel()
    {
		Model = Account.Profile.Kontak;
        Model.PropertyChanged += Model_PropertyChanged;
    }

    private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
            Errors = validator.Validate(Model).Errors;
        
    }

    public Kontak Model { get; private set; }
}