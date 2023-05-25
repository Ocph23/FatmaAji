namespace ShareModel
{
    public class ItemPersyaratan
    {
        public int Id { get; set; }
        public Persyaratan Persyaratan { get; set; }
        public string? FileName { get; set; }
        public bool? Jawaban { get; set; }
        public bool Verifikasi { get; set; }


    }
}
