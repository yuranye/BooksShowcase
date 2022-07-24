namespace BooksShowcase.Persistence.Cassandra.Options;

public class CassandraOptions
{
    public const string Name = nameof(CassandraOptions);
    
    public IEnumerable<string> Addresses { get; set; }
    public string Keyspace { get; set; }
    public string PageTokenEncryptionKey { get; set; }
}