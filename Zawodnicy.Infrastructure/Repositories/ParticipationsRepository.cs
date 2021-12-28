using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class ParticipationsRepository : IParticipationsRepository
    {
        public Task AddAsync(Participation u)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Participation>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Participation u)
        {
            throw new NotImplementedException();
        }

        public Task<Participation> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Participation u)
        {
            throw new NotImplementedException();
        }
    }
}
