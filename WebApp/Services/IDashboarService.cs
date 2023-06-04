using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IDashboarService
    {
        Task<Dashboard> GetDashboardAsync();
    }

    public class DashboarService : IDashboarService
    {
        private readonly ApplicationDbContext dbContext;

        public DashboarService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public Task<Dashboard> GetDashboardAsync()
        {
            var totalPendaftar = dbContext.CalonPesertaDidik.Count();
            var pria = dbContext.CalonPesertaDidik.Where(x=>x.JenisKelamin== ShareModel.JenisKelamin.Pria).Count();
            var wanita = dbContext.CalonPesertaDidik.Where(x=>x.JenisKelamin== ShareModel.JenisKelamin.Wanita).Count();
            var lulus = dbContext.CalonPesertaDidik.Where(x=>x.Status==  ShareModel.StatusPenerimaan.Lulus).Count();
            return Task.FromResult(new Dashboard(totalPendaftar, pria, wanita, lulus));
        }
    }
}
