using Farmacia.Data;
using Farmacia.Domains.Repositories;
using Farmacia.Domains.Repositories.IRepositories;
using Farmacia.Domains.Service;
using Farmacia.Domains.Service.IService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProdutoRepositories,ProdutoRepositories>();
builder.Services.AddScoped<IProdutoService,ProdutoService>();
builder.Services.AddScoped<IVendaRepositories, VendaRepositories>();
builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite("Data Source=Farmacia.db"));
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