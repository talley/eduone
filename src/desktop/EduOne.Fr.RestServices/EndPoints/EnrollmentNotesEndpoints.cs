using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class EnrollmentNotesEndpoints
{
    public static void MapEnrollmentNotesEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/EnrollmentNotes").WithTags(nameof(EnrollmentNotes));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.EnrollmentNotes.ToListAsync();
        })
        .WithName("GetAllEnrollmentNotes")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<EnrollmentNotes>, NotFound>> (int eid, EduOne_FrContext db) =>
        {
            return await db.EnrollmentNotes.AsNoTracking()
                .FirstOrDefaultAsync(model => model.EId == eid)
                is EnrollmentNotes model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetEnrollmentNotesById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int eid, EnrollmentNotes enrollmentNotes, EduOne_FrContext db) =>
        {
            var affected = await db.EnrollmentNotes
                .Where(model => model.EId == eid)
                .ExecuteUpdateAsync(setters => setters
                   // .SetProperty(m => m.EId, enrollmentNotes.EId)
                    .SetProperty(m => m.Id, enrollmentNotes.Id)
                    .SetProperty(m => m.Notes, enrollmentNotes.Notes)
                    .SetProperty(m => m.AjouterAu, enrollmentNotes.AjouterAu)
                    .SetProperty(m => m.AjouterPar, enrollmentNotes.AjouterPar)
                    .SetProperty(m => m.ModifierAu, enrollmentNotes.ModifierAu)
                    .SetProperty(m => m.ModifierPar, enrollmentNotes.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateEnrollmentNotes")
        .WithOpenApi();

        group.MapPost("/", async (EnrollmentNotes enrollmentNotes, EduOne_FrContext db) =>
        {
            db.EnrollmentNotes.Add(enrollmentNotes);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/EnrollmentNotes/{enrollmentNotes.EId}",enrollmentNotes);
        })
        .WithName("CreateEnrollmentNotes")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int eid, EduOne_FrContext db) =>
        {
            var affected = await db.EnrollmentNotes
                .Where(model => model.EId == eid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteEnrollmentNotes")
        .WithOpenApi();
    }
}
