using Xunit;
using MediatR;
using DDD.Core.NET5.Common.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Core.NET5.Common.Tests.Configuration
{
    public class MediatorConfigTests
    {
        [Fact(DisplayName = "Adding MediatR to ServiceCollection")]
        [Trait("Mediator", "Configuration Tests")]
        public void Adding_MediatR_To_ServiceCollection()
        {
            //Arrange
            IServiceCollection services = new ServiceCollection();

            //Act
            services.AddMediator<Startup>();

            //Assert
            Assert.Contains(services, x => x.ServiceType == typeof(IMediator));
        }
    }

    public class Startup { }
}