using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ICompetitionsRepository
    {
        Task UpdateAsync(Competition z);
        Task AddAsync(Competition z);
        Task DelAsync(Competition z);
        Task<Competition> GetAsync(int id);
        Task<IEnumerable<Competition>> BrowseAllAsync();
    }
}
