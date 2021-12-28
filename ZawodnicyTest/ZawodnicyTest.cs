using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Infrastructure;
using Zawodnicy.Infrastructure.Commands;

namespace ZawodnicyTest
{
    [TestClass]
    public class ZawodnicyTest : TestBase
    {
        [TestMethod]
        public async Task addSkiJumper_should_throw_NullReferenceException_when_addedSkiJumperIsNull()
        {
            CreateSkiJumper skiJumper = null;

            Func<Task> addNullSkiJumperAction = () => _skiJumpersService.AddSkiJumper(skiJumper);

            await Assert.ThrowsExceptionAsync<NullReferenceException>(addNullSkiJumperAction);
        }

        [TestMethod]
        public async Task addSkiJumper_should_addSkiJumperToRepository_when_givenCorrectData()
        {
            SkiJumper element = SkiJumperBase();
            CreateSkiJumper skiJumper = CreateSkiJumperBase();
            SkiJumper createdSkiJumper = new SkiJumper()
            {
                FirstName = skiJumper.FirstName,
                LastName = skiJumper.LastName,
                Country = skiJumper.Country
            };
            _mockedSkiJumpersRepository.Setup(skiJumpers => skiJumpers.AddAsync(createdSkiJumper));

            await _skiJumpersService.AddSkiJumper(skiJumper);

            SkiJumperDTO expectedSkiJumper = SkiJumperDtoBase();
            //Assert.AreEqual(expectedSkiJumper, addedSkiJumper);
        }

        [TestMethod]
        public async Task browseAll_should_returnEmptyList_when_repositoryIsEmpty()
        {
            var emptyRepository = new List<SkiJumper>();
            _mockedSkiJumpersRepository.Setup(skiJumpers => skiJumpers.BrowseAllAsync()).ReturnsAsync(emptyRepository);

            var browsed = await _skiJumpersService.BrowseAll();
            var browsedList = browsed.ToList();

            var expectedBrowsedList = new List<SkiJumperDTO>();
            Assert.IsTrue(expectedBrowsedList.SequenceEqual(browsedList));
        }

        [TestMethod]
        public async Task browseAll_should_returnList_when_repositoryIsNotEmpty()
        {
            var repository = new List<SkiJumper>();
            repository.Add(SkiJumperBase());
            _mockedSkiJumpersRepository.Setup(skiJumpers => skiJumpers.BrowseAllAsync()).ReturnsAsync(repository);

            var browsed = await _skiJumpersService.BrowseAll();
            var browsedList = browsed.ToList();

            var expectedBrowsedList = new List<SkiJumperDTO>();
            expectedBrowsedList.Add(SkiJumperDtoBase());
            Assert.IsTrue(expectedBrowsedList.SequenceEqual(browsedList));
        }

        [TestMethod]
        public async Task browseAllAndFilter_should_returnEmptyList_when_repositoryIsEmpty()
        {
            var repository = new List<SkiJumper>();
            string country = "Zasiedmiogórogród";
            string lastName = "Makota";
            _mockedSkiJumpersRepository.Setup(skiJumpers => skiJumpers.BrowseAllAndFilter(country, lastName)).ReturnsAsync(repository);

            var browsed = await _skiJumpersService.BrowseAllAndFilter(country, lastName);
            var browsedList = browsed.ToList();

            var expectedBrowsedList = new List<SkiJumperDTO>();
            Assert.IsTrue(expectedBrowsedList.SequenceEqual(browsedList));
        }

        [TestMethod]
        public async Task browseAllAndFilter_should_returnList_when_repositoryIsNotEmpty()
        {
            var repository = new List<SkiJumper>();
            repository.Add(SkiJumperBase());
            string country = "Zasiedmiogórogród";
            string lastName = "Makota";
            _mockedSkiJumpersRepository.Setup(skiJumpers => skiJumpers.BrowseAllAndFilter(country, lastName)).ReturnsAsync(repository);

            var browsed = await _skiJumpersService.BrowseAllAndFilter(country, lastName);
            var browsedList = browsed.ToList();

            var expectedBrowsedList = new List<SkiJumperDTO>();
            expectedBrowsedList.Add(SkiJumperDtoBase());
            Assert.IsTrue(expectedBrowsedList.SequenceEqual(browsedList));
        }

