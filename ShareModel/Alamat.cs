namespace ShareModel
{
    public class Alamat:BaseNotify
    {
        private int id;
        private string? kec;
        private string? kelurahan;
        private string? rw;
        private string? rt;
        private string? jalan;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }
        public string? Jalan  {
            get { return jalan; }
            set { SetProperty(ref jalan, value); }
        }
        public string? RT  {
            get { return rt; }
            set { SetProperty(ref rt, value); }
        }
        public string? RW  {
            get { return rw; }
            set { SetProperty(ref rw, value); }
        }
        public string? Keluarahan  {
            get { return kelurahan; }
            set { SetProperty(ref kelurahan, value); }
        }
        public string? Kecamatan  {
            get { return kec; }
            set { SetProperty(ref kec, value); }
        }
    }


}
