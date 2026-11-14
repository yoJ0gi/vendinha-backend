using Microsoft.EntityFrameworkCore;
using Vendinha.Api.Data;
using Vendinha.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VendinhaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Vendinha")));

// Services da camada de negócio, entregues aos controllers pelo construtor
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<DividaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<VendinhaContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
