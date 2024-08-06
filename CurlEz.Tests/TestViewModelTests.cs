using CurlEz.Data.Interfaces;
using CurlEz.Infrastructure;
using CurlEz.Models;
using CurlEz.ViewModels;
using FluentAssertions;
using Moq;
using System.Collections.ObjectModel;

namespace CurlEz.Tests
{
    public class TestViewModelTests
    {
        [Fact]
        public async Task LoadTestsAsync_WhenDatabaseHasFiveItems_ShouldLoadFiveItemsToList()
        {
            // Arrange
            var mockTestService = new Mock<ITestService>();
            var mockNavigationService = new Mock<INavigationService>();

            var testList = new List<Test>
            {
                new() { ID = 1, Name = "Test 1" },
                new() { ID = 2, Name = "Test 2" },
                new() { ID = 3, Name = "Test 3" },
                new() { ID = 4, Name = "Test 4" },
                new() { ID = 5, Name = "Test 5" }
            };

            mockTestService.Setup(service => service.GetTestsAsync())
                .ReturnsAsync(testList);

            var viewModel = new TestViewModel(mockTestService.Object, mockNavigationService.Object);

            // Act
            await viewModel.LoadTestsCommand.ExecuteAsync(null);

            // Assert
            viewModel.Tests.Should().NotBeNull();
            viewModel.Tests.Should().BeOfType<ObservableCollection<Test>>();
            viewModel.Tests.Should().HaveCount(5);
            viewModel.Tests?.Select(t => t.Name).Should().BeEquivalentTo("Test 1", "Test 2", "Test 3", "Test 4", "Test 5");

            mockTestService.Verify(service => service.GetTestsAsync(), Times.Once);
        }
    }
}