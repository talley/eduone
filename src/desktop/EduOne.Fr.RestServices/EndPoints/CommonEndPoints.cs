using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;

namespace EduOne.Fr.RestServices.EndPoints
{
    public static class CommonEndPoints
    {
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
                    var roleId = await EncryptPasswordAsync(password);
                    return roleId == null ? TypedResults.Ok(roleId) : TypedResults.NotFound();
                })
                .WithName("EncryptPassword")
                .WithOpenApi()
                .RequireCors("ApplicationPolicy");
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
                result = await sqlcon.ExecuteScalarAsync<byte[]>(query, commandType: CommandType.Text);
            }

            return result;
        }
    }
}
