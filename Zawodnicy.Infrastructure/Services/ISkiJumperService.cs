using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.Commands;

namespace Zawodnicy.Infrastructure.Services
{
    public interface ISkiJumperService
    {
        public Task<IEnumerable<SkiJumperDTO>> BrowseAll();
        public Task<IEnumerable<SkiJumperDTO>> BrowseAllAndFilter(string country, string lastName);
        public Task<SkiJumperDTO> GetById(int id);
        public Task<SkiJumperDTO> AddSkiJumper(CreateSkiJumper skiJumper);
        public Task DeleteSkiJumper(int id);
        public Task EditSkiJumper(UpdateSkiJumper skiJumper, int id);        
    }
}