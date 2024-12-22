using DAL.Context;
using DAL.Repositories.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Service;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Services; // IPortfolioService için gerekli
using Service; // PortfolioService için gerekli


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddHttpClient<IStockService, StockService>(client =>
{
    client.BaseAddress = new Uri("http://api.marketstack.com/v1");
});

//builder.Services.AddHttpClient<ICryptoService, CryptoService>(client =>
//{
//    client.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
//});

builder.Services.AddHttpClient<ICryptoService, CryptoService>(client =>
{
    client.BaseAddress = new Uri("https://rest.coinapi.io/"); // CoinAPI’nin temel URL’si
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext ayarlarý
builder.Services.AddDbContext<CryptoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));


// Dependency Injection
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();


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

app.Run();
