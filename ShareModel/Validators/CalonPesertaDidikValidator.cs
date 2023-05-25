using FluentValidation;

namespace ShareModel
{
    public class CalonPesertaDidikValidator :AbstractValidator<CalonPesertaDidik>
    {

        public CalonPesertaDidikValidator()
        {
            RuleFor(x => x.Nama).NotEmpty();
            RuleFor(x => x.TempatLahir).NotEmpty();
            RuleFor(x => x.TanggalLahir).GreaterThan(new DateTime(2014,1,1));
            RuleFor(x => x.Negara).NotEmpty().When(x=>x.Kewarganegaraan== ShareModel.Kewarganegaraan.WNA);
            RuleFor(x => x.ModaTransportasiLain).NotEmpty().When(x=>x.ModaTransportasi== ShareModel.ModaTransportasi.Lainnya);
            RuleFor(x => x.TempatTinggalLain).NotEmpty().When(x=>x.TempatTinggal== ShareModel.TempatTinggal.Lainnya);
            RuleFor(x => x.Alamat).SetValidator(new AddressValidator());
            RuleFor(x => x.Kontak).SetValidator(new KontakValidator());
            RuleFor(x => x.Ayah).SetValidator(new OratuaValidator());
            RuleFor(x => x.Ibu).SetValidator(new OratuaValidator());
            RuleFor(x => x.Periodik).SetValidator(new PeriodikValidator());
        }


    }
}
