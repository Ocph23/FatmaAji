using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MySqlConnector;
using ShareModel;
using System.Reflection.Emit;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CalonPesertaDidik> CalonPesertaDidik { get; set; }
        public DbSet<Persyaratan> Persyaratan{ get; set; }
        public DbSet<AntrianZonasi> AntrianZonasi { get; set; }
        public DbSet<Informasi> Informasi { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}