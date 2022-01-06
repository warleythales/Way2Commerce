using Microsoft.EntityFrameworkCore;
using Way2Commerce.Data;
using Way2Commerce.Data.Repositorios;
using Way2Commerce.Domain.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Way2CommerceContexto>(options => options
    .UseSqlServer(@"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=DESKTOP-CPEVJU9\wtsl_;Initial Catalog=testeone;Data Source=DESKTOP-CPEVJU9"));

builder.Services.AddScoped<Way2CommerceContexto, Way2CommerceContexto>();
builder.Services.AddTransient<IProdutoRepositorio, ProdutoRepositorio>();

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
