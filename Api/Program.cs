using Core.Data;
using Core.Services.Implementation;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Api.Dto;
using Core.Models;
using Api.Converter;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddAutoMapper(typeof(MapperProflies));
            builder.Services.AddDbContext<QuzzDbContext>(options =>
                options.UseMySql(connectionString, new MariaDbServerVersion(new Version(11, 0, 2))));

            builder.Services.AddScoped<IQuizBuilderService, QuizBuilderService>();
            builder.Services.AddControllers();

            var app = builder.Build();
            app.MapControllers();
            
            app.Run();
        }
    }
}