using System.Text.Json.Serialization;
using System.Text.Json;
using EduOne.Fr.RestServices.EndPoints;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace EduOne.Fr.RestServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddServiceDefaults();

            builder.Services.AddDbContext<EduOne_FrContext>(option =>
            {
                option.UseSqlServer(DbHelpers.CS);
                option.EnableDetailedErrors();

            });

            // Authentication
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<EduOne_FrContext>()
            .AddDefaultTokenProviders();

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
            /*
            builder.Services.AddControllers(options =>
            {
                options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
                options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                }));
            });
            */

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

                        builder.Services.AddEndpointsApiExplorer();

                        builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.MapDefaultEndpoints();

            //
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                 InitializeRoles(services);
            }

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
            app.MapApplicationRolesEndpoints();
            app.MapCommonEndpoints();
            app.MapCoursesEndpoints();
            app.MapDepartmentsEndpoints();

                        app.MapDepartmentHeadsEndpoints();

                        //app.MapDepartmentHeadsEndpoints();




            app.Run();
        }

        #region Helpers
        public static async Task InitializeRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "User","Guess","Super" };

            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public static async Task AssignUserRole(IServiceProvider serviceProvider, string email, string role)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var user = await userManager.FindByEmailAsync(email);

            if (user != null && !await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }

        #endregion
    }
}
