using Microsoft.EntityFrameworkCore;
using ProvaTp3Teste.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AgendamentoDbContext>(opt =>
    opt.UseSqlServer("Data Source=DESKTOP-0PVID37\\SQLEXPRESS;Initial Catalog=nfl;Integrated Security=True;Encrypt=False"));
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AgendamentoDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        // Log de erro ou tratamento apropriado
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao aplicar as migrations ao banco de dados.");
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
