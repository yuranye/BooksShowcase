using BooksShowcase.Core;
using BooksShowcase.Persistence.Cassandra;
using BooksShowcase.Persistence.Cassandra.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCore();

//cassandra
builder.Services.Configure<CassandraOptions>(builder.Configuration.GetSection(CassandraOptions.Name));
builder.Services.AddCassandraPersistence();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();