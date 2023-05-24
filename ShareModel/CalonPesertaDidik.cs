
namespace ShareModel
{
    public class CalonPesertaDidik :BaseNotify
    {
        

        private int id;
        private string name=string.Empty;
        private JenisKelamin jk;
        private string tl = string.Empty;
        private DateOnly tanggalLahir;
        private string nisn = string.Empty;
        private Agama agama;
        private Kewarganegaraan kewarganegaraan;
        private string negara = string.Empty;
        private Alamat alamat = new();
        private Kontak kontak = new();
        private OrangTua ayah = new();
        private OrangTua ibu = new();
        private Periodik periodik = new();
        private ICollection<ItemPersyaratan> persyaratan=new List<ItemPersyaratan>();
        private string userId = string.Empty;
        private TempatTinggal tempatTinggal;
        private string tempatTinggalLain = string.Empty;
        private ModaTransportasi trans;
        private string translain = string.Empty;
        private string kks = string.Empty;
        private int anakke=1;
        private string kps = string.Empty;
        private string pip = string.Empty;
        private bool tk;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public string? Nama
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public JenisKelamin JenisKelamin
        {
            get { return jk; }
            set { SetProperty(ref jk, value); }
        }

        public string NISN
        {
            get { return nisn; }
            set { SetProperty(ref nisn, value); }
        }

        public string? TempatLahir
        {
            get { return tl; }
            set { SetProperty(ref tl, value); }
        }

        public DateOnly TanggalLahir
        {
            get { return tanggalLahir; }
            set { SetProperty(ref tanggalLahir, value); }
        }

        public Agama Kepercayaan
        {
            get { return agama; }
            set { SetProperty(ref agama, value); }
        }

        public Kewarganegaraan Kewarganegaraan
        {
            get { return kewarganegaraan; }
            set { SetProperty(ref kewarganegaraan, value); }
        }
        public string? Negara
        {
            get { return negara; }
            set { SetProperty(ref negara, value); }
        }

        public Alamat? Alamat
        {
            get { return alamat; }
            set { SetProperty(ref alamat, value); }
        }
        public Kontak? Kontak
        {
            get { return kontak; }
            set { SetProperty(ref kontak, value); }
        }
        public Periodik? Periodik
        {
            get { return periodik; }
            set { SetProperty(ref periodik, value); }
        }
        public OrangTua? Ayah
        {
            get { return ayah; }
            set { SetProperty(ref ayah, value); }
        }
        public OrangTua? Ibu
        {
            get { return ibu; }
            set { SetProperty(ref ibu, value); }
        }
        public TempatTinggal TempatTinggal
        {
            get { return tempatTinggal; }
            set { SetProperty(ref tempatTinggal, value); }
        }
        public string? TempatTinggalLain
        {
            get { return tempatTinggalLain; }
            set { SetProperty(ref tempatTinggalLain, value); }
        }
        public ModaTransportasi ModaTransportasi
        {
            get { return trans; }
            set { SetProperty(ref trans, value); }
        }
        public string? ModaTransportasiLain
        {
            get { return translain; }
            set { SetProperty(ref translain, value); }
        }
        public string? KKS
        {
            get { return kks; }
            set { SetProperty(ref kks, value); }
        }
        public int AnakKe
        {
            get { return anakke; }
            set { SetProperty(ref anakke, value); }
        }
        public string? KPS
        {
            get { return kps; }
            set { SetProperty(ref kps, value); }
        }
        public string? PIP
        {
            get { return pip; }
            set { SetProperty(ref pip, value); }
        }
        public bool TK
        {
            get { return tk; }
            set { SetProperty(ref tk, value); }
        }
        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }
        public ICollection<ItemPersyaratan> Persyaratan
        {
            get { return persyaratan; }
            set { SetProperty(ref persyaratan, value); }
        }

        public static CalonPesertaDidik Create(string userId)
        {
            return new CalonPesertaDidik() { UserId = userId };
        }
    }

}
