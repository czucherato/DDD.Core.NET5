using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Core.NET5.Common.Configuration
{
    public static class MediatorConfig
    {
        public static void AddMediator<T>(this IServiceCollection services)
        {
            services.AddMediatR(typeof(T));
        }
    }
}