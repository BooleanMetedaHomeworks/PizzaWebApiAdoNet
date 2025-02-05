
using PizzaWebApi.Loggers;
using PizzaWebApi.Repositories;

namespace PizzaWebApi
{
    // Houston we have bugs!
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            // CONSEGNA 05/02/2025: 
            // Ora abbiamo una nuova dependency da gestire!

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            builder.Services.AddScoped<CategoryRepository>();

            app.MapControllers();

            app.Run();
        }
    }
}
