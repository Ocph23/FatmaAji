using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IPendaftaranService
    {
        Task<IEnumerable<CalonPesertaDidik>> Get();
        Task<CalonPesertaDidik> GetById(int id);
        Task<CalonPesertaDidik> GetByUserId(string id);
        Task<CalonPesertaDidik> CreateProfile(string userId);
        Task<bool> UpdateProfile(CalonPesertaDidik calonPesertaDidik);

    }

    public class PendaftaranService : IPendaftaranService
    {
        private readonly ApplicationDbContext dbcontext;

        public PendaftaranService(ApplicationDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public Task<CalonPesertaDidik> CreateProfile(string userId)
        {
            var data = CalonPesertaDidik.Create(userId);
            dbcontext.CalonPesertaDidik.Add(data);
            dbcontext.SaveChanges();
            return Task.FromResult(data);
        }

        public Task<IEnumerable<CalonPesertaDidik>> Get()
        {
            var datas = dbcontext.CalonPesertaDidik.AsEnumerable();
            return Task.FromResult(datas);
        }

        public Task<CalonPesertaDidik> GetById(int id)
        {
            var data = dbcontext.CalonPesertaDidik.FirstOrDefault(x=>x.Id==id);
            return Task.FromResult(data!);
        }

        public async Task<CalonPesertaDidik> GetByUserId(string userid)
        {
            try
            {
                var data = dbcontext.CalonPesertaDidik.FirstOrDefault(x => x.UserId == userid);
                if (data is null)
                    data = await CreateProfile(userid);
                return data;
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
        }

        public Task<bool> UpdateProfile(CalonPesertaDidik calonPesertaDidik)
        {
            try
            {
                var data = dbcontext.CalonPesertaDidik
                    .Include(x=>x.Alamat)
                    .Include(x=>x.Periodik)
                    .Include(x=>x.Ibu)
                    .Include(x=>x.Ayah)
                    .Include(x=>x.Kontak)
                    .SingleOrDefault(x => x.Id == calonPesertaDidik.Id);

                dbcontext.Entry(data!).CurrentValues.SetValues(calonPesertaDidik);
                dbcontext.SaveChanges();
                return Task.FromResult(true);   
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
    }
}