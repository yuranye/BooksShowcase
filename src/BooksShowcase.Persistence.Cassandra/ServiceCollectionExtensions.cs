using BooksShowcase.Core;
using BooksShowcase.Persistence.Cassandra.Options;
using Cassandra;
using Cassandra.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BooksShowcase.Persistence.Cassandra;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCassandraPersistence(this IServiceCollection serviceCollection) =>
        serviceCollection
            .AddScoped<IBooksReader, BooksReader>()
            .AddSingleton(p => Cluster.Builder()
                .AddContactPoints(p.GetRequiredService<IOptions<CassandraOptions>>().Value.Addresses)
                .Build())
            .AddScoped<ISession>(p =>
            {
                var session = p.GetRequiredService<Cluster>()
                    .Connect(p.GetRequiredService<IOptions<CassandraOptions>>().Value.Keyspace);

                Mappings.AddUdtMaps(session);

                return session;
            })
            .AddScoped(p => new Mapper(p.GetRequiredService<ISession>()));
}