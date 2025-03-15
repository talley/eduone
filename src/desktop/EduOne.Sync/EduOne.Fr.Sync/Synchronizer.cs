using Dotmim.Sync.Sqlite;
using Dotmim.Sync.SqlServer;
using Dotmim.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace EduOne.Fr.Sync
{
    public static class Synchronizer
    {
       public static async void SyncTables(string apiUrl, string token,string email)
        {
            // Sql Server provider, the "server" or "hub".
            SqlSyncProvider serverProvider = new SqlSyncProvider(DbHelpers.CS);

            // Sqlite Client provider acting as the "client"
            SqliteSyncProvider clientProvider = new SqliteSyncProvider(string.Concat(email, "_eudone.db"));

            // Tables involved in the sync process:
            var tables = await GetSyncTablesAsync(apiUrl, token);
            var setup = new SyncSetup(tables);

            // Sync agent
            SyncAgent agent = new SyncAgent(clientProvider, serverProvider);

          //  do
          //  {
            var result=  await agent.SynchronizeAsync(setup).ConfigureAwait(false);
              //  Console.WriteLine(result);

           // } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static async Task<List<string>> GetSyncTablesAsync(string apiUrl,string token)
        {
            List<string> result = new List<string>();

            using (var client = new HttpClient())
            {
                try
                {

                    client.DefaultRequestHeaders.Add("HOTELIA_X-API-KEY", token);
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = JsonConvert.DeserializeObject<List<string>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }
    }
}
