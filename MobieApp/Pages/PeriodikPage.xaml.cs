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
    public PeriodikViewModel()
    {
        Model = Account.Profile.Periodik;
    }

    public Periodik Model { get; }
}