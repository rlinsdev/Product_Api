using AsyncProductAPI.Data;
using AsyncProductAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data Source=RequestDb.db"));

var app = builder.Build();

app.UseHttpsRedirection();

// Start endpoints
app.MapPost("api/v1/products", async (AppDbContext context, ListingRequest listingRequest) => {
    if (listingRequest == null)
        return Results.BadRequest();

    listingRequest.RequestStatus = "ACCEPT";
    listingRequest.EstimatedCompetitionTime = "2023-02-06:14:00:00";

    await context.ListingRequests.AddAsync(listingRequest);
    await context.SaveChangesAsync();
    
    return Results.Accepted($"api/v1/productstatus/{listingRequest.RequestId}", listingRequest);
});

app.Run();
