using ShareModel;

namespace WebApp.Models
{
    public class CalonPesertaDidik
    {
        public int Id { get; set; }

        public string? Nama { get; set; } =string.Empty;

        public JenisKelamin JenisKelamin { get; set; }

        //public string NISN { get; set; }

        public string? TempatLahir { get; set; } = string.Empty;

        public DateTime TanggalLahir { get; set; }

        public Agama Kepercayaan { get; set; }

        public Kewarganegaraan Kewarganegaraan { get;set; }
        public string? Negara { get;set; }

        public Alamat? Alamat { get; set; } = new ();
        public Kontak? Kontak { get; set; } = new();
        public Periodik? Periodik{ get; set; } = new();
        public OrangTua? Ayah{ get; set; }= new OrangTua();
        public OrangTua? Ibu{ get; set; }= new OrangTua();

        public  TempatTinggal TempatTinggal { get; set; }
        public string? TempatTinggalLain { get; set; }

        public ModaTransportasi ModaTransportasi { get; set; }
        public string? ModaTransportasiLain { get; set; }

        public string? KKS { get; set; }
        public int AnakKe { get; set; } = 1;
        public string? KPS { get; set; }
        public string? PIP { get; set; }
        public bool TK { get; set; }

        public string UserId { get; set; }

        internal static CalonPesertaDidik Create(string userId)
        {
            return new CalonPesertaDidik() { UserId = userId };
        }
    }


    public class OrangTua {
        public int Id { get; set; }
        public string? Nama{ get; set; }
        public string? NIK{ get; set; }

        public int TahunLahir { get; set; }

        public Pendidikan  Pendidikan { get; set; }
        public Pekerjaan Pekerjaan { get; set; }
        public Penghasilan Penghasilan { get; set; }


    }

}
