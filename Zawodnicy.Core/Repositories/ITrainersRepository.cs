using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ITrainersRepository
    {
        Task UpdateAsync(Trainer t);
        Task AddAsync(Trainer t);
        Task DelAsync(int id);
        Task<Trainer> GetAsync(int id);
        Task<IEnumerable<Trainer>> BrowseAllAsync();
    }
}
