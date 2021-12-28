using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class SkiJumpersRepository : ISkiJumpersRepository
    {
        //private static List<SkiJumper> _mockedSkiJumpers = new List<SkiJumper>();
        //private static int count = 0;
        private AppDbContext _appDbContext;

        public SkiJumpersRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(SkiJumper skiJumper)
        {
            try
            {
                _appDbContext.SkiJumper.Add(skiJumper);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<SkiJumper>> BrowseAllAndFilter(string country, string lastName)
        {
            try
            {
                return await Task.FromResult(_appDbContext.SkiJumper.Where(x => x.Country.Contains(country) || x.LastName.Contains(lastName)).AsEnumerable());
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task<IEnumerable<SkiJumper>> BrowseAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.SkiJumper);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try { 
                _appDbContext.Remove(_appDbContext.SkiJumper.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<SkiJumper> GetAsync(int id)
        {
            try
            {
                return _appDbContext.SkiJumper.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task UpdateAsync(SkiJumper skiJumper)
        {
            try
            {
                var s = _appDbContext.SkiJumper.FirstOrDefault(x => x.Id == skiJumper.Id);
                s.FirstName = skiJumper.FirstName;
                s.LastName = skiJumper.LastName;
                s.Trainer = skiJumper.Trainer;
                s.Country = skiJumper.Country;
                s.BirthDate = skiJumper.BirthDate;
                s.Height = skiJumper.Height;
                s.Weight = skiJumper.Weight;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
