using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class ApplicationSettingsEndpoints
{
    public static void MapApplicationSettingsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/ApplicationSettings").WithTags(nameof(ApplicationSettings));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.ApplicationSettings.ToListAsync();
        })
        .WithName("GetAllApplicationSettings")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<ApplicationSettings>, NotFound>> (int id, EduOne_FrContext db) =>
        {
            return await db.ApplicationSettings.AsNoTracking()
                .FirstOrDefaultAsync(model => model.ID == id)
                is ApplicationSettings model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetApplicationSettingsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, ApplicationSettings applicationSettings, EduOne_FrContext db) =>
        {
            var affected = await db.ApplicationSettings
                .Where(model => model.ID == id)
                .ExecuteUpdateAsync(setters => setters
                    //.SetProperty(m => m.ID, applicationSettings.ID)
                    .SetProperty(m => m.AppKey, applicationSettings.AppKey)
                    .SetProperty(m => m.AppValue, applicationSettings.AppValue)
                    .SetProperty(m => m.CanBeAltered, applicationSettings.CanBeAltered)
                    .SetProperty(m => m.Notes, applicationSettings.Notes)
                    .SetProperty(m => m.Statut, applicationSettings.Statut)
                    .SetProperty(m => m.AjouterAu, applicationSettings.AjouterAu)
                    .SetProperty(m => m.AjouterPar, applicationSettings.AjouterPar)
                    .SetProperty(m => m.ModifierAu, applicationSettings.ModifierAu)
                    .SetProperty(m => m.ModifierPar, applicationSettings.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateApplicationSettings")
        .WithOpenApi();

        group.MapPost("/", async (ApplicationSettings applicationSettings, EduOne_FrContext db) =>
        {
            db.ApplicationSettings.Add(applicationSettings);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/ApplicationSettings/{applicationSettings.ID}",applicationSettings);
        })
        .WithName("CreateApplicationSettings")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EduOne_FrContext db) =>
        {
            var affected = await db.ApplicationSettings
                .Where(model => model.ID == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteApplicationSettings")
        .WithOpenApi();
    }
}
