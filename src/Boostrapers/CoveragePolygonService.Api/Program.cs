using CoveragePolygonService.Core;
using CoveragePolygonService.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Extensiones - Injection Dependencies.
builder.Services.AddCoreServices();
builder.Services.AddInfraestructureServices();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
