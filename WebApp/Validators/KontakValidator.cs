using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using WebApp.Models;

namespace WebApp.Validators
{
    public class KontakValidator : AbstractValidator<Kontak>
    {
        public KontakValidator()
        {
            RuleFor(x => x.Email).EmailAddress().When(x=>!x.Email.IsNullOrEmpty());
            RuleFor(x => x.HP).NotEmpty().NotNull();
        }
    }
}
