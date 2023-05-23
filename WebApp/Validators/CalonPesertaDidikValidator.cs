using FluentValidation;
using WebApp.Models;

namespace WebApp.Validators
{
    public class CalonPesertaDidikValidator :AbstractValidator<CalonPesertaDidik>
    {

        public CalonPesertaDidikValidator()
        {
            RuleFor(x => x.Nama).NotNull().NotEmpty();
            RuleFor(x => x.TempatLahir).NotNull().NotEmpty();
            RuleFor(x => x.TanggalLahir).GreaterThanOrEqualTo(DateOnly.FromDateTime(new DateTime(2015,1,1)));
            RuleFor(x => x.Negara).NotNull().NotEmpty().When(x=>x.Kewarganegaraan== ShareModel.Kewarganegaraan.WNA);
            RuleFor(x => x.ModaTransportasiLain).NotNull().NotEmpty().When(x=>x.ModaTransportasi== ShareModel.ModaTransportasi.Lainnya);
            RuleFor(x => x.TempatTinggalLain).NotNull().NotEmpty().When(x=>x.TempatTinggal== ShareModel.TempatTinggal.Lainnya);
            RuleFor(x => x.Alamat).SetValidator(new AddressValidator());
            RuleFor(x => x.Kontak).SetValidator(new KontakValidator());
            RuleFor(x => x.Ayah).SetValidator(new OratuaValidator());
            RuleFor(x => x.Ibu).SetValidator(new OratuaValidator());
            RuleFor(x => x.Periodik).SetValidator(new PeriodikValidator());
        }


    }
}
