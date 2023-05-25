using FluentValidation.Results;
using MobieApp.Services;
using ShareModel;

namespace MobieApp
{
    public class BaseViewModel  :BaseNotify
    {

        public IAccountService AccountStore => DependencyService.Get<IAccountService>();
        public IPendaftaranService PendaftaranStore => DependencyService.Get<IPendaftaranService>();
        public IPersyaratanService PersyaratanStore => DependencyService.Get<IPersyaratanService>();
        public IInformasiService InformasiStore => DependencyService.Get<IInformasiService>();

        private string titile;

		public string Title
		{
			get { return titile; }
			set { SetProperty(ref titile , value); }
		}


		private bool isBusy;

		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy , value); }
		}

        private List<ValidationFailure> errors;

        public List<ValidationFailure> Errors
        {
            get { return errors; }
            set { SetProperty(ref errors, value); }
        }


    }
}
