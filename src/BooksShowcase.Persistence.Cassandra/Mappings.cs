using BooksShowcase.Core.Models.Entities;
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
                .PartitionKey(u => u.Uuid)
                .Column(u => u.EanUpc, cm => cm.WithName("ean_upc"))
                .Column(u => u.PublishDate, cm => cm.WithName("publish_date")));
    }

    public static void AddUdtMaps(ISession session)
    {
        session.UserDefinedTypes.Define(
            UdtMap.For<Author>()
                .Map(v => v.Name, "name")
                .Map(v => v.About, "about")
                .Map(v => v.Uuid, "uuid"),
            UdtMap.For<Publisher>()
                .Map(v => v.Name, "name")
                .Map(v => v.Email, "email")
                .Map(v => v.ContactNumber, "contact_number")
                .Map(v => v.Address, "address")
                .Map(v => v.Uuid, "uuid"));
    }
}