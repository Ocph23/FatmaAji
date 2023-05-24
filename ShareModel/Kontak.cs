using System.Xml.Linq;

namespace ShareModel
{
    public class Kontak    :BaseNotify
    {
        private string? email;
        private string? hp;
        private string? tel;
        private int id;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }
        public string? Telepon
        {
            get { return tel; }
            set { SetProperty(ref tel, value); }
        }
        public string? HP {
            get { return hp; }
            set { SetProperty(ref hp, value); }
        }
        public string? Email {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

    }


}
