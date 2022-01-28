using Xunit;
using FluentValidation.Results;
using DDD.Core.NET5.Common.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Core.NET5.Common.Tests.Configuration
{
    public class FluentValidationConfigTests
    {
        [Fact(DisplayName = "Adding ValidationResult to ServiceCollection")]
        [Trait("FluentValidation", "Configuration Tests")]
        public void Adding_ValidationResult_To_ServiceCollection()
        {
            //Arrange
            IServiceCollection services = new ServiceCollection();

            //Act
            services.AddFluentValidation();

            //Assert
            Assert.Contains(services, x => x.ServiceType == typeof(ValidationResult));
        }
    }
}