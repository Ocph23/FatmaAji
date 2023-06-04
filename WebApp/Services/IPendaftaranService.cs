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
        Task<CalonPesertaDidik> CreateProfile(string userId, AntrianZonasi zonasi);
        Task<CalonPesertaDidik> UpdateProfile(CalonPesertaDidik calonPesertaDidik);
        Task<ItemPersyaratan> AddPersyaratan(int id, ItemPersyaratan model);
        Task<ItemPersyaratan> UpdatePersyaratan(int id, ItemPersyaratan model);
        Task<ItemPersyaratan> GetItemPersyaratan(int id);
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

        public Task<CalonPesertaDidik> CreateProfile(string userId, AntrianZonasi zona)
        {
            var data = CalonPesertaDidik.Create(userId, zona);


            foreach(var item in dbcontext.Persyaratan.ToList())
            {
                data.Persyaratan.Add(new ItemPersyaratan { Persyaratan = item });
            }
            
            dbcontext.Entry(data.Zonasi).State = EntityState.Unchanged;  
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
                    .Include(x => x.Zonasi)
                    .Include(x => x.Persyaratan).ThenInclude(x=>x.Persyaratan)
                    .FirstOrDefault(x => x.UserId == userid);

                if(data!=null)
                {
                    var persyaratans = dbcontext.Persyaratan.AsEnumerable();
                    var result = persyaratans.Where(x => !data.Persyaratan.Any(p => p.Persyaratan.Id == x.Id));
                    foreach (var item in result)
                    {
                        dbcontext.Entry(item).State = EntityState.Unchanged;
                        data.Persyaratan.Add(new ItemPersyaratan { Persyaratan = item });
                    }
                    dbcontext.SaveChanges();
                }

                if (data is null)
                    throw new SystemException("Data Tidak Ditemukan !");
                return data;
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
        }

        public Task<ItemPersyaratan> GetItemPersyaratan(int id)
        {
            var result = dbcontext.CalonPesertaDidik
                .Include(x => x.Persyaratan)
                .SelectMany(x => x.Persyaratan).FirstOrDefault(x=>x.Id==id);
            ArgumentNullException.ThrowIfNull(result);
            return Task.FromResult(result);
        }

        public Task<ItemPersyaratan> UpdatePersyaratan(int id, ItemPersyaratan model)
        {
            var data = dbcontext.CalonPesertaDidik
                .Include(x => x.Persyaratan)
                .SelectMany(x => x.Persyaratan).FirstOrDefault(x => x.Id == id);
            if (data is not null)
            {
                dbcontext.Entry(data).CurrentValues.SetValues(model);
                dbcontext.SaveChanges();
            }
            return Task.FromResult(model!);
        }

        public Task<CalonPesertaDidik> UpdateProfile(CalonPesertaDidik calonPesertaDidik)
        {
            try
            {
                var data = dbcontext.CalonPesertaDidik
                    .Include(x=>x.Alamat)
                    .Include(x=>x.Periodik)
                    .Include(x=>x.Ibu)
                    .Include(x=>x.Ayah)
                    .Include(x=>x.Kontak)
                    .Include(x=>x.Zonasi)
                    .FirstOrDefault(x=> x.Id == calonPesertaDidik.Id);

                var status = data.Status;
                calonPesertaDidik.Status = status;
                dbcontext.Entry(data).CurrentValues.SetValues(calonPesertaDidik);
                dbcontext.Entry(data.Alamat).CurrentValues.SetValues(calonPesertaDidik.Alamat);
                dbcontext.Entry(data.Ayah).CurrentValues.SetValues(calonPesertaDidik.Ayah);
                dbcontext.Entry(data.Ibu).CurrentValues.SetValues(calonPesertaDidik.Ibu);
                dbcontext.Entry(data.Periodik).CurrentValues.SetValues(calonPesertaDidik.Periodik);
                dbcontext.Entry(data.Kontak).CurrentValues.SetValues(calonPesertaDidik.Kontak);
                dbcontext.Entry(data.Zonasi).CurrentValues.SetValues(calonPesertaDidik.Zonasi);
                dbcontext.SaveChanges();
                return Task.FromResult(data);   
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
    }
}