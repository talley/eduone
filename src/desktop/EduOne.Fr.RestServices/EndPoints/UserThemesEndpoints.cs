using Microsoft.EntityFrameworkCore;
using Eduone.Fr.Data.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace EduOne.Fr.RestServices.EndPoints;

public static class UserThemesEndpoints
{
    public static void MapUserThemesEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/UserThemes").WithTags(nameof(UserThemes));

        group.MapGet("/", async (EduOne_FrContext db) =>
        {
            return await db.UserThemes.ToListAsync();
        })
        .WithName("GetAllUserThemes")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<UserThemes>, NotFound>> (int id, EduOne_FrContext db) =>
        {
            return await db.UserThemes.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is UserThemes model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetUserThemesById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, UserThemes userThemes, EduOne_FrContext db) =>
        {
            var affected = await db.UserThemes
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, userThemes.Id)
                    .SetProperty(m => m.Email, userThemes.Email)
                    .SetProperty(m => m.Thème, userThemes.Thème)
                    .SetProperty(m => m.AjouterAu, userThemes.AjouterAu)
                    .SetProperty(m => m.AjouterPar, userThemes.AjouterPar)
                    .SetProperty(m => m.ModifierAu, userThemes.ModifierAu)
                    .SetProperty(m => m.ModifierPar, userThemes.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateUserThemes")
        .WithOpenApi();

        group.MapPost("/", async (UserThemes userThemes, EduOne_FrContext db) =>
        {
            db.UserThemes.Add(userThemes);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/UserThemes/{userThemes.Id}",userThemes);
        })
        .WithName("CreateUserThemes")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, EduOne_FrContext db) =>
        {
            var affected = await db.UserThemes
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteUserThemes")
        .WithOpenApi();
    }
}
