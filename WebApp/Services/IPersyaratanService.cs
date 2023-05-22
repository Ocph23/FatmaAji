using ShareModel;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IPersyaratanService
    {
        Task<IEnumerable<Persyaratan>> Get();
        Task<Persyaratan> Get(int id);
        Task<Persyaratan> Post(Persyaratan model);
        Task<Persyaratan> Put(Persyaratan model);
        Task<bool> Delete(int id);
    }


    public class PersyaratanService : IPersyaratanService
    {
        private readonly ApplicationDbContext dbcontext;

        public PersyaratanService(ApplicationDbContext _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        public Task<bool> Delete(int id)
        {
            try
            {
                var oldData = dbcontext.Persyaratan.SingleOrDefault(x => x.Id == id);
                if (oldData is null)
                    throw new SystemException("Data Tidak Ditemukan !");
                
                dbcontext.Persyaratan.Remove(oldData); 
                dbcontext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Task<IEnumerable<Persyaratan>> Get()
        {
            var datas = dbcontext.Persyaratan.ToList();
            if(datas.Any()) {
                return Task.FromResult(datas.AsEnumerable());
            }
            return Task.FromResult(Enumerable.Empty<Persyaratan>());
        }

        public Task<Persyaratan> Get(int id)
        {
            return Task.FromResult(dbcontext.Persyaratan.SingleOrDefault(x=>x.Id==id));
        }

        public Task<Persyaratan> Post(Persyaratan model)
        {
            try
            {
                dbcontext.Persyaratan.Add(model);
                dbcontext.SaveChanges();
                return Task.FromResult(model);
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Task<Persyaratan> Put(Persyaratan model)
        {
            try
            {
                var oldData=   dbcontext.Persyaratan.SingleOrDefault(x=>x.Id==model.Id);
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
