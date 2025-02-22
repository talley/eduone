using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class EnrollmentsEndpoints
{
    public static void MapEnrollmentsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Enrollments").WithTags(nameof(Enrollments));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.Enrollments.ToListAsync();
        })
        .WithName("GetAllEnrollments")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Enrollments>, NotFound>> (int inscriptionid, EduOne_FrContext db) =>
        {
            return await db.Enrollments.AsNoTracking()
                .FirstOrDefaultAsync(model => model.InscriptionID == inscriptionid)
                is Enrollments model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetEnrollmentsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Enrollments enrollments, EduOne_FrContext db) =>
        {
            var affected = await db.Enrollments
                .Where(model => model.InscriptionID == id)
                .ExecuteUpdateAsync(setters => setters
                    //.SetProperty(m => m.InscriptionID, enrollments.InscriptionID)
                    .SetProperty(m => m.EleveId, enrollments.EleveId)
                    .SetProperty(m => m.CoursId, enrollments.CoursId)
                    .SetProperty(m => m.Date_Inscription, enrollments.Date_Inscription)
                    .SetProperty(m => m.Grade, enrollments.Grade)
                    .SetProperty(m => m.Statut, enrollments.Statut)
                    .SetProperty(m => m.Notes, enrollments.Notes)
                    .SetProperty(m => m.AjouterAu, enrollments.AjouterAu)
                    .SetProperty(m => m.AjouterPar, enrollments.AjouterPar)
                    .SetProperty(m => m.ModifierAu, enrollments.ModifierAu)
                    .SetProperty(m => m.ModifierPar, enrollments.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateEnrollments")
        .WithOpenApi();

        group.MapPost("/", async (Enrollments enrollments, EduOne_FrContext db) =>
        {
            db.Enrollments.Add(enrollments);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Enrollments/{enrollments.InscriptionID}",enrollments);
        })
        .WithName("CreateEnrollments")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int inscriptionid, EduOne_FrContext db) =>
        {
            var affected = await db.Enrollments
                .Where(model => model.InscriptionID == inscriptionid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteEnrollments")
        .WithOpenApi();
    }
}
