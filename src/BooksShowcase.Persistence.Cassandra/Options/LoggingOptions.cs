namespace BooksShowcase.Persistence.Cassandra.Options;

public class LoggingOptions
{
    public const string SectionName = nameof(LoggingOptions);

    public string LogstashAddress { get; set; }
    public long? LogstashQueueLimitBytes { get; set; }
}
