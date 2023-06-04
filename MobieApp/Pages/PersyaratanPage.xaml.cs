using MobieApp.Models;
using MobieApp.Services;
using ShareModel;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MobieApp.Pages;

public partial class PersyaratanPage : ContentPage
{
    public PersyaratanPage()
    {
        InitializeComponent();
        BindingContext = new PersyaratanViewModel();
    }
}


public partial class PersyaratanViewModel : BaseViewModel
{
    public ObservableCollection<DataPersyaratan> Datas { get; set; } = new ObservableCollection<DataPersyaratan>();
    public Command UploadCommand { get; }
    public CalonPesertaDidik Permohonan { get; set; }
    public PersyaratanViewModel()
    {
        UploadCommand = new Command(async (x) => await UploadAction(x));
        this.Permohonan = Account.Profile;
        _ = LoadData();
    }

    private async Task LoadData()
    {
        try
        {
            IsBusy = true;

            if (this.Permohonan != null)
            {
                Datas.Clear();
                foreach (var item in Permohonan.Persyaratan)
                {
                    Datas.Add(new DataPersyaratan() { Persyaratan = item.Persyaratan, FileName = item.FileName, Id = item.Id });
                }
            }
        }
        catch (Exception ex)
        {
            await MessageHelper.ErrorAsync(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async Task UploadAction(object obj)
    {
        if (obj is DataPersyaratan syarat)
        {
            var data = await PickAndShow(syarat, new PickOptions { FileTypes = FilePickerFileType.Pdf, PickerTitle = "Dokumen" });
        }
    }



    public async Task<FileResult> PickAndShow(DataPersyaratan syarat, PickOptions options)
    {
        try
        {
            IsBusy = true;
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("pdf", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);

                    var content = new MultipartFormDataContent();
                    content.Add(new StreamContent(await result.OpenReadAsync()), "file", result.FileName);
                    string fileName = await PendaftaranStore.UpdatePersyaratan(syarat.Id, content);
                    var data = this.Permohonan.Persyaratan.SingleOrDefault(x => x.Id == syarat.Id);
                    if (data != null)
                    {
                        data.FileName = fileName;
                        syarat.FileName = fileName;
                        await Account.SetProfile(Permohonan);
                    }

                }
                else
                {
                    await MessageHelper.ErrorAsync("Dokumen Harus Dalam Bentuk PDF");
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            await MessageHelper.ErrorAsync(ex.Message);
        }
        finally
        {
            IsBusy = false;
        }

        return null;
    }



}

//public class PersyaratanViewModel : BaseViewModel
//{
//    public PersyaratanViewModel()
//    {
//        LoadCommand = new Command(LoadAction);
//    }

//    public Command LoadCommand { get; }

//    private async void LoadAction(object obj)
//    {
//        try
//        {
//            var calon = Account.Profile;
//            var persyaatans = await PersyaratanStore.GetPersyaratan();
//            foreach (var item in persyaatans)
//            {
//                var notExists = calon.Persyaratan.SingleOrDefault(x => x.Persyaratan.Id == item.Id);
//                if (notExists is null)
//                {
//                    calon.Persyaratan.Add(new ShareModel.ItemPersyaratan { Persyaratan = item });
//                }
//            }
//        }
//        catch (Exception ex)
//        {
//           await MessageHelper.ErrorAsync(ex.Message);
//        }
//    }
//}