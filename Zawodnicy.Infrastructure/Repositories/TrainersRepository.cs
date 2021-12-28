using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class TrainersRepository : ITrainersRepository
    {
        private AppDbContext _appDbContext;

        public TrainersRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Trainer t)
        {
            try
            {
                _appDbContext.Trainer.Add(t);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Trainer>> BrowseAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.Trainer);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Trainer.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Trainer> GetAsync(int id)
        {
            try
            {
                return _appDbContext.Trainer.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task UpdateAsync(Trainer t)
        {
            try
            {
                var s = _appDbContext.Trainer.FirstOrDefault(x => x.Id == t.Id);
                s.FirstName = t.FirstName;
                s.LastName = t.LastName;
                s.BirthDate = t.BirthDate;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
