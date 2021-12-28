using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ISkiJumpersRepository
    {
        Task UpdateAsync(SkiJumper z);
        Task AddAsync(SkiJumper z);
        Task DeleteAsync(int id);
        Task<SkiJumper> GetAsync(int id);
        Task<IEnumerable<SkiJumper>> BrowseAllAsync();
        Task<IEnumerable<SkiJumper>> BrowseAllAndFilter(string country, string lastName);
    }
}
