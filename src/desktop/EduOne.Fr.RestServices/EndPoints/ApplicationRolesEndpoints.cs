using Microsoft.EntityFrameworkCore;
using EduOne.Fr.RestServices.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class ApplicationRolesEndpoints
{
    public static void MapApplicationRolesEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/ApplicationRoles").WithTags(nameof(ApplicationRoles));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.ApplicationRoles.ToListAsync();
        })
        .WithName("GetAllApplicationRoles")
        .WithOpenApi()
        .RequireCors("ApplicationPolicy");

        group.MapGet("/{id}", async Task<Results<Ok<ApplicationRoles>, NotFound>> (Guid id, EduOne_FrContext db) =>
        {
            return await db.ApplicationRoles.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is ApplicationRoles model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetApplicationRolesById")
        .WithOpenApi()
        .RequireCors("ApplicationPolicy");

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid id, ApplicationRoles applicationRoles, EduOne_FrContext db) =>
        {
            var affected = await db.ApplicationRoles
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, applicationRoles.Id)
                    .SetProperty(m => m.NomRole, applicationRoles.NomRole)
                    .SetProperty(m => m.Description, applicationRoles.Description)
                    .SetProperty(m => m.AjouterAu, applicationRoles.AjouterAu)
                    .SetProperty(m => m.AjouterPar, applicationRoles.AjouterPar)
                    .SetProperty(m => m.ModifierAu, applicationRoles.ModifierAu)
                    .SetProperty(m => m.ModifierPar, applicationRoles.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateApplicationRoles")
        .WithOpenApi()
        .RequireCors("ApplicationPolicy");

        group.MapPost("/", async (ApplicationRoles applicationRoles, EduOne_FrContext db) =>
        {
            db.ApplicationRoles.Add(applicationRoles);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/ApplicationRoles/{applicationRoles.Id}",applicationRoles);
        })
        .WithName("CreateApplicationRoles")
        .WithOpenApi()
        .RequireCors("ApplicationPolicy");

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid id, EduOne_FrContext db) =>
        {
            var affected = await db.ApplicationRoles
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteApplicationRoles")
        .WithOpenApi()
            .RequireCors("ApplicationPolicy");
    }
}
