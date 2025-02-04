using Microsoft.EntityFrameworkCore;
using EduOne.Fr.RestServices.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class DepartmentsEndpoints
{
    //Authencation later
    public static void MapDepartmentsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Departments").WithTags(nameof(Departments));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.Departments.ToListAsync();
        })
        .WithName("GetAllDepartments")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Departments>, NotFound>> (int id, EduOne_FrContext db) =>
        {
            return await db.Departments.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Departments model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetDepartmentsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Departments departments, EduOne_FrContext db) =>
        {
            var affected = await db.Departments
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                   // .SetProperty(m => m.Id, departments.Id)
                    .SetProperty(m => m.Nom_Département, departments.Nom_Département)
                    .SetProperty(m => m.ID_Chef_Département, departments.ID_Chef_Département)
                    .SetProperty(m => m.AjouterAu, departments.AjouterAu)
                    .SetProperty(m => m.AjouterPar, departments.AjouterPar)
                    .SetProperty(m => m.ModifierAu, departments.ModifierAu)
                    .SetProperty(m => m.ModifierPar, departments.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateDepartments")
        .WithOpenApi();

        group.MapPost("/", async (Departments departments, EduOne_FrContext db) =>
        {
            db.Departments.Add(departments);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Departments/{departments.Id}",departments);
        })
        .WithName("CreateDepartments")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EduOne_FrContext db) =>
        {
            var affected = await db.Departments
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteDepartments")
        .WithOpenApi();
    }
}
