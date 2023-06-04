namespace WebApp.Models
{
    public record Dashboard
    {
        public Dashboard(int totalPendaftar, int pria, int wanita, int lulus)
        {
            TotalPendaftar = totalPendaftar;
            Pria = pria;
            Wanita = wanita;
            Lulus = lulus;
        }

        public int TotalPendaftar { get; }
        public int Pria { get; }
        public int Wanita { get; }
        public int Lulus { get; }
    }
}
