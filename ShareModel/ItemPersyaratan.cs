namespace ShareModel
{
    public class ItemPersyaratan
    {
        public int Id { get; set; }
        public Persyaratan Persyaratan { get; set; }
        public string? FileName { get; set; }
        public string? Jawaban { get; set; }
    }
}
