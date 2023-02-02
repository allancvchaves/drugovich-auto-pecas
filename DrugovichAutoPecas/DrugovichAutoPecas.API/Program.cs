using AutoMapper;
using DrugovichAutoPecas.API.Context;
using DrugovichAutoPecas.API.Contracts;
using DrugovichAutoPecas.API.Mapper;
using DrugovichAutoPecas.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AutoPecasContext>(opt => opt.UseInMemoryDatabase("DrugovichTestDb"));
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(x =>
{
    x.AddProfile(new AutoPecasMapping());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AutoPecasContext>();
    dbContext.Gerentes.AddRange(
        new DrugovichAutoPecas.API.Entities.Gerente()
        {
            Id = 1,
            Nome = "Gerente Junior",
            Email = "junior@drugovich.com.br",
            Nivel = 1
        },
        new DrugovichAutoPecas.API.Entities.Gerente()
        {
            Id = 2,
            Nome = "Gerente Senior",
            Email = "senior@drugovich.com.br",
            Nivel = 2
        });
    dbContext.Clientes.Add(
        new DrugovichAutoPecas.API.Entities.Cliente()
        {
            Id = 1,
            Nome = "Cliente um",
            Cnpj = "82086610000114",
            DataFundacao = DateTime.Now
        });

    dbContext.SaveChanges();
}


app.Run();
