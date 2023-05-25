namespace ShareModel
{
    public class Informasi
    {
        public int Id { get; set; }
        public DateTime? Tanggal { get; set; }=DateTime.Now;
        public string? Pesan { get; set; }=string.Empty;
        public bool Publish { get; set; } = true;
    }

}
