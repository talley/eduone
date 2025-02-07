using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class DepartmentHeadsEndpoints
{
    public static void MapDepartmentHeadsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/DepartmentHeads").WithTags(nameof(DepartmentHeads));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.DepartmentHeads.ToListAsync();
        })
        .WithName("GetAllDepartmentHeads")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<DepartmentHeads>, NotFound>> (int id, EduOne_FrContext db) =>
        {
            return await db.DepartmentHeads.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is DepartmentHeads model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetDepartmentHeadsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, DepartmentHeads departmentHeads, EduOne_FrContext db) =>
        {
            var affected = await db.DepartmentHeads
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    //.SetProperty(m => m.Id, departmentHeads.Id)
                    .SetProperty(m => m.Nom, departmentHeads.Nom)
                    .SetProperty(m => m.Prénom, departmentHeads.Prénom)
                    .SetProperty(m => m.TelePhone, departmentHeads.TelePhone)
                    .SetProperty(m => m.DateNaissance, departmentHeads.DateNaissance)
                    .SetProperty(m => m.Fax, departmentHeads.Fax)
                    .SetProperty(m => m.Email, departmentHeads.Email)
                    .SetProperty(m => m.Notes, departmentHeads.Notes)
                    .SetProperty(m => m.Statut, departmentHeads.Statut)
                    .SetProperty(m => m.AjouterAu, departmentHeads.AjouterAu)
                    .SetProperty(m => m.AjouterPar, departmentHeads.AjouterPar)
                    .SetProperty(m => m.ModifierAu, departmentHeads.ModifierAu)
                    .SetProperty(m => m.ModifierPar, departmentHeads.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateDepartmentHeads")
        .WithOpenApi();

        group.MapPost("/", async (DepartmentHeads departmentHeads, EduOne_FrContext db) =>
        {
            db.DepartmentHeads.Add(departmentHeads);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/DepartmentHeads/{departmentHeads.Id}",departmentHeads);
        })
        .WithName("CreateDepartmentHeads")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EduOne_FrContext db) =>
        {
            var affected = await db.DepartmentHeads
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteDepartmentHeads")
        .WithOpenApi();
    }
}
