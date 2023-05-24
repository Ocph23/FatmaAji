using FluentValidation;

namespace ShareModel
{
    public class PeriodikValidator : AbstractValidator<Periodik>
    {
        public PeriodikValidator()
        {
            RuleFor(x => x.WaktuTempuh).GreaterThan(new TimeSpan());
            RuleFor(x => x.JarakKeSekolah).GreaterThan(0);
            RuleFor(x => x.LingkarKepala).GreaterThan(0);
            RuleFor(x => x.Berat).GreaterThan(0);
            RuleFor(x => x.Tinggi).GreaterThan(0);
        }
    }
}
