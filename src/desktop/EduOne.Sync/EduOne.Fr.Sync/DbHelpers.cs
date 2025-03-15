

namespace EduOne.Fr.Sync
{
    /// <summary>
    ///  Helpers for db access
    /// </summary>
    public class DbHelpers
    {

        public static string DbHost { get; } = "localhost";
        public static string DbName { get; } = "EduOne_Fr";
        public static string DbUser { get; } = "eduone";
        public static string DbUserPass { get; } = "Iamsmart27!";
        public static string DbTableName { get; } = "localhost";
        /// <summary>
        /// Gets the connection string(will be moved to  appsettings.json in production)
        /// </summary>
        /// <value>
        /// The cs.
        /// </value>
        public static string CS=>@"Data Source=.;Initial Catalog=EduOne_Fr;Persist Security Info=True;User ID=eduone;Password=Iamsmart27!;TrustServerCertificate=true;";
    }
}
