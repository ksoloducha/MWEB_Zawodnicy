using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;
using Zawodnicy.Infrastructure.Services;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainersRepository _trainersRepository;

        public TrainerService(ITrainersRepository trainersRepository)
        {
            _trainersRepository = trainersRepository;
        }

        public async Task<TrainerDTO> Add(CreateTrainer trainer)
        {
            Trainer newTrainer = new Trainer()
            {
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                BirthDate = trainer.BirthDate
            };
            await _trainersRepository.AddAsync(newTrainer);

            return new TrainerDTO()
            {
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                BirthDate = trainer.BirthDate
            };
        }

        public async Task<IEnumerable<TrainerDTO>> BrowseAll()
        {
            var trainersEntities = await _trainersRepository.BrowseAllAsync();
            return trainersEntities.Select(trainerEntity => mapToDto(trainerEntity));
        }

        private TrainerDTO mapToDto(Trainer trainerEntity)
        {
            return new TrainerDTO()
            {
                Id = trainerEntity.Id,
                FirstName = trainerEntity.FirstName,
                LastName = trainerEntity.LastName,
                BirthDate = trainerEntity.BirthDate
            };
        }

        public async Task Delete(int id)
        {
            await _trainersRepository.DelAsync(id);
        }

        public async Task Edit(UpdateTrainer trainer, int id)
        {
            Trainer updatedTrainer = new Trainer()
            {
                Id = id,
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                BirthDate = trainer.BirthDate
            };
            await _trainersRepository.UpdateAsync(updatedTrainer);
        }

        public async Task<TrainerDTO> GetById(int id)
        {
            var trainer = await _trainersRepository.GetAsync(id);
            return mapToDto(trainer);
        }
    }
}
