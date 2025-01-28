using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using EduOne.Fr.Logging.Helpers;

namespace EduOne.Fr.Logging
{
    public static class DatabaseLogger
    {
        [Obsolete("I will use new Serilog method on the next release")]
        public static void LogExceptionToDatabase(this Exception ex,string Project,string FileName,int LineNumber)
        {
            // SQL Server connection string
            string connectionString = DbHelpers.CS.Replace("***********", "Iamsmart27!");

            // Define column options for the database sink
            var columnOptions = new ColumnOptions
            {
                AdditionalColumns = new Collection<SqlColumn>
            {
                new SqlColumn { ColumnName = "Project", DataType = System.Data.SqlDbType.NVarChar, DataLength = 400 },
                new SqlColumn { ColumnName = "FileName", DataType = System.Data.SqlDbType.NVarChar, DataLength = 500 },
                new SqlColumn { ColumnName = "LineNumber", DataType = System.Data.SqlDbType.Int}
            }
            };

            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("Project", Project)
                .Enrich.WithProperty("FileName",FileName)
                .Enrich.WithProperty("LineNumber",LineNumber)
                .WriteTo.MSSqlServer(
                    connectionString: connectionString,
                    tableName: "ApplicationLogs",
                    autoCreateSqlTable: true, // Set to true to automatically create the table
                    columnOptions: columnOptions,
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information // Set the minimum log level
                )
                .CreateLogger();

            try
            {
                // Example exception
                throw new Exception("This is a test exception for SQL logging");
            }
            catch (Exception exx)
            {
                // Log the exception to SQL Server
                Log.Error(ex, "An error occurred");
            }
            finally
            {
                // Flush and close the logger
                Log.CloseAndFlush();
            }
        }
    }
}
