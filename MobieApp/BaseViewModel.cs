using MobieApp.Services;
using ShareModel;

namespace MobieApp
{
    public class BaseViewModel  :BaseNotify
    {

        public IAccountService AccountStore => DependencyService.Get<IAccountService>();

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


	}
}
