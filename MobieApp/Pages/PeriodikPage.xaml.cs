using ShareModel;

namespace MobieApp.Pages;

public partial class PeriodikPage : ContentPage
{
    public PeriodikPage()
    {
        InitializeComponent();
        BindingContext = new PeriodikViewModel();
    }
}


public class PeriodikViewModel : BaseViewModel
{
    private PeriodikValidator validator = new PeriodikValidator();
    public PeriodikViewModel()
    {
        Model = Account.Profile.Periodik;
        Model.PropertyChanged += Model_PropertyChanged;
    }

    private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        Errors = validator.Validate(Model).Errors;
    }

    public Periodik Model { get; }
}