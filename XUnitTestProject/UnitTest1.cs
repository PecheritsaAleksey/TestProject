using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using QuotationManager.Controllers;
using QuotationManager.Models;
using QuotationManager.Repository;

namespace XUnitTestProject
{
    public class QuotaControllerTests
    {
        [Fact]
        public void GetByIdTest()
        {
            // Arrange
            var mockQuotaRepo = new Mock<IQuotasRepository>();
            var mockCityRepo = new Mock<ICityRepository>();
            var mockContributionRepo = new Mock<IContributionReposirory>();

            var quota = new Quota{Id = 1,CityId = 1, PurposeId = 1, RefinancingAmount = 100000};

            mockQuotaRepo.Setup(x => x.GetQuotaById(1)).Returns(quota);

            var controller = new QuotasController(mockQuotaRepo.Object, mockCityRepo.Object, mockContributionRepo.Object);

            // Act
            var result = controller.Get(1);

            // Assert
            Assert.Equal(100000, result.RefinancingAmount);
        }

        [Fact]
        public void PostTest()
        {
            // Arrange
            var mockQuotaRepo = new Mock<IQuotasRepository>();
            var mockCityRepo = new Mock<ICityRepository>();
            var mockContributionRepo = new Mock<IContributionReposirory>();

            var quota = new Quota { Id = 1, CityId = 1, PurposeId = 1, RefinancingAmount = 100000 };
            var controller = new QuotasController(mockQuotaRepo.Object, mockCityRepo.Object, mockContributionRepo.Object);

            mockCityRepo.Setup(x => x.GetCityById(1)).Returns(new City{Name = "ÃÎÐÎÄ", SignificanceLevel = 10});

            // Act
            var result = controller.Post(quota);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void PutTest()
        {
            // Arrange
            var mockQuotaRepo = new Mock<IQuotasRepository>();
            var mockCityRepo = new Mock<ICityRepository>();
            var mockContributionRepo = new Mock<IContributionReposirory>();

            var quota = new Quota { Id = 1, CityId = 1, PurposeId = 1, RefinancingAmount = 100000 };
            var controller = new QuotasController(mockQuotaRepo.Object, mockCityRepo.Object, mockContributionRepo.Object);

            mockCityRepo.Setup(x => x.GetCityById(1)).Returns(new City { Name = "ÃÎÐÎÄ", SignificanceLevel = 10 });

            // Act
            var result = controller.Put(quota.Id, quota);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void DeleteTest()
        {
            // Arrange
            var mockQuotaRepo = new Mock<IQuotasRepository>();
            var mockCityRepo = new Mock<ICityRepository>();
            var mockContributionRepo = new Mock<IContributionReposirory>();

            var quota = new Quota { Id = 1, CityId = 1, PurposeId = 1, RefinancingAmount = 100000 };
            var controller = new QuotasController(mockQuotaRepo.Object, mockCityRepo.Object, mockContributionRepo.Object);

            mockCityRepo.Setup(x => x.GetCityById(1)).Returns(new City { Name = "ÃÎÐÎÄ", SignificanceLevel = 10 });
            mockQuotaRepo.Setup(x => x.GetQuotaById(1)).Returns(quota);

            // Act
            var result = controller.Delete(quota.Id);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
