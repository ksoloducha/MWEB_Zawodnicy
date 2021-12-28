using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.Services;

namespace Zawodnicy.Infrastructure.Repositories
{
	public class SkiJumperService : ISkiJumperService
	{
		private readonly ISkiJumpersRepository _skiJumperRepository;

        public SkiJumperService(ISkiJumpersRepository skiJumperRepository)
        {
            _skiJumperRepository = skiJumperRepository;
        }

        public async Task<SkiJumperDTO> AddSkiJumper(CreateSkiJumper skiJumper)
        {
            SkiJumper newSkiJumper = new SkiJumper()
            {
                FirstName = skiJumper.FirstName,
                LastName = skiJumper.LastName,
                Country = skiJumper.Country,
                BirthDate = skiJumper.BirthDate,
                Height = skiJumper.Height,
                Weight = skiJumper.Weight
            };
            await _skiJumperRepository.AddAsync(newSkiJumper);
            return new SkiJumperDTO()
            {
                FirstName = skiJumper.FirstName,
                LastName = skiJumper.LastName,
                Country = skiJumper.Country,
                BirthDate = skiJumper.BirthDate,
                Height = skiJumper.Height,
                Weight = skiJumper.Weight
            };
        }

        private SkiJumperDTO mapToDto(SkiJumper skiJumperEntity)
        {
            return new SkiJumperDTO()
            {
                Id = skiJumperEntity.Id,
                FirstName = skiJumperEntity.FirstName,
                LastName = skiJumperEntity.LastName,
                Country = skiJumperEntity.Country,
                BirthDate = skiJumperEntity.BirthDate,
                Height = skiJumperEntity.Height,
                Weight = skiJumperEntity.Weight
            };
        }

        public async Task<IEnumerable<SkiJumperDTO>> BrowseAll()
        {
            var skiJumpersEntities = await _skiJumperRepository.BrowseAllAsync();
            return skiJumpersEntities.Select(skiJumperEntity => mapToDto(skiJumperEntity));
        }

        public async Task<IEnumerable<SkiJumperDTO>> BrowseAllAndFilter(string country, string lastName)
        {
            var skiJumpersEntities = await _skiJumperRepository.BrowseAllAndFilter(country, lastName);
            return skiJumpersEntities.Select(skiJumperEntity => mapToDto(skiJumperEntity));
        }

        public async Task DeleteSkiJumper(int id)
        {
            await _skiJumperRepository.DeleteAsync(id);
        }

        public async Task EditSkiJumper(UpdateSkiJumper skiJumper, int id)
        {
            SkiJumper updatedSkiJumper = new SkiJumper()
            {
                Id = id,
                FirstName = skiJumper.FirstName,
                LastName = skiJumper.LastName,
                Trainer = skiJumper.Trainer,
                Country = skiJumper.Country,
                BirthDate = skiJumper.BirthDate,
                Height = skiJumper.Height,
                Weight = skiJumper.Weight
            };
            await _skiJumperRepository.UpdateAsync(updatedSkiJumper);
        }

        public async Task<SkiJumperDTO> GetById(int id)
        {
            var skiJumper = await _skiJumperRepository.GetAsync(id);
            return mapToDto(skiJumper);
        }
    }
}
