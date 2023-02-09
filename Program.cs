using AsyncProductAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data Source=RequestDb.db"));

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
