using HotelApi.Infrastructure;
using HotelDomain.Data;
using HotelDomain.Data.Seed;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<IDbAccessTokenProvider, DevAccessTokenProvider>();
}
else
{
    builder.Services.AddSingleton<IDbAccessTokenProvider, DbAccessTokenProvider>();
}

builder.Services.AddDbContext<HotelsDbContext>((sp, options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    options.AddInterceptors(new DbAccessTokenInterceptor(sp.GetRequiredService<IDbAccessTokenProvider>()));
});

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    try
//    {
//        var context = services.GetRequiredService<HotelsDbContext>();
//        HotelsDbContextDataSeed.Initialize(context);
//    }
//    catch (Exception ex)
//    {
//        var logger = services.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred creating the DB.");
//        throw;
//    }
//}


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
