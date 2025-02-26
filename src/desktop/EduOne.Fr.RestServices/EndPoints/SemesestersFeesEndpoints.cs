using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class SemesestersFeesEndpoints
{
    public static void MapSemesestersFeesEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/SemesestersFees").WithTags(nameof(SemesestersFees));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.SemesestersFees.ToListAsync();
        })
        .WithName("GetAllSemesestersFees")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<SemesestersFees>, NotFound>> (int id, EduOne_FrContext db) =>
        {
            return await db.SemesestersFees.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is SemesestersFees model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSemesestersFeesById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, SemesestersFees semesestersFees, EduOne_FrContext db) =>
        {
            var affected = await db.SemesestersFees
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    //.SetProperty(m => m.Id, semesestersFees.Id)
                    .SetProperty(m => m.SemestreId, semesestersFees.SemestreId)
                    .SetProperty(m => m.Frais, semesestersFees.Frais)
                    .SetProperty(m => m.Notes, semesestersFees.Notes)
                    .SetProperty(m => m.AjouterAu, semesestersFees.AjouterAu)
                    .SetProperty(m => m.AjouterPar, semesestersFees.AjouterPar)
                    .SetProperty(m => m.ModifierAu, semesestersFees.ModifierAu)
                    .SetProperty(m => m.ModifierPar, semesestersFees.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSemesestersFees")
        .WithOpenApi();

        group.MapPost("/", async (SemesestersFees semesestersFees, EduOne_FrContext db) =>
        {
            db.SemesestersFees.Add(semesestersFees);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/SemesestersFees/{semesestersFees.Id}",semesestersFees);
        })
        .WithName("CreateSemesestersFees")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EduOne_FrContext db) =>
        {
            var affected = await db.SemesestersFees
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSemesestersFees")
        .WithOpenApi();
    }
}
