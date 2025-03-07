using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduOne.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string API_KEY_NAME= "HOTELIA_X-API-KEY";
        private string API_KEY_VALUE;//= "my-secure-api-key";
        private EduOne_FrContext db = new EduOne_FrContext();

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        private async Task<string> GetApiSecurityKeyAsync()
        {
            string result="";

            var settings = await db.ApplicationSettings.ToListAsync().ConfigureAwait(false);
            var setting = settings.SingleOrDefault(x => x.AppKey == "APPLICATION.SECURITY.APIKEY");

            if (settings!= null){
                result = setting.AppValue;
            }

            return result;
        }

        public async Task Invoke(HttpContext context)
        {
            API_KEY_VALUE =await GetApiSecurityKeyAsync();
            if (!context.Request.Headers.TryGetValue(API_KEY_NAME, out var extractedApiKey) ||
                !API_KEY_VALUE.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized Access(Accès non autorisé)");
                return;
            }
            await _next(context);
        }
    }

}
