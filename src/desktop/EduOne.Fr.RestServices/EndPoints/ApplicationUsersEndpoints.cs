namespace EduOne.Fr.RestServices.EndPoints;

public static class ApplicationUsersEndpoints
{
    public static void MapApplicationUsersEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/ApplicationUsers").WithTags(nameof(ApplicationUsers));

        group.MapGet("/", async (EduOne_FrContext db) =>
            {
                return await db.ApplicationUsers.ToListAsync();
            })
            .WithName("GetAllApplicationUsers")
            .WithOpenApi()
            .RequireCors("ApplicationPolicy");

        group.MapGet("/{id}", async Task<Results<Ok<ApplicationUsers>, NotFound>> (Guid id, EduOne_FrContext db) =>
        {
            return await db.ApplicationUsers.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is ApplicationUsers model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetApplicationUsersById")
        .WithOpenApi()
        .RequireCors("ApplicationPolicy");

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid id, ApplicationUsers applicationUsers, EduOne_FrContext db) =>
        {
            var affected = await db.ApplicationUsers
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, applicationUsers.Id)
                    .SetProperty(m => m.RoleId, applicationUsers.RoleId)
                    .SetProperty(m => m.Utilisateur, applicationUsers.Utilisateur)
                    .SetProperty(m => m.Password, applicationUsers.Password)
                    .SetProperty(m => m.Statut, applicationUsers.Statut)
                    .SetProperty(m => m.Nom, applicationUsers.Nom)
                    .SetProperty(m => m.Prenom, applicationUsers.Prenom)
                    .SetProperty(m => m.DateNaissance, applicationUsers.DateNaissance)
                    .SetProperty(m => m.Notes, applicationUsers.Notes)
                    .SetProperty(m => m.Email, applicationUsers.Email)
                    .SetProperty(m => m.AjouterAu, applicationUsers.AjouterAu)
                    .SetProperty(m => m.AjouterPar, applicationUsers.AjouterPar)
                    .SetProperty(m => m.ModifierAu, applicationUsers.ModifierAu)
                    .SetProperty(m => m.ModifierPar, applicationUsers.ModifierPar)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateApplicationUsers")
        .WithOpenApi()
        .RequireCors("ApplicationPolicy");

        group.MapPost("/", async (ApplicationUsers applicationUsers, EduOne_FrContext db) =>
        {
            db.ApplicationUsers.Add(applicationUsers);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/ApplicationUsers/{applicationUsers.Id}", applicationUsers);
        })
        .WithName("CreateApplicationUsers")
        .WithOpenApi()
        .RequireCors("ApplicationPolicy");

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid id, EduOne_FrContext db) =>
        {
            var affected = await db.ApplicationUsers
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteApplicationUsers")
        .WithOpenApi()
        .RequireCors("ApplicationPolicy");
    }
}
