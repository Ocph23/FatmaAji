using FluentValidation;

namespace ShareModel
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
