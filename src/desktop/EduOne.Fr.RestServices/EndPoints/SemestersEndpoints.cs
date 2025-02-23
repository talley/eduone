using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class SemestersEndpoints
{
    public static void MapSemestersEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Semesters").WithTags(nameof(Semesters));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.Semesters.ToListAsync();
        })
        .WithName("GetAllSemesters")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Semesters>, NotFound>> (int id, EduOne_FrContext db) =>
        {
            return await db.Semesters.AsNoTracking()
                .FirstOrDefaultAsync(model => model.ID == id)
                is Semesters model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSemestersById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Semesters semesters, EduOne_FrContext db) =>
        {
            var affected = await db.Semesters
                .Where(model => model.ID == id)
                .ExecuteUpdateAsync(setters => setters
                    //.SetProperty(m => m.ID, semesters.ID)
                    .SetProperty(m => m.Année, semesters.Année)
                    .SetProperty(m => m.Semestre, semesters.Semestre)
                    .SetProperty(m => m.Notes, semesters.Notes)
                    .SetProperty(m => m.Statut, semesters.Statut)
                    .SetProperty(m => m.AjouterAu, semesters.AjouterAu)
                    .SetProperty(m => m.AjouterPar, semesters.AjouterPar)
                    .SetProperty(m => m.ModifierAu, semesters.ModifierAu)
                    .SetProperty(m => m.ModifierPar, semesters.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSemesters")
        .WithOpenApi();

        group.MapPost("/", async (Semesters semesters, EduOne_FrContext db) =>
        {
            db.Semesters.Add(semesters);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Semesters/{semesters.ID}",semesters);
        })
        .WithName("CreateSemesters")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EduOne_FrContext db) =>
        {
            var affected = await db.Semesters
                .Where(model => model.ID == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSemesters")
        .WithOpenApi();
    }
}
