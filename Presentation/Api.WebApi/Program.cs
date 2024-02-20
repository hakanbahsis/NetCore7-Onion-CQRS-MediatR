using Api.Persistance;
using Api.Application;
using Api.Infrastructure;
using Api.Mapper;
using Api.Application.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Environment
var env = builder.Environment;
builder.Configuration.SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)//her halükarde okur
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

//Add PersistanceRegistraton
builder.Services.AddPersistance(builder.Configuration);

//Add ApplicationRegistration
builder.Services.AddApplication();

//Add CustomMapperRegistration
builder.Services.AddCustomMapper();

//Add InfrastructureRegistration
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Add ExceptionMiddleware
app.ConfigureExceptionHandlingMiddleware();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
