using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;
using Zawodnicy.Infrastructure;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.Repositories;

namespace ZawodnicyTest
{
    [TestClass]
    public class TestBase
    {
        protected readonly Mock<ISkiJumpersRepository> _mockedSkiJumpersRepository;
        protected readonly SkiJumperService _skiJumpersService;

        public TestBase()
        {
            _mockedSkiJumpersRepository = new Mock<ISkiJumpersRepository>();
            _skiJumpersService = new SkiJumperService(_mockedSkiJumpersRepository.Object);
        }

        protected SkiJumper SkiJumperBase()
        {
            return new SkiJumper()
            {
                Id = 1,
                FirstName = "Ala",
                LastName = "Makota",
                Country = "Zasiedmiogórogród"
            };
        }

        protected SkiJumperDTO SkiJumperDtoBase()
        {
            SkiJumper skiJumper = SkiJumperBase();
            return new SkiJumperDTO()
            {
                Id = skiJumper.Id,
                FirstName = skiJumper.FirstName,
                LastName = skiJumper.LastName,
                Country = skiJumper.Country
            };
        }

        protected CreateSkiJumper CreateSkiJumperBase()
        {
            SkiJumper skiJumper = SkiJumperBase();
            return new CreateSkiJumper()
            {
                FirstName = skiJumper.FirstName,
                LastName = skiJumper.LastName,
                Country = skiJumper.Country
            };
        }

        protected UpdateSkiJumper UpdateSkiJumperBase()
        {
            SkiJumper skiJumper = SkiJumperBase();
            return new UpdateSkiJumper()
            {
                FirstName = skiJumper.FirstName,
                LastName = skiJumper.LastName,
                Country = skiJumper.Country
            };
        }
    }
}
