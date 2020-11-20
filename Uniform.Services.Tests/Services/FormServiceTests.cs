using Moq;
using System.Collections.Generic;
using System.Linq;
using Uniform.Core.Dtos;
using Uniform.Core.Entities;
using Uniform.Core.Repositories;
using Xunit;

namespace Uniform.Services.Tests
{
    public class FormServiceTests
    {
        [Fact]
        public async void SearchFormAsync_ExistingData_ReturnsForm()
        {
            // Arrange
            var input = new SearchFormInput
            {
                Request = "John"
            };
            var forms = new List<Form>
            {
                new Form { Json = "\"name\":\"John\"" }
            };

            var repo = new Mock<IFormRepository>(MockBehavior.Strict);
            repo.Setup(s => s.FindAsync(It.Is<string>(s => s == input.Request)))
                .ReturnsAsync(forms);
            var uow = new Mock<IUnitOfWork>(MockBehavior.Strict);
            uow
                .Setup(s => s.Forms)
                .Returns(repo.Object);
            uow
                .Setup(s => s.Dispose());

            var service = new FormService(uow.Object);

            // Act
            var output = await service.SearchFormAsync(input);

            // Assert
            Assert.True(output.Result.Count == 1);
            Assert.Equal(forms.First().Json, output.Result.First());
        }
    }
}
