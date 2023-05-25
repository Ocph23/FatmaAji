using ShareModel;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IInformasiService
    {
        Task<IEnumerable<Informasi>> Get();
        Task<Informasi> Get(int id);
        Task<Informasi> Post(Informasi model);
        Task<Informasi> Put(Informasi model);
        Task<bool> Delete(int id);
    }


    public class InformasiService : IInformasiService
    {
        private readonly ApplicationDbContext dbcontext;

        public InformasiService(ApplicationDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public Task<bool> Delete(int id)
        {
            try
            {
                var oldData = dbcontext.Informasi.SingleOrDefault(x => x.Id == id);
                if (oldData is null)
                    throw new SystemException("Data Tidak Ditemukan !");
                
                dbcontext.Informasi.Remove(oldData); 
                dbcontext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Task<IEnumerable<Informasi>> Get()
        {
            var datas = dbcontext.Informasi.ToList();
            if(datas.Any()) {
                return Task.FromResult(datas.AsEnumerable());
            }
            return Task.FromResult(Enumerable.Empty<Informasi>());
        }

        public Task<Informasi> Get(int id)
        {
            return Task.FromResult(dbcontext.Informasi.SingleOrDefault(x=>x.Id==id));
        }

        public Task<Informasi> Post(Informasi model)
        {
            try
            {
                dbcontext.Informasi.Add(model);
                dbcontext.SaveChanges();
                return Task.FromResult(model);
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Task<Informasi> Put(Informasi model)
        {
            try
            {
                var oldData=   dbcontext.Informasi.SingleOrDefault(x=>x.Id==model.Id);
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
