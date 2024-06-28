using FluentValidation;
using HR.API.Services;
using HR.API.Validators;
using HR.Application.Contracts;
using HR.Application.Services;
using HR.Infrastructure;
using HR.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace HR.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetSection("ConnectionString").Value;
            builder.Services.AddDbContext<HrDbContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("HR.API")));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddValidatorsFromAssemblyContaining<JobValidator>();
            builder.Services.AddScoped<IMessageProducer, MessageProducer>();

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
}
