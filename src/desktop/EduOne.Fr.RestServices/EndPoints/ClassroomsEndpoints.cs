using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class ClassroomsEndpoints
{
    public static void MapClassroomsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Classrooms").WithTags(nameof(Classrooms));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.Classrooms.ToListAsync();
        })
        .WithName("GetAllClassrooms")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Classrooms>, NotFound>> (int id, EduOne_FrContext db) =>
        {
            return await db.Classrooms.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Classrooms model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetClassroomsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Classrooms classrooms, EduOne_FrContext db) =>
        {
            var affected = await db.Classrooms
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                   // .SetProperty(m => m.Id, classrooms.Id)
                    .SetProperty(m => m.NuméroChambre, classrooms.NuméroChambre)
                    .SetProperty(m => m.Bâtiment, classrooms.Bâtiment)
                    .SetProperty(m => m.Capacité, classrooms.Capacité)
                    .SetProperty(m => m.Statut, classrooms.Statut)
                    .SetProperty(m => m.Notes, classrooms.Notes)
                    .SetProperty(m => m.AjouterAu, classrooms.AjouterAu)
                    .SetProperty(m => m.AjouterPar, classrooms.AjouterPar)
                    .SetProperty(m => m.ModifierAu, classrooms.ModifierAu)
                    .SetProperty(m => m.ModifierPar, classrooms.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateClassrooms")
        .WithOpenApi();

        group.MapPost("/", async (Classrooms classrooms, EduOne_FrContext db) =>
        {
            db.Classrooms.Add(classrooms);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Classrooms/{classrooms.Id}",classrooms);
        })
        .WithName("CreateClassrooms")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EduOne_FrContext db) =>
        {
            var affected = await db.Classrooms
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteClassrooms")
        .WithOpenApi();
    }
}
