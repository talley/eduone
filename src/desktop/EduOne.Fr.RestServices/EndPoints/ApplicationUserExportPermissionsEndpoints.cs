using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class ApplicationUserExportPermissionsEndpoints
{
    public static void MapApplicationUserExportPermissionsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/ApplicationUserExportPermissions").WithTags(nameof(ApplicationUserExportPermissions));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.ApplicationUserExportPermissions.ToListAsync();
        })
        .WithName("GetAllApplicationUserExportPermissions")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<ApplicationUserExportPermissions>, NotFound>> (int id, EduOne_FrContext db) =>
        {
            return await db.ApplicationUserExportPermissions.AsNoTracking()
                .FirstOrDefaultAsync(model => model.ID == id)
                is ApplicationUserExportPermissions model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetApplicationUserExportPermissionsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, ApplicationUserExportPermissions applicationUserExportPermissions, EduOne_FrContext db) =>
        {
            var affected = await db.ApplicationUserExportPermissions
                .Where(model => model.ID == id)
                .ExecuteUpdateAsync(setters => setters
                    //.SetProperty(m => m.ID, applicationUserExportPermissions.ID)
                    .SetProperty(m => m.Email, applicationUserExportPermissions.Email)
                    .SetProperty(m => m.CanExportToExcel, applicationUserExportPermissions.CanExportToExcel)
                    .SetProperty(m => m.CanExportToPDF, applicationUserExportPermissions.CanExportToPDF)
                    .SetProperty(m => m.CanExportToHTML, applicationUserExportPermissions.CanExportToHTML)
                    .SetProperty(m => m.AjouterAu, applicationUserExportPermissions.AjouterAu)
                    .SetProperty(m => m.AjouterPar, applicationUserExportPermissions.AjouterPar)
                    .SetProperty(m => m.ModifierAu, applicationUserExportPermissions.ModifierAu)
                    .SetProperty(m => m.ModifierPar, applicationUserExportPermissions.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateApplicationUserExportPermissions")
        .WithOpenApi();

        group.MapPost("/", async (ApplicationUserExportPermissions applicationUserExportPermissions, EduOne_FrContext db) =>
        {
            db.ApplicationUserExportPermissions.Add(applicationUserExportPermissions);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/ApplicationUserExportPermissions/{applicationUserExportPermissions.ID}",applicationUserExportPermissions);
        })
        .WithName("CreateApplicationUserExportPermissions")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EduOne_FrContext db) =>
        {
            var affected = await db.ApplicationUserExportPermissions
                .Where(model => model.ID == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteApplicationUserExportPermissions")
        .WithOpenApi();
    }
}
