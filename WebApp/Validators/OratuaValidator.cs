using FluentValidation;
using ShareModel;
using WebApp.Models;

namespace WebApp.Validators
{
    public class OratuaValidator:AbstractValidator<OrangTua>
    {
        public OratuaValidator()
        {
            RuleFor(x => x.Nama).NotNull();
            RuleFor(x => x.NIK).NotEmpty();
            RuleFor(x => x.TahunLahir).GreaterThan(1930);
        }
    }
}
