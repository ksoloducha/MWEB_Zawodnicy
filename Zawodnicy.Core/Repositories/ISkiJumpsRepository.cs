using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ISkiJumpsRepository
    {
        Task UpdateAsync(SkiJump s);
        Task AddAsync(SkiJump s);
        Task DelAsync(SkiJump s);
        Task<SkiJump> GetAsync(int id);
        Task<IEnumerable<SkiJump>> BrowseAllAsync();
    }
}
