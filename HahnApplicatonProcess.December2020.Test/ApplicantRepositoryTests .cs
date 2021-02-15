using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Data.Repository.ApplicantRepo;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HahnApplicatonProcess.December2020.Test
{
    public class ApplicantRepositoryTests
    {
        private readonly Mock<ApplicantRepository> _appRepo;
        private readonly Mock<DataContext> _appRepoMock;
        private readonly DbContextOptions<DataContext> _dbContextOptions = new DbContextOptions<DataContext>();

        // private readonly DbContextOptions<DataContext> options;
        //= new DbContextOptions<DataContext>();

        public ApplicantRepositoryTests()
        {
            _appRepoMock = new Mock<DataContext>(_dbContextOptions);

            _appRepo = new Mock<ApplicantRepository>(_appRepoMock.Object);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetById_ShouldReturnApplicant_WhenApplicantExist()
        {
            // Arrange
            int id = new Random().Next();
            string familyName = "Layed";

            var applicant = new Applicant()
            {
                ID = id,
                Address = "jame col, avenue UK London",
                Age = 45,
                EmailAddress = "james@gmail.ccom",
                CountryOfOrigin = "EU",
                FamilyName = familyName,
                Hired = false,
                Name = "Terry"
            };

            _appRepo.Setup(c =>  c.Get(applicant.ID)).ReturnsAsync(applicant);

            // Act 
            var application = await  _appRepo.Object.Get(id);

            //Assert
            Assert.Equal(id, application.ID);
            Assert.Equal(familyName, application.FamilyName);

        }

        [Fact]
        public async Task GetById_ShouldReturnNothing_WhenApplicantDoesNotExist()
        {
            // Arrange

            _appRepoMock.Setup(c => c.Applicants.FirstOrDefault(c => c.ID == It.IsAny<int>())).Returns(() => null);

            // Act 
            var applicant = await _appRepo.Object.Get(new Random().Next());

            //Assert
            Assert.Null(applicant);

        }
    }
}
