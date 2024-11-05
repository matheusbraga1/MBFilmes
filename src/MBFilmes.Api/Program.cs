using MBFilmes.Api.Data;
using MBFilmes.Api.Endpoints;
using MBFilmes.Api.Handlers;
using MBFilmes.Core.Handlers;
using MBFilmes.Core.Models;
using MBFilmes.Core.Requests.Profiles;
using MBFilmes.Core.Responses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(x => { x.UseSqlServer(connectionString); });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });
builder.Services.AddTransient<IProfileHandler, ProfileHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => new { message = "OK" });
app.MapEndpoints();

app.Run();