        [TestMethod]
        public async Task deleteSkiJumper_should_throwInvalidOperationException_when_givenIdIsNotInRepository()
        {
            int id = 5;
            _mockedSkiJumpersRepository.Setup(skiJumpers => skiJumpers.DeleteAsync(id)).ThrowsAsync(new InvalidOperationException());

            Func<Task> deleteSkiJumperAction = () => _skiJumpersService.DeleteSkiJumper(id);

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(deleteSkiJumperAction);
        }

        [TestMethod]
        public async Task deleteSkiJumper_should_deleteSkiJumperFromRepository_when_givenCorrectData()
        {
            int id = 1;
            _mockedSkiJumpersRepository.Setup(skiJumpers => skiJumpers.DeleteAsync(id));

            await _skiJumpersService.DeleteSkiJumper(id);

            _mockedSkiJumpersRepository.Verify(skiJumpers => skiJumpers.DeleteAsync(id), Times.Once);
        }

        [TestMethod]
        public async Task editSkiJumper_should_throw_NullReferenceException_when_updatedSkiJumperIsNull()
        {
            UpdateSkiJumper skiJumper = null;
            int id = 1;

            Func<Task> updateNullSkiJumperAction = () => _skiJumpersService.EditSkiJumper(skiJumper, id);

            await Assert.ThrowsExceptionAsync<NullReferenceException>(updateNullSkiJumperAction);
        }

        [TestMethod]
        public async Task editSkiJumper_should_throwInvalidOperationException_when_givenIdIsNotInRepository()
        {
            int id = 1;
            UpdateSkiJumper editedSkiJumper = UpdateSkiJumperBase();
            editedSkiJumper.Country = "xxx";
            SkiJumper originalSkiJumper = new SkiJumper()
            {
                Id = id,
                FirstName = editedSkiJumper.FirstName,
                LastName = editedSkiJumper.LastName,
                Country = editedSkiJumper.Country
            };
            _mockedSkiJumpersRepository.Setup(skiJumpers => skiJumpers.UpdateAsync(originalSkiJumper)).ThrowsAsync(new InvalidOperationException());

            Func<Task> editAction = () => _skiJumpersService.EditSkiJumper(editedSkiJumper, id);

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(editAction);
        }

        [TestMethod]
        public async Task editSkiJumper_should_editSkiJumperInRepository_when_givenCorrectData()
        {
            int id = 1;
            UpdateSkiJumper editedSkiJumper = UpdateSkiJumperBase();
            editedSkiJumper.Country = "xxx";
            SkiJumper originalSkiJumper = new SkiJumper()
            {
                Id = id,
                FirstName = editedSkiJumper.FirstName,
                LastName = editedSkiJumper.LastName,
                Country = editedSkiJumper.Country
            };
            _mockedSkiJumpersRepository.Setup(skiJumpers => skiJumpers.UpdateAsync(originalSkiJumper));

            await _skiJumpersService.EditSkiJumper(editedSkiJumper, id);

            _mockedSkiJumpersRepository.Verify(skiJumpers => skiJumpers.UpdateAsync(originalSkiJumper), Times.Once);
        }

        [TestMethod]
        public async Task getById_should_throwInvalidOperationException_when_givenIdIsNotInRepository()
        {
            int id = 5;
            _mockedSkiJumpersRepository.Setup(skiJumpers => skiJumpers.GetAsync(id)).ThrowsAsync(new InvalidOperationException());

            Func<Task> getByIdAction = () => _skiJumpersService.GetById(id);

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(getByIdAction);
        }

        [TestMethod]
        public void getById_should_returnSkiJumperWithGivenId_when_givenIdIsInRepository()
        {
            SkiJumper addedSkiJumper = SkiJumperBase();
            int id = addedSkiJumper.Id;
            _mockedSkiJumpersRepository.Setup(skiJumpers => skiJumpers.GetAsync(id)).ReturnsAsync(addedSkiJumper);

            var returnedSkiJumper = _skiJumpersService.GetById(id);

            SkiJumperDTO expectedSkiJumper = SkiJumperDtoBase();
            _mockedSkiJumpersRepository.Verify(skiJumper => skiJumper.GetAsync(id), Times.Once());
        }
    }
}