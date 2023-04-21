using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using vosplzen.sem2h1.Data;
using vosplzen.sem2h1.Filters;
using vosplzen.sem2h1.Migrations;
using vosplzen.sem2h1.Services;
using vosplzen.sem2h1.Services.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(
                  builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IIdentityService, IdentityService>();
        builder.Services.AddScoped<IStudentService, StudentService>();
        builder.Services.AddScoped<IMasterSeedService, MasterSeedService>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }



}