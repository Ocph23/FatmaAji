using ShareModel;

namespace MobieApp.Models
{
    public class Register : BaseNotify
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }


        private string email;

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }


        private string password;

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }



        private string confirmPasssword;

        public string ConfirmPassword
        {
            get { return confirmPasssword; }
            set { SetProperty(ref confirmPasssword, value); }
        }

        private bool isZonasi;

        public bool IsZonasi
        {
            get { return isZonasi; }
            set { SetProperty(ref isZonasi, value); }
        }

    }

}