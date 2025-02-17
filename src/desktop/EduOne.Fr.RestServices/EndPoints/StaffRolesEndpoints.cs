using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class StaffRolesEndpoints
{
    public static void MapStaffRolesEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/StaffRoles").WithTags(nameof(StaffRoles));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.StaffRoles.ToListAsync();
        })
        .WithName("GetAllStaffRoles")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<StaffRoles>, NotFound>> (int id, EduOne_FrContext db) =>
        {
            return await db.StaffRoles.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is StaffRoles model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetStaffRolesById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, StaffRoles staffRoles, EduOne_FrContext db) =>
        {
            var affected = await db.StaffRoles
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, staffRoles.Id)
                    .SetProperty(m => m.Role, staffRoles.Role)
                    .SetProperty(m => m.AjouterAu, staffRoles.AjouterAu)
                    .SetProperty(m => m.AjouterPar, staffRoles.AjouterPar)
                    .SetProperty(m => m.ModifierAu, staffRoles.ModifierAu)
                    .SetProperty(m => m.ModifierPar, staffRoles.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateStaffRoles")
        .WithOpenApi();

        group.MapPost("/", async (StaffRoles staffRoles, EduOne_FrContext db) =>
        {
            db.StaffRoles.Add(staffRoles);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/StaffRoles/{staffRoles.Id}",staffRoles);
        })
        .WithName("CreateStaffRoles")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EduOne_FrContext db) =>
        {
            var affected = await db.StaffRoles
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteStaffRoles")
        .WithOpenApi();
    }
}
