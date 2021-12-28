using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.Services
{
    public interface ITrainerService
    {
        public Task<IEnumerable<TrainerDTO>> BrowseAll();
        public Task<TrainerDTO> GetById(int id);
        public Task<TrainerDTO> Add(CreateTrainer trainer);
        public Task Delete(int id);
        public Task Edit(UpdateTrainer trainer, int id);
    }
}
