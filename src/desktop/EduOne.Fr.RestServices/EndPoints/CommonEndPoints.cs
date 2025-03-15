using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using Eduone.Fr.Data.Entities;

namespace EduOne.Fr.RestServices.EndPoints
{
    public static class CommonEndPoints
    {
        private static EduOne_FrContext db=new EduOne_FrContext();
        public static void MapCommonEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Commons").WithTags("Commons");

            group.MapGet("/Roles/{role}", static async Task<Results<Ok<Guid>, NotFound>> (string role, EduOne_FrContext db) =>
                {
                    var roleId = await GetRoleIdAsync(role);
                    return roleId == null ? TypedResults.Ok(roleId) : TypedResults.NotFound();
                })
                .WithName("GetCommonRoleById")
                .WithOpenApi()
                .RequireCors("ApplicationPolicy");



            group.MapGet("/Security/EncryptPassword/{password}", static async Task<Results<Ok<byte[]>, NotFound>> (string password, EduOne_FrContext db) =>
                {
                    var result = await EncryptPasswordAsync(password);
                    return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
                })
                .WithName("EncryptPassword")
                .WithOpenApi()
                .RequireCors("ApplicationPolicy");


            group.MapGet("/Security/DecryptPassword/{password}", static async Task<Results<Ok<string>, NotFound>> (byte[] password, EduOne_FrContext db) =>
            {
                var result = await DecryptPasswordAsync(password);
                return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
            })
                .WithName("DecryptPassword")
                .WithOpenApi()
                .RequireCors("ApplicationPolicy");

            //https://localhost:7027/api/Commons/Security/Authenticate/talleyouro@gmail.com/test
            group.MapGet("/Security/Authenticate/{email}/{password}", static async Task<Results<Ok<bool>, BadRequest>> (string email,string password, EduOne_FrContext db) =>
            {
                var result = await AuthenticateUserAsync(email, password);
                return TypedResults.Ok(result);//:TypedResults.NotFound();
            })
            .WithName("Authenticate")
            .WithOpenApi()
            .RequireCors("ApplicationPolicy");


            group.MapPost("/UploadImage/{id}", async Task<Results<Ok<StudentIdentifications>, BadRequest>> (int id, IFormFile file, EduOne_FrContext db) =>
            {
                if (file == null || file.Length == 0)
                    return TypedResults.BadRequest();

                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);

                var studentIdentification = new StudentIdentifications
                {
                    UID=Guid.NewGuid(),
                    Id = id,
                    FileData = memoryStream.ToArray() ,
                    ContentType = file.ContentType,
                    FileName = file.FileName,
                    AjouterAu=DateTime.Now,
                    AjouterPar=Environment.MachineName
                };

                db.StudentIdentifications.Add(studentIdentification);
                var result = await db.SaveChangesAsync();

                return result > 0 ? TypedResults.Ok(studentIdentification) : TypedResults.BadRequest();
                })
                .WithName("UpdateStudent0Identification")
                .WithOpenApi()
                .RequireCors("ApplicationPolicy");


            group.MapGet("/GetTables", static async Task<Results<Ok<List<string>>, NotFound>> (EduOne_FrContext db) =>
            {
                var result = await GetSyncTablesAsync();
                return TypedResults.Ok(result.ToList());
            })
                .WithName("GetTables")
                .WithOpenApi()
                .RequireCors("ApplicationPolicy");


            group.MapGet("/System/AppUrl/{isprod}", static async Task<Results<Ok<string>, NotFound>> (bool isprod, EduOne_FrContext db) =>
            {
                string result;
                var settings = await db.ApplicationSettings.ToListAsync();
                var prodUrl = settings.SingleOrDefault(x => x.AppKey == "APPLICATION.APPPROD.URL");
                var devUrl = settings.SingleOrDefault(x => x.AppKey == "APPLICATION.APPDEV.URL");
                if (isprod)
                {
                    result = prodUrl?.AppValue;
                }
                else
                {
                    result = devUrl?.AppValue;
                }
                return TypedResults.Ok(result);
            })
               .WithName("GetAppUrl")
               .WithOpenApi()
               .RequireCors("ApplicationPolicy");

            group.MapGet("/System/Prod", static async Task<Results<Ok<int>, NotFound>> (EduOne_FrContext db) =>
            {
            var settings = await db.ApplicationSettings.ToListAsync();
            var result = settings.SingleOrDefault(x => x.AppKey == "");
            var val = int.Parse(result?.AppValue.ToString());
                return TypedResults.Ok(val);
            })
                .WithName("CheckIfInProd")
                .WithOpenApi()
                .RequireCors("ApplicationPolicy");

        } //end endpoint class

        private static async Task<string> DecryptPasswordAsync(byte[] password)
        {
            string result;

            var cs = DbHelpers.CS;
            var query = $"SELECT dbo.func_decrypt_password('{password}','Iamsmart27@')";
            using (IDbConnection sqlcon = new SqlConnection(cs))
            {
                var oresult = await sqlcon.ExecuteScalarAsync<string>(query, commandType: CommandType.Text);
                result = oresult.ToString();
            }

            return result;
        }

        private static async Task<Guid> GetRoleIdAsync(string role)
        {
            var cs = DbHelpers.CS;
            var query = $"SELECT dbo.func_get_roleId('{role}')";
            Guid result;
            using (IDbConnection sqlcon = new SqlConnection(cs))
            {
                result = await sqlcon.ExecuteScalarAsync<Guid>(query, commandType: CommandType.Text).ConfigureAwait(false);
            }

            return result;
        }

        public static async Task<byte[]> EncryptPasswordAsync(string password)
        {
            var cs = DbHelpers.CS;
            var query = $"SELECT dbo.func_encrypt_password('{password}')";
            byte[] result;
            using (IDbConnection sqlcon = new SqlConnection(cs))
            {
                var oresult = await sqlcon.ExecuteScalarAsync<byte[]>(query, commandType: CommandType.Text);
                result = oresult?.ToArray();
            }

            return result;
        }

        public static async Task<bool> AuthenticateUserAsync(string email, string password)
        {
            bool result = false;

            var query = $" SELECT dbo.func_validate_password('{email}','{password}')";
            var cs = db.Database.GetConnectionString();
            if (cs != null)
            {
                using (var sqlcon = new SqlConnection(cs))
                {
                    await sqlcon.OpenAsync();

                    using (var sqlcmd = new SqlCommand(query, sqlcon))
                    {

                        var oresult=sqlcmd.ExecuteScalar();
                        result=bool.Parse(oresult?.ToString());
                    }

                        if (sqlcon.State == ConnectionState.Open)
                        {
                            await sqlcon.CloseAsync();
                        }
                }
            }
            return result;
        }

        public static async Task<IEnumerable<string>> GetSyncTablesAsync()
        {
            IEnumerable<string> result = new List<string>();
            var sql = "SELECT name FROM sys.tables";
            using (IDbConnection sqlcon = new SqlConnection(DbHelpers.CS))
            {

                result = await sqlcon.QueryAsync<string>(sql);
            }
            return result;
        }
    }
}
