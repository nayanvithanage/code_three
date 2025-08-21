using code_three.Infrastructure.Data;
using code_three.Core.Interfaces;
using code_three.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//???
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IBookRepository, BookRepository>(); //?
builder.Services.AddScoped<BookService>();
builder.Services.AddControllers();

var app = builder.Build(); //?

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //?
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); //?
app.MapControllers(); //?

app.Run();


