using FluentValidation;
using WebApp.Models;

namespace WebApp.Validators
{
    public class OratuaValidator:AbstractValidator<OrangTua>
    {
        public OratuaValidator()
        {
            RuleFor(x => x.TahunLahir).GreaterThan(1930);
            RuleFor(x => x.NIK).NotEmpty().NotNull();
            RuleFor(x => x.Nama).NotEmpty().NotNull();
        }
    }
}
