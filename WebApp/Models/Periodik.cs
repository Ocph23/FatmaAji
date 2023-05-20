namespace WebApp.Models
{
    public class Periodik
    {
        public int Id { get; set; }
        public double Tinggi { get; set; }
        public double LingkarKepala{ get; set; }
        public double Berat { get; set; }
        public double JarakKeSekolah { get; set; }
        public TimeSpan WaktuTempuh { get; set; }
        public int JumlahSaudara { get; set; }
        public bool DariTK { get; set; } = true;

    }


}
