using IbanValidator.Interfaces;
using IbanValidator.Services;

namespace IbanValidator
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
            builder.Services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo());
                var filePath = Path.Combine(AppContext.BaseDirectory, "ApiDoc.xml");
                c.IncludeXmlComments(filePath);
            });
            builder.Services.AddTransient<IIbanValidator, Services.IbanValidator>();

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