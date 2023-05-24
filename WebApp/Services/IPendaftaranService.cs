using Microsoft.EntityFrameworkCore;
using ShareModel;
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
        Task<ItemPersyaratan> AddPersyaratan(int id, ItemPersyaratan model);
        Task<ItemPersyaratan> UpdatePersyaratan(int id, ItemPersyaratan model);
    }

    public class PendaftaranService : IPendaftaranService
    {
        private readonly ApplicationDbContext dbcontext;

        public PendaftaranService(ApplicationDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public Task<ItemPersyaratan> AddPersyaratan(int id, ItemPersyaratan model)
        {
            var data = dbcontext.CalonPesertaDidik.Include(x=>x.Persyaratan).FirstOrDefault(x => x.Id == id);
            if(data is not null)
            {
                dbcontext.Entry(model.Persyaratan).State = EntityState.Unchanged;
                data.Persyaratan.Add(model);

                dbcontext.SaveChanges();
            }
            return Task.FromResult(model!);
        }

        public Task<CalonPesertaDidik> CreateProfile(string userId)
        {
            var data = CalonPesertaDidik.Create(userId);

            foreach(var item in dbcontext.Persyaratan.ToList())
            {
                data.Persyaratan.Add(new ItemPersyaratan { Persyaratan = item });
            }
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
                var data = dbcontext.CalonPesertaDidik
                     .Include(x => x.Alamat)
                    .Include(x => x.Periodik)
                    .Include(x => x.Ibu)
                    .Include(x => x.Ayah)
                    .Include(x => x.Kontak)
                    .FirstOrDefault(x => x.UserId == userid);
                if (data is null)
                    data = await CreateProfile(userid);
                return data;
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
        }

        public Task<ItemPersyaratan> UpdatePersyaratan(int id, ItemPersyaratan model)
        {
            var data = dbcontext.CalonPesertaDidik.Include(x => x.Persyaratan)
                .Where(x=>x.Persyaratan.Where(x=>x.Id==id).Count()>0).SelectMany(x=>x.Persyaratan).FirstOrDefault();
            if (data is not null)
            {
                dbcontext.Entry(data).CurrentValues.SetValues(model);
                dbcontext.SaveChanges();
            }
            return Task.FromResult(model!);
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
                    .FirstOrDefault(x=> x.Id == calonPesertaDidik.Id);

                dbcontext.Entry(data).CurrentValues.SetValues(calonPesertaDidik);
                dbcontext.Entry(data.Alamat).CurrentValues.SetValues(calonPesertaDidik.Alamat);
                dbcontext.Entry(data.Ayah).CurrentValues.SetValues(calonPesertaDidik.Ayah);
                dbcontext.Entry(data.Ibu).CurrentValues.SetValues(calonPesertaDidik.Ibu);
                dbcontext.Entry(data.Periodik).CurrentValues.SetValues(calonPesertaDidik.Periodik);
                dbcontext.Entry(data.Kontak).CurrentValues.SetValues(calonPesertaDidik.Kontak);
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