namespace ShareModel
{
    public class Periodik:BaseNotify
    {
        private int jumlah;
        private TimeSpan waktu;
        private double jarak;
        private double berat;
        private double lingkar;
        private double tinggi;
        private int id;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }
        public double Tinggi {
            get { return tinggi; }
            set { SetProperty(ref tinggi, value); }
        }
        public double LingkarKepala{
            get { return lingkar; }
            set { SetProperty(ref lingkar, value); }
        }
        public double Berat {
            get { return berat; }
            set { SetProperty(ref berat, value); }
        }
        public double JarakKeSekolah {
            get { return jarak; }
            set { SetProperty(ref jarak, value); }
        }
        public TimeSpan WaktuTempuh {
            get { return waktu; }
            set { SetProperty(ref waktu, value); }
        }
        public int JumlahSaudara {
            get { return jumlah; }
            set { SetProperty(ref jumlah, value); }
        }

    }


}
