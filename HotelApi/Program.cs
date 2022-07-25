using FluentValidation;
using HotelApi.Infrastructure;
using HotelDomain.Data;
using HotelDomain.Queries.FindHotel;
using MediatR;
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

builder.Services.AddMediatR(typeof(FindHotelQueryHandler).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<FindHotelRequestValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
