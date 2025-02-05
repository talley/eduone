using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Mvc;
using Eduone.Fr.Data.Entities;
namespace EduOne.Fr.RestServices.EndPoints;

public static class CoursesEndpoints
{
    public static void MapCoursesEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Courses").WithTags(nameof(Courses));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.Courses.ToListAsync();
        })
        .WithName("GetAllCourses")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Courses>, NotFound>> (int cours_id, EduOne_FrContext db) =>
        {
            return await db.Courses.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Cours_Id == cours_id)
                is Courses model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCoursesById")
        .WithOpenApi();


        // group.MapPut("/{id}", async Task<Results<Ok, NotFound>> ([FromRoute] int cours_id, Courses courses, EduOne_FrContext db) =>
        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> ( int id, Courses courses, EduOne_FrContext db) =>
        {
            var affected = await db.Courses
                .Where(model => model.Cours_Id == id)
                .ExecuteUpdateAsync(setters => setters
                   // .SetProperty(m => m.Cours_Id, courses.Cours_Id)
                    .SetProperty(m => m.Nom_Cours, courses.Nom_Cours)
                    .SetProperty(m => m.Description, courses.Description)
                    .SetProperty(m => m.ID_Department, courses.ID_Department)
                    .SetProperty(m => m.Statut, courses.Statut)
                    .SetProperty(m => m.AjouterAu, courses.AjouterAu)
                    .SetProperty(m => m.AjouterPar, courses.AjouterPar)
                    .SetProperty(m => m.ModifierAu, courses.ModifierAu)
                    .SetProperty(m => m.ModifierPar, courses.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCourses")
        .WithOpenApi();



        group.MapPost("/", async (Courses courses, EduOne_FrContext db) =>
        {
            db.Courses.Add(courses);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Courses/{courses.Cours_Id}",courses);
        })
        .WithName("CreateCourses")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int cours_id, EduOne_FrContext db) =>
        {
            var affected = await db.Courses
                .Where(model => model.Cours_Id == cours_id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCourses")
        .WithOpenApi();
    }
}
