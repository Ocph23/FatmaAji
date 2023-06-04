using Microsoft.Maui.Graphics;
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
			StatusColor = Account.Profile.Status == ShareModel.StatusPenerimaan.Lulus ? Colors.LimeGreen : Colors.OrangeRed;
			
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




	protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }

}