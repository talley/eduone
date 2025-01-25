

namespace EduOne.Helpers
{
    /// <summary>
    ///  Helpers for db access
    /// </summary>
    public class DbHelpers
    {
        /// <summary>
        /// Gets the connection string(will be moved to  appsettings.json in production)
        /// </summary>
        /// <value>
        /// The cs.
        /// </value>
        public static string CS=>@"Data Source=.;Initial Catalog=EduOne_Fr;Persist Security Info=True;User ID=eduone;Password=Iamsmart27!;TrustServerCertificate=true;";
    }
}
