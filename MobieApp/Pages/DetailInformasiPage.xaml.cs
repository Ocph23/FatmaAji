using ShareModel;

namespace MobieApp.Pages;

public partial class DetailInformasiPage : ContentPage
{
    public Informasi Model { get; set; }
    public Command KeluarCommand { get; }
    public string IsiView { get; set; }

    public DetailInformasiPage(Informasi model)
	{
		InitializeComponent();
		Model = model;
        IsiView = model.Isi.Replace("<img src=\"/upload/images/", $"<img src=\"{Helper.Url}upload/images/");

        KeluarCommand = new Command(()=> Application.Current.MainPage.Navigation.PopModalAsync());

        BindingContext = this;

	}




}