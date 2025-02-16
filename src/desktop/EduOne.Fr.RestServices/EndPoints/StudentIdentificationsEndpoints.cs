using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class StudentIdentificationsEndpoints
{
    public static void MapStudentIdentificationsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/StudentIdentifications").WithTags(nameof(StudentIdentifications));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.StudentIdentifications.ToListAsync();
        })
        .WithName("GetAllStudentIdentifications")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<StudentIdentifications>, NotFound>> (Guid uid, EduOne_FrContext db) =>
        {
            return await db.StudentIdentifications.AsNoTracking()
                .FirstOrDefaultAsync(model => model.UID == uid)
                is StudentIdentifications model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetStudentIdentificationsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid uid, StudentIdentifications studentIdentifications, EduOne_FrContext db) =>
        {
            var affected = await db.StudentIdentifications
                .Where(model => model.UID == uid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.UID, studentIdentifications.UID)
                    .SetProperty(m => m.Id, studentIdentifications.Id)
                    .SetProperty(m => m.FileName, studentIdentifications.FileName)
                    .SetProperty(m => m.ContentType, studentIdentifications.ContentType)
                    .SetProperty(m => m.FileData, studentIdentifications.FileData)
                    .SetProperty(m => m.AjouterAu, studentIdentifications.AjouterAu)
                    .SetProperty(m => m.AjouterPar, studentIdentifications.AjouterPar)
                    .SetProperty(m => m.ModifierAu, studentIdentifications.ModifierAu)
                    .SetProperty(m => m.ModifierPar, studentIdentifications.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateStudentIdentifications")
        .WithOpenApi();

        group.MapPost("/", async (StudentIdentifications studentIdentifications, EduOne_FrContext db) =>
        {
            db.StudentIdentifications.Add(studentIdentifications);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/StudentIdentifications/{studentIdentifications.UID}",studentIdentifications);
        })
        .WithName("CreateStudentIdentifications")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid uid, EduOne_FrContext db) =>
        {
            var affected = await db.StudentIdentifications
                .Where(model => model.UID == uid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteStudentIdentifications")
        .WithOpenApi();
    }
}
