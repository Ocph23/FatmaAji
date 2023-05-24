using FluentValidation;
using ShareModel;

namespace WebApp.Validators
{
    public class AddressValidator :AbstractValidator<Alamat>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Jalan).NotEmpty();                     
            RuleFor(x => x.RT).NotEmpty();                     
            RuleFor(x => x.RW).NotEmpty();
            RuleFor(x => x.Keluarahan).NotEmpty();
            RuleFor(x => x.Kecamatan).NotEmpty();
        }
    }
}
