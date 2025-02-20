using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class StaffNotesEndpoints
{
    public static void MapStaffNotesEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/StaffNotes").WithTags(nameof(StaffNotes));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.StaffNotes.ToListAsync();
        })
        .WithName("GetAllStaffNotes")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<StaffNotes>, NotFound>> (int id, EduOne_FrContext db) =>
        {
            return await db.StaffNotes.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is StaffNotes model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetStaffNotesById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, StaffNotes staffNotes, EduOne_FrContext db) =>
        {
            var affected = await db.StaffNotes
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, staffNotes.Id)
                    .SetProperty(m => m.EId, staffNotes.EId)
                    .SetProperty(m => m.Notes, staffNotes.Notes)
                    .SetProperty(m => m.AjouterAu, staffNotes.AjouterAu)
                    .SetProperty(m => m.AjouterPar, staffNotes.AjouterPar)
                    .SetProperty(m => m.ModifierAu, staffNotes.ModifierAu)
                    .SetProperty(m => m.ModifierPar, staffNotes.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateStaffNotes")
        .WithOpenApi();

        group.MapPost("/", async (StaffNotes staffNotes, EduOne_FrContext db) =>
        {
            db.StaffNotes.Add(staffNotes);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/StaffNotes/{staffNotes.Id}",staffNotes);
        })
        .WithName("CreateStaffNotes")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EduOne_FrContext db) =>
        {
            var affected = await db.StaffNotes
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteStaffNotes")
        .WithOpenApi();
    }
}
