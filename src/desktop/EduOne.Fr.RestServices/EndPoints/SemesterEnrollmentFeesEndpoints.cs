using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class SemesterEnrollmentFeesEndpoints
{
    public static void MapSemesterEnrollmentFeesEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/SemesterEnrollmentFees").WithTags(nameof(SemesterEnrollmentFees));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.SemesterEnrollmentFees.ToListAsync();
        })
        .WithName("GetAllSemesterEnrollmentFees")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<SemesterEnrollmentFees>, NotFound>> (int id, EduOne_FrContext db) =>
        {
            return await db.SemesterEnrollmentFees.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is SemesterEnrollmentFees model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSemesterEnrollmentFeesById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, SemesterEnrollmentFees semesterEnrollmentFees, EduOne_FrContext db) =>
        {
            var affected = await db.SemesterEnrollmentFees
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.GID, semesterEnrollmentFees.GID)
                    .SetProperty(m=>m.MontantDu, semesterEnrollmentFees.MontantDu)
                    .SetProperty(m => m.Balance, semesterEnrollmentFees.Balance)
                    .SetProperty(m => m.EleveId, semesterEnrollmentFees.EleveId)
                    .SetProperty(m => m.SemestreId, semesterEnrollmentFees.SemestreId)
                    .SetProperty(m => m.Statut, semesterEnrollmentFees.Statut)
                    .SetProperty(m => m.MontantReçu, semesterEnrollmentFees.MontantReçu)
                    .SetProperty(m => m.AjouterAu, semesterEnrollmentFees.AjouterAu)
                    .SetProperty(m => m.AjouterPar, semesterEnrollmentFees.AjouterPar)
                    .SetProperty(m => m.ModifierAu, semesterEnrollmentFees.ModifierAu)
                    .SetProperty(m => m.ModifierPar, semesterEnrollmentFees.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSemesterEnrollmentFees")
        .WithOpenApi();

        group.MapPost("/", async (SemesterEnrollmentFees semesterEnrollmentFees, EduOne_FrContext db) =>
        {
            db.SemesterEnrollmentFees.Add(semesterEnrollmentFees);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/SemesterEnrollmentFees/{semesterEnrollmentFees.Id}",semesterEnrollmentFees);
        })
        .WithName("CreateSemesterEnrollmentFees")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EduOne_FrContext db) =>
        {
            var affected = await db.SemesterEnrollmentFees
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSemesterEnrollmentFees")
        .WithOpenApi();
    }
}
