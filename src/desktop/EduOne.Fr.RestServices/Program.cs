using EduOne.Fr.RestServices;

namespace EduOne.Fr.RestServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EduOne_FrContext>(option =>
            {
                option.UseSqlServer(DbHelpers.CS);
                option.EnableDetailedErrors();

            });

            // Add CORS services
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });

                options.AddPolicy("ApplicationPolicy", builder =>
                {
                    builder.WithOrigins("https://localhost:7027","http://localhost:5111")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

                        builder.Services.AddEndpointsApiExplorer();

                        builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            };

            // Global CORS Policy
            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

                        app.MapApplicationUsersEndpoints();

            app.Run();
        }
    }
}
