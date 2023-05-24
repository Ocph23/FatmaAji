using FluentValidation;

namespace ShareModel
{
    public class KontakValidator : AbstractValidator<Kontak>
    {
        public KontakValidator()
        {
            RuleFor(x => x.Email).EmailAddress().When(x=>!string.IsNullOrEmpty(x.Email));
            RuleFor(x => x.HP).NotEmpty();
        }
    }
}
