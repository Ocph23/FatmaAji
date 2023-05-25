using MobieApp.Models;
using ShareModel;

namespace MobieApp.Pages;

public partial class IbuPage : ContentPage
{
	public IbuPage()
	{
		InitializeComponent();
        BindingContext = new IbuViewModel();
	}
}

public class IbuViewModel : BaseViewModel
{
    private OratuaValidator validator=new OratuaValidator();
    public IbuViewModel()
    {
        foreach (var item in Enum.GetValues(typeof(Pendidikan)).Cast<Pendidikan>().ToList())
            Pendidikans.Add(new EnumModel<Pendidikan>(item, ShareModel.Helper.AddWhiteSpaceInTitleCase(item.ToString())));

        foreach (var item in Enum.GetValues(typeof(Pekerjaan)).Cast<Pekerjaan>().ToList())
            Pekerjaans.Add(new EnumModel<Pekerjaan>(item, ShareModel.Helper.AddWhiteSpaceInTitleCase(item.ToString())));

        foreach (var item in Enum.GetValues(typeof(Penghasilan)).Cast<Penghasilan>().ToList())
            Penghasilans.Add(new EnumModel<Penghasilan>(item, ShareModel.Helper.GetPenghasilanText(item)));
        Model = Account.Profile.Ibu;

        PendidikanSelected = Pendidikans.SingleOrDefault(x => x.Value == Model.Pendidikan);
        PekerjaanSelected = Pekerjaans.SingleOrDefault(x => x.Value == Model.Pekerjaan);
        PenghasilanSelected = Penghasilans.SingleOrDefault(x => x.Value == Model.Penghasilan);
        Model.PropertyChanged += Model_PropertyChanged;

    }

    private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        Errors = validator.Validate(Model).Errors;
    }

    public List<EnumModel<Pendidikan>> Pendidikans { get; private set; } = new List<EnumModel<Pendidikan>>();
    public List<EnumModel<Pekerjaan>> Pekerjaans { get; private set; } = new List<EnumModel<Pekerjaan>>();
    public List<EnumModel<Penghasilan>> Penghasilans { get; private set; } = new List<EnumModel<Penghasilan>>();
    public OrangTua Model { get; }



    private EnumModel<Pendidikan> pendidikanSelected;

    public EnumModel<Pendidikan> PendidikanSelected
    {
        get { return pendidikanSelected; }
        set
        {
            SetProperty(ref pendidikanSelected, value);
            Model.Pendidikan = value.Value;
        }
    }



    private EnumModel<Pekerjaan> pekerjaanSelected;

    public EnumModel<Pekerjaan> PekerjaanSelected
    {
        get { return pekerjaanSelected; }
        set
        {
            SetProperty(ref pekerjaanSelected, value);
            Model.Pekerjaan = value.Value;
        }
    }




    private EnumModel<Penghasilan> penghasilanSelected;

    public EnumModel<Penghasilan> PenghasilanSelected
    {
        get { return penghasilanSelected; }
        set
        {
            SetProperty(ref penghasilanSelected, value);
            Model.Penghasilan = value.Value;
        }
    }






}