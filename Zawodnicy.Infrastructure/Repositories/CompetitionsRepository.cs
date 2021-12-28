using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class CompetitionsRepository : ICompetitionsRepository
    {
        public Task AddAsync(Competition z)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Competition>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Competition z)
        {
            throw new NotImplementedException();
        }

        public Task<Competition> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Competition z)
        {
            throw new NotImplementedException();
        }
    }
}
