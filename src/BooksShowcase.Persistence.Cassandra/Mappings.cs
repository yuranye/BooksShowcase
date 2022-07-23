using BooksShowcase.Core.Models;
using Cassandra;
using Cassandra.Mapping;

namespace BooksShowcase.Persistence.Cassandra;

public class Mappings
{
    public static void SetGlobalMappings()
    {
        MappingConfiguration.Global.Define(
            new Map<Book>()
                .TableName("books")
                .PartitionKey(u => u.Uuid));
    }

    public static void AddUdtMaps(ISession session)
    {
        //nested type mappings
    }
}