using BackEnd.DataService.DataContext;
using BackEnd.DataService.Services;
using Backend_Challenge.WebAPI.Clients;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<ClienteValidator>();

builder.Services.AddSingleton<IDbContextFactory, DbContextFactory>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
