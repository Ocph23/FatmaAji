namespace WebApp.Models
{
    public class UserModel
    {
        public string UserId{ get; set; }
        public string Name{ get; set; }
        public bool Active { get; set; }
        public CalonPesertaDidik Calon{ get; set; }

    }
}
