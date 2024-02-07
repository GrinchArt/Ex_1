using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentApi.Data;
using StudentApi.Repository;
using System;
namespace StudentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<StudentsDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("StudentApiContext") ?? throw new ArgumentNullException("Connection string 'StudentApiContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IStudentsRepository,StudentsRepository>();
            builder.Services.AddScoped<IPicturesRepository,PicturesRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
