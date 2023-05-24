using MobieApp.Models;
using ShareModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobieApp.Pages;

public partial class CalonSiswaPage : ContentPage
{
    public CalonSiswaPage()
    {
        InitializeComponent();
        BindingContext = new CalonSiswaViewModel();
    }
}

public class CalonSiswaViewModel : BaseViewModel
{
    public CalonPesertaDidik Model { get; set; } = new();
    public List<EnumModel<Agama>> Agamas { get; } = new List<EnumModel<Agama>>();
    public List<EnumModel<Kewarganegaraan>> Kewarganegaraans { get; } = new List<EnumModel<Kewarganegaraan>>();
    public List<EnumModel<TempatTinggal>> TempatTinggals { get; } = new List<EnumModel<TempatTinggal>>();
    public List<EnumModel<ModaTransportasi>> ModaTransportasis { get; } = new List<EnumModel<ModaTransportasi>>();
    public List<EnumModel<JenisKelamin>> JenisKelamins { get; set; } = new List<EnumModel<JenisKelamin>>();
    public Command SaveCoomand { get; }

    private CalonPesertaDidikValidator validator = new CalonPesertaDidikValidator();

    public CalonSiswaViewModel()
    {


        foreach (var item in Enum.GetValues(typeof(Agama)).Cast<Agama>().ToList())
            Agamas.Add(new EnumModel<Agama>(item, ShareModel.Helper.AddWhiteSpaceInTitleCase(item.ToString())));

        foreach (var item in Enum.GetValues(typeof(Kewarganegaraan)).OfType<Kewarganegaraan>().ToList())
            Kewarganegaraans.Add(new EnumModel<Kewarganegaraan>(item, ShareModel.Helper.AddWhiteSpaceInTitleCase(item.ToString())));


        foreach (var item in Enum.GetValues(typeof(TempatTinggal)).OfType<TempatTinggal>().ToList())
            TempatTinggals.Add(new EnumModel<TempatTinggal>(item, ShareModel.Helper.AddWhiteSpaceInTitleCase(item.ToString())));


        foreach (var item in Enum.GetValues(typeof(ModaTransportasi)).OfType<ModaTransportasi>().ToList())
            ModaTransportasis.Add(new EnumModel<ModaTransportasi>(item, ShareModel.Helper.AddWhiteSpaceInTitleCase(item.ToString())));

        foreach (var item in Enum.GetValues(typeof(JenisKelamin)).Cast<JenisKelamin>().ToList())
            JenisKelamins.Add(new EnumModel<JenisKelamin>(item, ShareModel.Helper.AddWhiteSpaceInTitleCase(item.ToString())));

        Model = Account.Profile;

        AgamaSelected = Agamas.SingleOrDefault(x => x.Value == Model.Kepercayaan);
        KewarganegaraanSelected = Kewarganegaraans.SingleOrDefault(x => x.Value == Model.Kewarganegaraan);
        JenisKelaminSelected = JenisKelamins.SingleOrDefault(x => x.Value == Model.JenisKelamin);
        TempatTinggalSelected = TempatTinggals.SingleOrDefault(x => x.Value == Model.TempatTinggal);
        ModaTransportasiSelected = ModaTransportasis.SingleOrDefault(x => x.Value == Model.ModaTransportasi);


        SaveCoomand = new Command(SaveAction, SaveValidate);
    }


    private bool SaveValidate(object arg)
    {
        var resultValidator = validator.Validate(Model);
        if (!resultValidator.IsValid)
        {
            SaveText = "Simpan";
            return false;
        }
        SaveText = "Kirim";
        return true;
    }

    private async void SaveAction(object obj)
    {
        try
        {
            await Account.SetProfile(Account.Profile);
            var resultValidator = validator.Validate(Model);
            if (!resultValidator.IsValid)
            {
                var updated = await PendaftaranStore.Update(Model);
                await MessageHelper.InfoAsync("Data Berhasil Dikirim !");
                return;
            }
            await MessageHelper.InfoAsync("Lengkapi Data !");
        }
        catch (Exception ex)
        {
            await MessageHelper.ErrorAsync(ex.Message);
        }


    }
    private EnumModel<Agama> agamaSelected;
    public EnumModel<Agama> AgamaSelected
    {
        get { return agamaSelected; }
        set
        {
            SetProperty(ref agamaSelected, value);
            Model.Kepercayaan = value.Value;
        }
    }



    private EnumModel<JenisKelamin> jenisKelaminSelected;

    public EnumModel<JenisKelamin> JenisKelaminSelected
    {
        get { return jenisKelaminSelected; }
        set
        {
            SetProperty(ref jenisKelaminSelected, value);
            Model.JenisKelamin = value.Value;
        }
    }

    private EnumModel<Kewarganegaraan> kewarganegaraanSelected;

    public EnumModel<Kewarganegaraan> KewarganegaraanSelected
    {
        get { return kewarganegaraanSelected; }
        set
        {
            SetProperty(ref kewarganegaraanSelected, value);
            Model.Kewarganegaraan = value.Value;
        }
    }



    private EnumModel<TempatTinggal> tempatTinggalSelected;

    public EnumModel<TempatTinggal> TempatTinggalSelected
    {
        get { return tempatTinggalSelected; }
        set
        {
            SetProperty(ref tempatTinggalSelected, value);
            Model.TempatTinggal = value.Value;
        }
    }



    private EnumModel<ModaTransportasi> modaTransportasiSelected;

    public EnumModel<ModaTransportasi> ModaTransportasiSelected
    {
        get { return modaTransportasiSelected; }
        set
        {
            SetProperty(ref modaTransportasiSelected, value);
            Model.ModaTransportasi = value.Value;
        }
    }


    private string saveText = "Simpan";

    public string SaveText
    {
        get { return saveText; }
        set { SetProperty(ref saveText, value); }
    }




}