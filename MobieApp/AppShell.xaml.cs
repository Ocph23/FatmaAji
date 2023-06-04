using Microsoft.Maui.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MobieApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new AppShellViewModel();
        }
    }

    internal class AppShellViewModel : BaseViewModel
    {

        private bool showStatus;

        public bool ShowStatus
        {
            get { return showStatus; }
            set { SetProperty(ref showStatus, value); }
        }

        

        public AppShellViewModel()
        {
            var profile = Account.Profile;
            ShowStatus = profile != null && profile.Status != ShareModel.StatusPenerimaan.None ? true : false;
        }
    }
}