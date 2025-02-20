using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class StaffsEndpoints
{
    public static void MapStaffsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Staffs").WithTags(nameof(Staffs));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.Staffs.ToListAsync();
        })
        .WithName("GetAllStaffs")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Staffs>, NotFound>> (int id, EduOne_FrContext db) =>
        {
            return await db.Staffs.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Staffs model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetStaffsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Staffs staffs, EduOne_FrContext db) =>
        {
            var x = 122;
            var affected = await db.Staffs
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    //.SetProperty(m => m.Id, staffs.Id)
                    .SetProperty(m => m.Nom, staffs.Nom)
                    .SetProperty(m => m.Prénom, staffs.Prénom)
                    .SetProperty(m => m.Surnom, staffs.Surnom)
                    .SetProperty(m => m.LieuNaissance, staffs.LieuNaissance)
                    .SetProperty(m => m.DateNaissance, staffs.DateNaissance)
                    .SetProperty(m => m.Genre, staffs.Genre)
                    .SetProperty(m => m.Email, staffs.Email)
                    .SetProperty(m => m.TelePhone, staffs.TelePhone)
                    .SetProperty(m => m.Fax, staffs.Fax)
                    .SetProperty(m => m.Date_Embauche, staffs.Date_Embauche)
                    .SetProperty(m => m.Role, staffs.Role)
                    .SetProperty(m => m.Notes, staffs.Notes)
                    .SetProperty(m => m.Status, staffs.Status)
                    .SetProperty(m => m.AjouterAu, staffs.AjouterAu)
                    .SetProperty(m => m.AjouterPar, staffs.AjouterPar)
                    .SetProperty(m => m.ModifierAu, staffs.ModifierAu)
                    .SetProperty(m => m.ModifierPar, staffs.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateStaffs")
        .WithOpenApi();

        group.MapPost("/", async (Staffs staffs, EduOne_FrContext db) =>
        {
            db.Staffs.Add(staffs);
            await db.SaveChangesAsync();
            return TypedResults.Ok(staffs);//reated($"/api/Staffs/{staffs.Id}",staffs);
        })
        .WithName("CreateStaffs")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EduOne_FrContext db) =>
        {
            var affected = await db.Staffs
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteStaffs")
        .WithOpenApi();
    }
}
