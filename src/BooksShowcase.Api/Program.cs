using BooksShowcase.Api;
using BooksShowcase.Core;
using BooksShowcase.Persistence.Cassandra;
using BooksShowcase.Persistence.Cassandra.Options;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Http.BatchFormatters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCore();

//logs
builder.Services.Configure<LoggingOptions>(builder.Configuration.GetSection(LoggingOptions.SectionName));
builder.Host.UseSerilog((_, serviceProvider, configuration) =>
{
    var loggingOptions = serviceProvider.GetRequiredService<IOptions<LoggingOptions>>().Value;

    configuration
        .Enrich.FromLogContext()
        .Enrich.WithProperty("ServiceName", Constants.ServiceName)
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .WriteTo.Http(loggingOptions.LogstashAddress, loggingOptions.LogstashQueueLimitBytes,
            batchFormatter: new ArrayBatchFormatter())
        .WriteTo.Console();
});

//cassandra
builder.Services.Configure<CassandraOptions>(builder.Configuration.GetSection(CassandraOptions.SectionName));
builder.Services.AddCassandraPersistence();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();