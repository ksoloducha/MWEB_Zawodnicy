using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface IParticipationsRepository
    {
        Task UpdateAsync(Participation u);
        Task AddAsync(Participation u);
        Task DelAsync(Participation u);
        Task<Participation> GetAsync(int id);
        Task<IEnumerable<Participation>> BrowseAllAsync();
    }
}
