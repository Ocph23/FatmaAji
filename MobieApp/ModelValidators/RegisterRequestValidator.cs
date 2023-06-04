using FluentValidation;
using MobieApp.Models;

namespace ShareModel
{
    public class RegisterRequestValidator : AbstractValidator<Register>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).Equal(x=>x.ConfirmPassword);
            RuleFor(x => x.ConfirmPassword).NotEmpty();
            RuleFor(x => x.Zonasi).NotNull();
        }
    }
}
