using Microsoft.Maui.Graphics;
using ShareModel;
using System.ComponentModel;

namespace MobieApp.Pages;

public partial class StatusPage : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
	public StatusPage()
	{
		InitializeComponent();
		
		if(Account.Profile !=null)
		{
			Status = Account.Profile.Status== ShareModel.StatusPenerimaan.Lulus?"LULUS/DITERIMA":"GAGAL/TIDAK DITERIMA";
			StatusColor = Account.Profile.Status == ShareModel.StatusPenerimaan.Lulus ? Colors.Green : Colors.OrangeRed;
			Zona = Account.Profile.Zonasi;
			ShowZonasi = Account.Profile.Status == ShareModel.StatusPenerimaan.Lulus ? true : false;

        }
		BindingContext = this;
	}
	private Color statusColor = Colors.Red;
	public Color StatusColor
    {
		get { return statusColor; }
		set { statusColor = value; OnPropertyChanged("StatusColor"); }
	}


	private string status;

	public string Status
	{
		get { return status; }
		set { status = value; OnPropertyChanged("Status"); }
	}



	private AntrianZonasi zona;

	public AntrianZonasi Zona
	{
		get { return zona; }
        set { zona = value; OnPropertyChanged("Zona"); }
    }

	private bool showZonasi;

	public bool ShowZonasi
    {
		get { return showZonasi; }
		set { showZonasi = value; OnPropertyChanged("ShowZonasi"); }
	}


	protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }

}