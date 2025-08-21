using code_three.Infrastructure.Data;
using code_three.Core.Interfaces;
using code_three.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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
    app.MapOpenApi();
}

app.UseHttpsRedirection(); //?
app.MapControllers(); //?

app.Run();


