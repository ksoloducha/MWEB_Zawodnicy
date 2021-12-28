using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ICitiesRepository
    {
        Task UpdateAsync(City m);
        Task AddAsync(City m);
        Task DelAsync(City m);
        Task<City> GetAsync(int id);
        Task<IEnumerable<City>> BrowseAllAsync();
    }
}
