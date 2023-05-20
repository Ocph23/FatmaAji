using ShareModel;

namespace WebApp.Models
{
    public class CalonPesertaDidik
    {
        public int Id { get; set; }

        public string Nama { get; set; }

        public JenisKelamin JenisKelamin { get; set; }

        //public string NISN { get; set; }

        public string TempatLahir { get; set; }

        public DateTime TanggalLahir { get; set; }

        public Agama Kepercayaan { get; set; }

        public Kewarganegaraan Kewarganegaraan { get;set; }
        public string? Negara { get;set; }

        public Alamat? Alamat { get; set; }
        public Kontak? Kontak{ get; set; }
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
        public string UserId { get; set; }
    }


    public class OrangTua {
        public int Id { get; set; }
        public string? Nama{ get; set; }
        public string? NIK{ get; set; }

        public int TahunLahir { get; set; }

        public Pendidikan  Pendidikan { get; set; }

    }


    public enum Pendidikan
    {
        TidakSekolah, PutusSd, SDSederajat, SMPSederajat, SMASederajat, D1,D2, D3, S1, S2, S3
    }


    public enum Pekerjaan
    {
        TidakBekerja, Nelayan, Petani, Peternak, PNS,Karyawan, PedagangKecil, PedagangBesar, Wiraswasta, Wirausaha,Buruh, Pensiunan, TenagaKerjaIndonesia, SudahMeninggal 
    }


    public enum Penghasilan
    {
        KurangRP1, RP1TORP2, LebihRP2
    }

}
