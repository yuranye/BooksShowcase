using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BooksShowcase.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection serviceCollection) =>
        serviceCollection
            .AddMediatR(Assembly.GetExecutingAssembly());
}