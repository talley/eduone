using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class StudentsEndpoints
{
    public static void MapStudentsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Students").WithTags(nameof(Students));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.Students.ToListAsync();
        })
        .WithName("GetAllStudents")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Students>, NotFound>> (int id, EduOne_FrContext db) =>
        {
            return await db.Students.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Students model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetStudentsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Students students, EduOne_FrContext db) =>
        {
            var ixd = 1;
            var affected = await db.Students
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.GlobalId, students.GlobalId)
                    //.SetProperty(m => m.Id, students.Id)
                    .SetProperty(m => m.Nom, students.Nom)
                    .SetProperty(m => m.Prénom, students.Prénom)
                    .SetProperty(m => m.Surnom, students.Surnom)
                    .SetProperty(m => m.LieuNaissance, students.LieuNaissance)
                    .SetProperty(m => m.DateNaissance, students.DateNaissance)
                    .SetProperty(m => m.Genre, students.Genre)
                    .SetProperty(m => m.Email, students.Email)
                    .SetProperty(m => m.TelePhone, students.TelePhone)
                    .SetProperty(m => m.Fax, students.Fax)
                    .SetProperty(m => m.Addresse, students.Addresse)
                    .SetProperty(m => m.Addresse2, students.Addresse2)
                    .SetProperty(m => m.Ville, students.Ville)
                    .SetProperty(m => m.État, students.État)
                    .SetProperty(m => m.Pays, students.Pays)
                    .SetProperty(m => m.Date_Inscription, students.Date_Inscription)
                    .SetProperty(m => m.Notes, students.Notes)
                    .SetProperty(m => m.Statut, students.Statut)
                    .SetProperty(m => m.AjouterAu, students.AjouterAu)
                    .SetProperty(m => m.AjouterPar, students.AjouterPar)
                    .SetProperty(m => m.ModifierAu, students.ModifierAu)
                    .SetProperty(m => m.ModifierPar, students.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateStudents")
        .WithOpenApi();

        group.MapPost("/", async (Students students, EduOne_FrContext db) =>
        {
            db.Students.Add(students);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Students/{students.Id}",students);
        })
        .WithName("CreateStudents")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EduOne_FrContext db) =>
        {
            var affected = await db.Students
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteStudents")
        .WithOpenApi();
    }
}
