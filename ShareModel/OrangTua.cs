using ShareModel;

namespace ShareModel
{
    public class OrangTua : BaseNotify
    {
        private Pekerjaan pekerjaan;
        private Penghasilan penghasilan;
        private Pendidikan pendidikan;
        private int tl;
        private string? nik;
        private string? nama;
        private int id;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }
        public string? Nama
        {
            get { return nama; }
            set { SetProperty(ref nama, value); }
        }
        public string? NIK
        {
            get { return nik; }
            set { SetProperty(ref nik, value); }
        }

        public int TahunLahir
        {
            get { return tl; }
            set { SetProperty(ref tl, value); }
        }

        public Pendidikan Pendidikan
        {
            get { return pendidikan; }
            set { SetProperty(ref pendidikan, value); }
        }
        public Pekerjaan Pekerjaan
        {
            get { return pekerjaan; }
            set { SetProperty(ref pekerjaan, value); }
        }
        public Penghasilan Penghasilan
        {
            get { return penghasilan; }
            set { SetProperty(ref penghasilan, value); }
        }
    }

}
