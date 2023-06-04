using ShareModel;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IAntrianZonasiService
    {
        Task<IEnumerable<AntrianZonasi>> Get();
        Task<AntrianZonasi> Get(int id);
        Task<AntrianZonasi> Post(AntrianZonasi model);
        Task<AntrianZonasi> Put(AntrianZonasi model);
        Task<bool> Delete(int id);
    }


    public class AntrianZonasiService : IAntrianZonasiService
    {
        private readonly ApplicationDbContext dbcontext;

        public AntrianZonasiService(ApplicationDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public Task<bool> Delete(int id)
        {
            try
            {
                var oldData = dbcontext.AntrianZonasi.SingleOrDefault(x => x.Id == id);
                if (oldData is null)
                    throw new SystemException("Data Tidak Ditemukan !");

                dbcontext.AntrianZonasi.Remove(oldData);
                dbcontext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Task<IEnumerable<AntrianZonasi>> Get()
        {
            var datas = dbcontext.AntrianZonasi.ToList();
            if (datas.Any())
            {
                return Task.FromResult(datas.AsEnumerable());
            }
            return Task.FromResult(Enumerable.Empty<AntrianZonasi>());
        }

        public Task<AntrianZonasi> Get(int id)
        {
            return Task.FromResult(dbcontext.AntrianZonasi.SingleOrDefault(x => x.Id == id));
        }

        public Task<AntrianZonasi> Post(AntrianZonasi model)
        {
            try
            {
                dbcontext.AntrianZonasi.Add(model);
                dbcontext.SaveChanges();
                return Task.FromResult(model);
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Task<AntrianZonasi> Put(AntrianZonasi model)
        {
            try
            {
                var oldData = dbcontext.AntrianZonasi.SingleOrDefault(x => x.Id == model.Id);
                if (oldData is null)
                    throw new SystemException("Data Tidak Ditemukan !");
                dbcontext.SaveChanges();
                return Task.FromResult(model);
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
    }

}
